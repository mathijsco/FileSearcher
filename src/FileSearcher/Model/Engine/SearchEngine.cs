using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using FileSearcher.Model.CriterionSchemas;
using FileSearcher.Plugin;

namespace FileSearcher.Model.Engine
{
    internal class SearchEngine
    {
        private readonly EngineOptions _engineOptions;
        private readonly IList<ICriterion> _additionalCriterion;
        private readonly IList<SearchException> _expections;
        private bool _stop;
        private Task<IList<SearchResult>> _currentTask;
        private DateTime _startTime;

        public SearchEngine(EngineOptions engineOptions, IEnumerable<ICriterion> additionalCriterion)
        {
            if (engineOptions == null) throw new ArgumentNullException("engineOptions");
            if (additionalCriterion == null) additionalCriterion = Enumerable.Empty<ICriterionPlugin>();

            _engineOptions = engineOptions;
            _additionalCriterion = additionalCriterion.ToList();
            this.RefreshTimer = TimeSpan.FromSeconds(1);
            _expections = new List<SearchException>();
        }

        /// <summary>
        /// Gets or sets the time span for the timeout of the match callback.
        /// </summary>
        public TimeSpan RefreshTimer { get; set; }

        /// <summary>
        /// Gets the time that the search engine was working on the last operation.
        /// </summary>
        public TimeSpan OperatingTime { get; private set; }

        /// <summary>
        /// Gets a list with all the search exceptions of the last operation.
        /// </summary>
        public IList<SearchException> Exceptions { get { return new ReadOnlyCollection<SearchException>(_expections); } }

        /// <summary>
        /// Gets a list of all the criteria that were used in the current or last operation.
        /// </summary>
        public IList<ICriterion> UsedCriteria { get; private set; } 

        /// <summary>
        /// Value indicating whether the search engine is still running.
        /// </summary>
        public bool IsRunning { get { return _currentTask != null; } }


        /// <summary>
        /// Starts the search operation.
        /// </summary>
        /// <param name="matchCallback">The callback when matches are found.</param>
        /// <param name="finishCallback">The callback when the search is done.</param>
        public void Start(Action<IEnumerable<SearchResult>> matchCallback, Action finishCallback)
        {
            this.OperatingTime = new TimeSpan();
            this.UsedCriteria = null;
            _startTime = DateTime.UtcNow;
            _expections.Clear();

            var timeout = new TimedCallback<SearchResult>(this.RefreshTimer, matchCallback);
            _stop = false;

            _currentTask = Task.Factory.StartNew((Func<object, IList<SearchResult>>)Search, timeout);
            _currentTask.ContinueWith(t => timeout.SetData(t.Result))
                .ContinueWith(t => {
                    _currentTask = null;
                    this.OperatingTime = DateTime.UtcNow - _startTime;
                    finishCallback();
                });
        }

        /// <summary>
        /// Aborts the current search operation.
        /// </summary>
        public void Stop()
        {
            if (this.IsRunning)
                _stop = true;
        }

        private IList<ICriterion> BuildCriteria()
        {
            // Only allow a single IPostProcessingCriterion. Otherwise the results will be strange.
            var criteria = CriteriaFactory.Build(_engineOptions).Union(_additionalCriterion).OrderBy(c => c is IPostProcessingCriterion).ThenBy(c => c.Weight).ToList();
            this.UsedCriteria = new ReadOnlyCollection<ICriterion>(criteria);
            return criteria;
        }

        private IList<SearchResult> Search(object state)
        {
            var timer = (TimedCallback<SearchResult>) state;

            var criteria = BuildCriteria();
            var list = new List<SearchResult>(64);
            var requiresPostProcessing = criteria.Any(c => c is IPostProcessingCriterion);

            foreach (var rootDirectory in _engineOptions.RootDirectories)
            {
                foreach (var fileSystemInfo in ListAllFileSystemInfo(rootDirectory, -1))
                {
                    var contexts = new Dictionary<Type, ICriterionContext>();
                    var isDir = fileSystemInfo is DirectoryInfo;
                    var match = true;

                    try
                    {
                        foreach (var c in criteria)
                        {
                            var context = c.BuildContext();

                            // Check if the criterion support the target file system type.
                            if ((c.DirectorySupport && isDir) || (c.FileSupport && !isDir))
                            {
                                if (c.IsMatch(fileSystemInfo, context))
                                {
                                    // Add the context if it is a match.
                                    if (context != null)
                                        contexts.Add(c.GetType(), context);
                                }
                                else
                                {
                                    match = false;
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _expections.Add(SearchExceptionFactory.Build(fileSystemInfo, ex));
                        match = false;
                    }

                    if (match && !requiresPostProcessing)
                        list.Add(new SearchResult(fileSystemInfo) { Metadata = contexts });

                    // Is match, and a result is not important.
                    if (list.Count > 0 && !requiresPostProcessing && timer.DataNeeded)
                    {
                        timer.SetData(list);
                        list = new List<SearchResult>(64);
                    }

                    // Stop the loop
                    if (_stop) break;
                }
                // Stop the loop
                if (_stop) break;
            }

            if (requiresPostProcessing)
            {
                // Pick the last one, this is the most intensive criterion.
                var resultLists = criteria.OfType<IPostProcessingCriterion>().Single();
                return resultLists.PostProcess().ToList();
            }

            return list;
        }

        private IEnumerable<FileSystemInfo> ListAllFileSystemInfo(FileSystemInfo fileSystemInfo, int level)
        {
            var directoryInfo = fileSystemInfo as DirectoryInfo;
            var isRoot = level == -1;

            // Return the folder, or if it is the file, always. Skip the root level.
            if (!isRoot && (directoryInfo == null || _engineOptions.SearchIncludesFolders))
                yield return fileSystemInfo;

            if (directoryInfo != null && (_engineOptions.SearchRecursive || isRoot)) // Only if recursive or if the level is the root.
            {
                FileSystemInfo[] infos = null;
                try
                {
                    infos = directoryInfo.GetFileSystemInfos();
                }
                catch (UnauthorizedAccessException ex)
                {
                    _expections.Add(SearchExceptionFactory.Build(directoryInfo, ex));
                }
                if (infos == null) yield break;

                foreach (var item in infos.SelectMany(s => ListAllFileSystemInfo(s, level + 1)))
                {
                    if (_stop) yield break;
                    yield return item;
                }
            }
        }
    }
}

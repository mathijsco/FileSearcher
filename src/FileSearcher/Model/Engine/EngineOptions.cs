using System;
using System.IO;
using FileSearcher.Model.EncodingDetection;
using FileSearcher.Model.Entities;

namespace FileSearcher.Model.Engine
{
    internal class EngineOptions
    {
        public EngineOptions(DirectoryInfo[] rootDirectories)
        {
            if (rootDirectories == null) throw new ArgumentNullException("rootDirectories");
            if (rootDirectories.Length <= 0) throw new ArgumentException(@"Minimal 1 root directory has to be specified.", "rootDirectories");

            this.RootDirectories = rootDirectories;
        }

        public DirectoryInfo[] RootDirectories { get; private set; }


        #region Basic

        public string SearchName { get; set; }

        public bool SearchNameIgnoreCasing { get; set; }

        public bool SearchNameMatchFullPath { get; set; }

        public bool SearchNameAsRegularExpression { get; set; }

        public bool SearchRecursive { get; set; }

        public bool SearchIncludesFolders { get; set; }

        public bool SearchInArchives { get; set; }

        #endregion

        #region Attributes

        public FileAttributes AttributesIncluded { get; set; }

        public FileAttributes AttributesExcluded { get; set; }

        #endregion

        #region Size

        public long? MinimumSize { get; set; }

        public long? MaximumSize { get; set; }

        #endregion

        #region Dates

        public FileDateOption DateOption { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        #endregion

        #region File content

        public string ContentText { get; set; }

        public IEncodingFactory ContentEncodingFactory { get; set; }

        public bool ContentIgnoreCasing { get; set; }

        public bool ContentWholeWordsOnly { get; set; }

        public bool ContentAsRegularExpression { get; set; }

        public bool ContentForOfficeXml { get; set; }

        #endregion

        #region Compare

        public bool CompareFileName { get; set; }

        public bool CompareSize { get; set; }

        public bool CompareContent { get; set; }

        #endregion
    }
}

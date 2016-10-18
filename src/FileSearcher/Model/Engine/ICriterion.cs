using System.IO;

namespace FileSearcher.Model.Engine
{
    public interface ICriterion
    {
        /// <summary>
        /// THe name of the filter criterion.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Value indicating the effort that the system needs to match the file.
        /// The higher the number, the later the criteria is tested.
        /// </summary>
        CriterionWeight Weight { get; }

        /// <summary>
        /// Indicates whether this criterion instance has support for directories.
        /// </summary>
        bool DirectorySupport { get; }
        
        /// <summary>
        /// Indicates whether this criterion instance has support for files.
        /// </summary>
        bool FileSupport { get; }

        /// <summary>
        /// Checks if the file or directory matches this criterion.
        /// </summary>
        /// <param name="fileSystemInfo">Entry of the file system.</param>
        /// <param name="context">Context of the current operation of all the criteria.</param>
        /// <returns></returns>
        bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context);

        /// <summary>
        /// Creates a new context for this criterion.
        /// </summary>
        /// <returns>New context for the matching of the files.</returns>
        ICriterionContext BuildContext();
    }
}

using System;
using System.IO;
using System.Xml;
using Ionic.Zip;

namespace FileSearcher.Model.Engine
{
    internal static class SearchExceptionFactory
    {
        public static SearchException Build(FileSystemInfo fileSystemInfo, Exception originalException)
        {
            if (originalException is PathTooLongException)
                return new SearchException(fileSystemInfo, originalException, "Path is too long.");

            if (originalException is IOException)
                return new SearchException(fileSystemInfo, originalException, "File is locked for reading.");

            if (originalException is UnauthorizedAccessException)
                return new SearchException(fileSystemInfo, originalException, "Insufficiënt permissions to read file or folder.");

            if (originalException is XmlException)
                return new SearchException(fileSystemInfo, originalException, "XML contains invalid characters.");

            if (originalException is ZipException)
                return new SearchException(fileSystemInfo, originalException, "Cannot process the ZIP file.");

            return new SearchException(fileSystemInfo, originalException, "Unknown unhandled exception.");
        }
    }
}

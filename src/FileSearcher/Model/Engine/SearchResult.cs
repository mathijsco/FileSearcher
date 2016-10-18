using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace FileSearcher.Model.Engine
{
    public class SearchResult
    {
        public SearchResult(FileSystemInfo fileSystemInfo)
        {
            this.FileSystemInfo = fileSystemInfo;
        }

        /// <summary>
        /// Gets the file or directory for this search result.
        /// </summary>
        public FileSystemInfo FileSystemInfo { get; private set; }

        /// <summary>
        /// Gets or sets the collection with all the metadata for this search result.
        /// The Type if the criterion which has set the context.
        /// </summary>
        public IDictionary<Type, ICriterionContext> Metadata { get; set; }
    }
}

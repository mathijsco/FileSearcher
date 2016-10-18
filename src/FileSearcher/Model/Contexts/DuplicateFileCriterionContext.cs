using FileSearcher.Model.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSearcher.Model.Contexts
{
    internal class DuplicateFileCriterionContext : ICriterionContext
    {
        public DuplicateFileCriterionContext(IList<FileSystemInfo> childs)
        {
            //this.Childs = new Collection<FileSystemInfo>();
            this.Childs = childs;
        }

        public IList<FileSystemInfo> Childs { get; private set; }
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FileSearcher.Model.Engine
{
    internal sealed class ZipCriterionContext : ICriterionContext
    {
        public ZipCriterionContext()
        {
            this.Childs = new Collection<string>();
        }

        public bool ArchiveNameIsMatch { get; set; }

        public IList<string> Childs { get; private set; }
    }
}

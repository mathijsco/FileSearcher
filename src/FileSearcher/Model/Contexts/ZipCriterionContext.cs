using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace FileSearcher.Model.Engine
{
    internal sealed class ZipCriterionContext : ICriterionContext
    {
        public ZipCriterionContext()
        {
            this.Childs = new Collection<string>();
        }

        public IList<string> Childs { get; private set; }
    }
}

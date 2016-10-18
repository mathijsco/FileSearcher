using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSearcher.Model.Engine
{
    public class CriterionBase
    {
        public virtual ICriterionContext BuildContext()
        {
            return null;
        }
    }

    public class CriterionBase<TContext> : CriterionBase where TContext : ICriterionContext, new()
    {
        public override ICriterionContext BuildContext()
        {
            return new TContext();
        }
    }
}

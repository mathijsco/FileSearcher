using System.Collections.Generic;
using FileSearcher.Model.Engine;

namespace FileSearcher.Model.CriterionSchemas
{
    internal interface IPostProcessingCriterion
    {
        IEnumerable<SearchResult> PostProcess();
    }
}

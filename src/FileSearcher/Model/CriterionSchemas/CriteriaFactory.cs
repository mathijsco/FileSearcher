using System;
using System.Collections.Generic;
using FileSearcher.Model.Engine;
using FileSearcher.Model.Entities;

namespace FileSearcher.Model.CriterionSchemas
{
    internal static class CriteriaFactory
    {
        public static IList<ICriterion> Build(EngineOptions options)
        {
            var list = new List<ICriterion>();

            // Apply basic options
            if (!string.IsNullOrEmpty(options.SearchName))
            {
                if (options.SearchInArchives)
                    list.Add(new NameAndZipCriterion(options.SearchName, options.SearchNameIgnoreCasing, options.SearchNameMatchFullPath));
                else if (!options.SearchNameAsRegularExpression)
                    list.Add(new NameCriterion(options.SearchName, options.SearchNameIgnoreCasing, options.SearchNameMatchFullPath));
                else
                    list.Add(new NameRegexCriterion(options.SearchName, options.SearchNameIgnoreCasing, options.SearchNameMatchFullPath));
            }

            // Add file attributes
            if (options.AttributesIncluded > 0 || options.AttributesExcluded > 0)
            {
                list.Add(new AttributeCriterion(options.AttributesIncluded, options.AttributesExcluded));
            }

            // Sizes
            if (options.MinimumSize != null || options.MaximumSize != null)
            {
                list.Add(new SizeCriterion(options.MinimumSize, options.MaximumSize));
            }

            // Dates
            if (options.DateOption != FileDateOption.None && (options.StartDateTime != null || options.EndDateTime != null))
            {
                list.Add(new DateCriterion(options.DateOption, options.StartDateTime, options.EndDateTime));
            }

            // Content
            if (!string.IsNullOrEmpty(options.ContentText))
            {
                if (!options.ContentAsRegularExpression)
                    list.Add(new ContentCriterion(options.ContentText, options.ContentIgnoreCasing, options.ContentWholeWordsOnly, options.ContentEncodingFactory));
                else
                    list.Add(new ContentRegexCriterion(options.ContentText, options.ContentIgnoreCasing));
            }

            // Duplicates
            if (options.CompareFileName || options.CompareSize || options.CompareContent)
            {
                list.Add(new DuplicateFileCriterion(options.CompareFileName, options.CompareSize, options.CompareContent));
            }

            return list.ToArray();
        }
    }
}

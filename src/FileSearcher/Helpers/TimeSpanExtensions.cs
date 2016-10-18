using System;
using System.Globalization;

namespace FileSearcher.Helpers
{
    public static class TimeSpanExtensions
    {
        public static string GetFriendlyNotation(this TimeSpan timeSpan)
        {
            if (timeSpan.Minutes > 2)
                return string.Format(CultureInfo.CurrentCulture, "{0:#,##0.0} minutes", timeSpan.TotalMinutes);
            return string.Format(CultureInfo.CurrentCulture, "{0:#,##0.00} seconds", timeSpan.TotalSeconds);
        }
    }
}

using System.Collections.Generic;

namespace Stringalyzer.Web.Models
{
    public class StringalyzerViewModel : IAnalyzer
    {
        public int TotalUniqueWords { get; set; }

        public int TotalWords { get; set; }

        public IEnumerable<KeyValuePair<string, int>> UniqueWordCounts { get; set; }

        public IEnumerable<string> UniqueWords { get; set; }
    }
}

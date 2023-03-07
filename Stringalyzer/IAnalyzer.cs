using System.Collections.Generic;

namespace Stringalyzer
{
    public interface IAnalyzer
    {
        int TotalUniqueWords { get; }
        int TotalWords { get; }
        IEnumerable<KeyValuePair<string, int>> UniqueWordCounts { get; }
        IEnumerable<string> UniqueWords { get; }
    }
}
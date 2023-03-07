using System;
using System.Collections.Generic;
using System.Linq;

namespace Stringalyzer
{
    public class Analyzer : IAnalyzer
    {
        private readonly string _input;
        private readonly string[] _inputTokens;
        private readonly char[] _delimiters = new char[] { ' ', ',', '.', '!', '?', '\n', '(', ')', ':', ';', };

        private int? _totalWords;
        public int TotalWords
        {
            get => CountAllWords();
            private set => _totalWords = value;
        }

        private int? _totalUniqueWords;
        public int TotalUniqueWords
        {
            get => CountUniqueWords();
            private set => _totalUniqueWords = value;
        }

        private IEnumerable<string> _uniqueWords;
        public IEnumerable<string> UniqueWords
        {
            get => GetUniqueWords();
            private set => _uniqueWords = value;
        }

        private IEnumerable<KeyValuePair<string, int>> _uniqueWordCounts;
        public IEnumerable<KeyValuePair<string, int>> UniqueWordCounts
        {
            get => GetUniqueWordCounts();
            private set => _uniqueWordCounts = value;
        }

        public Analyzer(string toAnalyze)
        {
            _input = toAnalyze;
            _inputTokens = _input.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        private int CountAllWords()
        {
            if (_totalWords == null)
            {
                _totalWords = _inputTokens.GetLength(0);
            }
            return (int)_totalWords;
        }

        private int CountUniqueWords()
        {
            if (_totalUniqueWords == null)
            {
                _totalUniqueWords = UniqueWords.Count();
            }
            return (int)_totalUniqueWords;
        }

        private IEnumerable<string> GetUniqueWords()
        {
            if (_uniqueWords == null)
            {
                _uniqueWords = _inputTokens.Distinct();
            }
            return _uniqueWords;
        }

        private IEnumerable<KeyValuePair<string, int>> GetUniqueWordCounts()
        {
            if (_uniqueWordCounts == null)
            {
                _uniqueWordCounts = from w in _inputTokens
                                    group w by w into gw
                                    orderby gw.Key
                                    select new KeyValuePair<string, int>(gw.Key, gw.Count());
            }
            return _uniqueWordCounts;
        }
    }
}

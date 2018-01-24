using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioinformaticsAlgorithms
{
    public class StringTaskSolver : ITasksSolver
    {
        public int PatternCount(string text, string pattern)
        {
            return PatternMatching(pattern, text).Count();
        }

        public IEnumerable<string> FrequentWords(string text, int k)
        {
            int maxAmount = 0;
            var frequentWords = new HashSet<string>();
            for (int i = 0; i <= (text.Length - k); ++i)
            {
                string pattern = text.Substring(i, k);
                int amount = PatternCount(text, pattern);
                if (amount > maxAmount)
                {
                    maxAmount = amount;
                    frequentWords.Clear();
                }
                if (amount == maxAmount)
                {
                    frequentWords.Add(pattern);
                }
            }
            return frequentWords;
        }

        private IEnumerable<string> FrequentWords(string text, int k, int minAmount)
        {
            var frequentWords = new HashSet<string>();
            for (int i = 0; i <= (text.Length - k); ++i)
            {
                string pattern = text.Substring(i, k);
                int amount = PatternCount(text, pattern);
                if (amount >= minAmount)
                {
                    frequentWords.Add(pattern);
                }
            }
            return frequentWords;
        }

        public string ReverseComplement(string pattern)
        {
            var sb = new StringBuilder(pattern);
            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] = DnaChar.Flip(sb[i]);
            }
            char[] arr = sb.ToString().ToArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public IEnumerable<int> PatternMatching(string pattern, string genome)
        {
            for (int i = 0; i <= (genome.Length - pattern.Length); ++i)
            {
                if (genome.Substring(i, pattern.Length) == pattern)
                {
                    yield return i;
                }
            }
        }

        public IEnumerable<string> ClumpFinding(string genome, int k, int windowLength, int minAmount)
        {
            var clumps = new HashSet<string>();
            for (int i = 0; i <= (genome.Length - windowLength); ++i)
            {
                string window = genome.Substring(i, windowLength);
                IEnumerable<string> currentClumps = FrequentWords(window, k, minAmount);
                foreach (string clump in currentClumps)
                {
                    clumps.Add(clump);
                }
            }
            return clumps;
        }
    }
}

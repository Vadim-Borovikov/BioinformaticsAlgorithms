using System.Collections.Generic;
using System.Linq;

namespace BioinformaticsAlgorithms
{
    public class StringTaskSolver : ITasksSolver
    {
        public int PatternCount(string text, string pattern)
        {
            int result = 0;
            for (int i = 0; i <= (text.Length - pattern.Length); ++i)
            {
                if (text.Substring(i, pattern.Length) == pattern)
                {
                    ++result;
                }
            }
            return result;
        }

        public IEnumerable<string> FrequentWords(string text, int k)
        {
            var amounts = new int[text.Length - k + 1];
            for (int i = 0; i <= (text.Length - k); ++i)
            {
                string pattern = text.Substring(i, k);
                amounts[i] = PatternCount(text, pattern);
            }
            int maxAmount = amounts.Max();

            var frequentWords = new HashSet<string>();
            for (int i = 0; i <= (text.Length - k); ++i)
            {
                if (amounts[i] == maxAmount)
                {
                    frequentWords.Add(text.Substring(i, k));
                }
            }
            return frequentWords;
        }
    }
}

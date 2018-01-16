using System.Collections.Generic;
using System.Linq;

namespace BioinformaticsAlgorithms
{
    public class DnaStringTaskSolver : ITasksSolver
    {
        public int PatternCount(string text, string pattern)
        {
            var dnaText = new DnaString(text);
            var dnaPattern = new DnaString(pattern);
            return dnaText.PatternCount(dnaPattern);
        }

        public IEnumerable<string> FrequentWords(string text, int k)
        {
            var dnaText = new DnaString(text);
            IEnumerable<DnaString> words = dnaText.FrequentWords(k);
            return words.Select(w => w.ToString());
        }

        public string ReverseComplement(string pattern)
        {
            var dnaPattern = new DnaString(pattern);
            DnaString dnaReverseComplement = dnaPattern.GetReverseComplement();
            return dnaReverseComplement.ToString();
        }

        public IEnumerable<int> PatternMatching(string pattern, string genome)
        {
            var dnaPattern = new DnaString(pattern);
            var dnagGenome = new DnaString(genome);
            return dnagGenome.PatternMatching(dnaPattern);
        }
    }
}

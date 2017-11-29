using System;
using System.Collections.Generic;
using System.Linq;

namespace BioinformaticsAlgorithms
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            string text = "GCGCG";
            const string Pattern = "GCG";
            int patternCount = PatternCount(text, Pattern);
            Console.WriteLine($"PatternCount: {patternCount}");

            text = "CAAGGCAGACAAGGCAGAGTGGCAACGCAAGGCAGACAAGGCAGAGGGGGTAACTACTCCGACCATTTTTGTGGCAACGGGGGGTAACGGGGGTAACTACTCCGATACTCCGATACTCCGACCATTTTTGGGGGTAACCCATTTTTGTGGCAACGCCATTTTTTACTCCGAGTGGCAACGCAAGGCAGACAAGGCAGATACTCCGACCATTTTTGTGGCAACGCCATTTTTCAAGGCAGAGGGGGTAACCCATTTTTTACTCCGAGTGGCAACGGGGGGTAACCCATTTTTCAAGGCAGAGTGGCAACGGGGGGTAACGGGGGTAACCAAGGCAGAGGGGGTAACGGGGGTAACCAAGGCAGACCATTTTTGTGGCAACGTACTCCGACAAGGCAGAGTGGCAACGCCATTTTTCAAGGCAGAGTGGCAACGGTGGCAACGCAAGGCAGACAAGGCAGACCATTTTTGGGGGTAACCCATTTTTCCATTTTTCAAGGCAGAGGGGGTAACGGGGGTAACCAAGGCAGAGGGGGTAACGTGGCAACGCAAGGCAGACAAGGCAGATACTCCGAGTGGCAACGTACTCCGATACTCCGATACTCCGATACTCCGACCATTTTTCAAGGCAGATACTCCGACAAGGCAGAGTGGCAACGGTGGCAACGGGGGGTAACGGGGGTAACCAAGGCAGATACTCCGACCATTTTTGTGGCAACGGTGGCAACGGTGGCAACGTACTCCGAGGGGGTAACTACTCCGACCATTTTTGGGGGTAACCAAGGCAGATACTCCGAGTGGCAACGCAAGGCAGACCATTTTTGGGGGTAACCAAGGCAGAGTGGCAACGTACTCCGAGGGGGTAACGGGGGTAACCAAGGCAGA";
            const int K = 13;
            IEnumerable<string> words = FrequentWords(text, K);
            Console.WriteLine($"FrequentWords: {string.Join(", ", words)}");
        }

        public static int PatternCount(string text, string pattern)
        {
            var dnaText = new DnaString(text);
            var dnaPattern = new DnaString(pattern);
            return dnaText.PatternCount(dnaPattern);
        }

        public static IEnumerable<string> FrequentWords(string text, int k)
        {
            var dnaText = new DnaString(text);
            IEnumerable<DnaString> words = dnaText.FrequentWords(k);
            return words.Select(w => w.ToString());
        }
    }
}

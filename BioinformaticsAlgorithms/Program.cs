using System;
using System.Collections.Generic;
using System.IO;

namespace BioinformaticsAlgorithms
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            ITasksSolver solver = new DnaStringTaskSolver();

            string text = "GCGCG";
            string pattern = "GCG";
            int patternCount = solver.PatternCount(text, pattern);
            Console.WriteLine($"PatternCount of {pattern} in {text}: {patternCount}");

            text = "ACGTTGCATGTCGCATGATGCATGAGAGCT";
            const int K = 4;
            IEnumerable<string> words = solver.FrequentWords(text, K);
            Console.WriteLine($"FrequentWords of {K} in {text}: {string.Join(", ", words)}");

            pattern = "ACACAC";
            string reverseComplement = solver.ReverseComplement(pattern);
            Console.WriteLine($"ReverseComplement of {pattern}: {reverseComplement}");

            text = "ATATATA";
            pattern = "ATA";
            IEnumerable<int> matches = solver.PatternMatching(pattern, text);
            Console.WriteLine($"PatternMatching of {pattern} in {text}: {string.Join(", ", matches)}");

            text = File.ReadAllText("VibrioCholerae.txt");
            pattern = "CTTGATCAT";
            matches = solver.PatternMatching(pattern, text);
            File.WriteAllText("VibrioCholerae.result.txt", string.Join(" ", matches));
        }
    }
}

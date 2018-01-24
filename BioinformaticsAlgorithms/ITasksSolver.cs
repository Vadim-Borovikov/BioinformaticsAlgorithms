using System.Collections.Generic;

namespace BioinformaticsAlgorithms
{
    public interface ITasksSolver
    {
        int PatternCount(string text, string pattern);
        IEnumerable<string> FrequentWords(string text, int k);
        string ReverseComplement(string pattern);
        IEnumerable<int> PatternMatching(string pattern, string genome);
        IEnumerable<string> ClumpFinding(string genome, int k, int windowLength, int times);
    }
}

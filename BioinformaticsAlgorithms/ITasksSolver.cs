using System.Collections.Generic;

namespace BioinformaticsAlgorithms
{
    public interface ITasksSolver
    {
        int PatternCount(string text, string pattern);
        IEnumerable<string> FrequentWords(string text, int k);
    }
}

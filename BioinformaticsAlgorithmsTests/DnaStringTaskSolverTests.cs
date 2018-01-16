using BioinformaticsAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BioinformaticsAlgorithmsTests
{
    [TestClass]
    public class DnaStringTaskSolverTests
    {
        [TestMethod]
        public void PatternCountTestDna()
        {
            var solver = new DnaStringTaskSolver();
            var tests = new SolversTests(solver);
            tests.PatternCountTest();
        }

        [TestMethod]
        public void FrequentWordsTestDna()
        {
            var solver = new DnaStringTaskSolver();
            var tests = new SolversTests(solver);
            tests.FrequentWordsTest();
        }

        [TestMethod]
        public void ReverseComplementTestDna()
        {
            var solver = new DnaStringTaskSolver();
            var tests = new SolversTests(solver);
            tests.ReverseComplementTest();
        }
    }
}
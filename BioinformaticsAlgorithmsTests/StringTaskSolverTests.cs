﻿using BioinformaticsAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BioinformaticsAlgorithmsTests
{
    [TestClass]
    public class StringTaskSolverTests
    {
        [TestMethod]
        public void PatternCountTest()
        {
            var solver = new StringTaskSolver();
            var tests = new SolversTests(solver);
            tests.PatternCountTest();
        }

        [TestMethod]
        public void FrequentWordsTest()
        {
            var solver = new StringTaskSolver();
            var tests = new SolversTests(solver);
            tests.FrequentWordsTest();
        }

        [TestMethod]
        public void ReverseComplementTest()
        {
            var solver = new StringTaskSolver();
            var tests = new SolversTests(solver);
            tests.ReverseComplementTest();
        }

        [TestMethod]
        public void PatternMatchingTest()
        {
            var solver = new StringTaskSolver();
            var tests = new SolversTests(solver);
            tests.PatternMatchingTest();
        }

        [TestMethod]
        public void ClumpFindingTest()
        {
            var solver = new StringTaskSolver();
            var tests = new SolversTests(solver);
            tests.ClumpFindingTest();
        }
    }
}
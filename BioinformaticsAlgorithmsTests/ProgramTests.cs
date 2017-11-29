﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BioinformaticsAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BioinformaticsAlgorithmsTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void PatternCountTest()
        {
            PatternCountTest("GCGCG", "GCG", 2);
            PatternCountTest("ACGTACGTACGT", "CG", 3);
            PatternCountTest("GGACTTACTGACGTACG", "ACT", 2);
            PatternCountTest("ATCCGATCCCATGCCCATG", "CC", 5);
            PatternCountTest("AGCGTGCCGAAATATGCCGCCAGACCTGCTGCGGTGGCCTCGCCGACTTCACGGATGCCAAGTGCATAGAGGAAGCGAGCAAAGGTGGTTTCTTTCGCTTTATCCAGCGCGTTAACCACGTTCTGTGCCGACTTT", "TTT", 4);
            PatternCountTest("AAAGAGTGTCTGATAGCAGCTTCTGAACTGGTTACCTGCCGTGAGTAAATTAAATTTTATTGACTTAGGTCACTAAATACTTTAACCAATATAGGCATAGCGCACAGACAGATAATAATTACAGAGTACACAACATCCAT", "AAA", 4);
            PatternCountTest("CTGTTTTTGATCCATGATATGTTATCTCTCCGTCATCAGAAGAACAGTGACGGATCGCCCTCTCTCTTGGTCAGGCGACCGTTTGCCATAATGCCCATGCTTTCCAGCCAGCTCTCAAACTCCGGTGACTCGCGCAGGTTGAGTA", "CTC", 9);
            PatternCountTest("TAACAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTGAGCCTTTGAGCCTTTTAGCCTTTCAGCCTTTAGCCTTTAAGCCTTTCCGCATCGAGCCTTTCAGCCTTTCGTAGCCTTTCGAGCCTTTAGCCTTTCAGCCTTTAGAGCCTTTAAGCCTTTAGTCGATGTAGCCTTTAGCCTTTAGCCTTTAGCCTTTGCAGCCTTTAGTAGGCAAGCCTTTTAGCCTTTGAGCCTTTCGAGCCTTTCTCGCTAGCCTTTAGCCTTTGGTGAGCCTTTTAGCCTTTAGCCTTTTCGCAGCCTTTTGAGCCTTTCTTGTTTGAATGGCAAGAGCCTTTTCGAGCCTTTAGCCTTTGAGCCTTTCAGCCTTTAAAAGCCTTTCGTTAGCCTTTAGCCTTTATCGAGCCTTTAAGCCTTTTATGCAAAGCCTTTGAGCCTTTAGCCTTTCAGCCTTTCAGCCTTTCATTGACAAGCCTTTCAGCCTTTAGCCTTTAGCCTTTCTCAGCCTTTGAGCCTTTGAGCCTTTGTCGAGCCTTTTTTCAGAGCCTTTTAGCCTTTAGCCTTTGAGCCTTTAGCCTTTAGCCTTTTACGAGCCTTTGCAAGCCTTTCAGCCTTTCCAAGCCTTTAGCCTTTGCTTTAGCCTTTCATGGGATAGCCTTTAGCCTTTATTAAGCCTTTTTTATCAAGCCTTTGTAGCCTTTAAGCCTTTCCAGCCTTTAGGAGCCTTTGTATAGCCTTTTGAGCCTTTCTACAGTAAAGCCTTTTTTGGTCAGCCTTTCTAGCCTTTGATAGCCTTTCTGAAGCCTTTGGCGGAGCCTTTCTGTTAACAGCCCAGCCTTTCTCATAGCCTTTGCGGTATCAGCCTTTGCAGCCTTTCTGGAGCGATAGCCTTTCAGCCTTTCCGAGCCTTTTTCAGAGCCTTTGAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTCCGAGCCTTTTCAGCCTTTACAGCCTTTTTAGCCTTTGAGCCTTTCACAGCCTTTGAGCTAGCCTTTAAGTTAAAGCCTTTAGCCTTTCAGCCTTTACATTAGCCTTTTAGCCTTTTCAGCCTTTAGAGCCTTTAGCCTTTGCTGAAGCCTTTAGTAGCCTTTAGCCTTTGCGAAGCCTTTCTGGTGCAACAAGTGAAGCCTTTGCCCTAGCCTTTGCTAGCCTTTCCGAGCCTTTGTCGATATAGCCTTTAGCCTTTAGAAAGCCTTTAGCCTTTGCTAGCCTTTATAGCCTTTAGCCTTTAGCCTTTCCCAGCCTTTAGCCTTTATCCTAAGCCTTTAGCCTTTTCCAGAAGCAGCCTTTTGATCAGAGCCTTTCTTCGGACTGCTCCCAGCCTTTAGCCTTTCAGCCTTTAGCCTTTAGCCTTTCAGCCTTTAGCCTTTTCTAGCCTTTAGCCTTTGTGTAGCCTTTCTAGCCTTTACGAGCCTTTGCCCAGCCTTTCCCAGCCTTTGAGAGCCTTTACCATATAGCCTTTACATAAGCCTTTGATGAGCCTTTAGCCTTTCGAGCCTTTCAGCCTTTACTCCAGCCTTTATAGCCTTTATATAGCCTTTCCTGTTAGGCCGTCGGTGCAGCCTTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTTAGCCTTTCAGCCTTTGCTAGCCTTTCCAGCCTTTACAGCCTTTTACCGAGCCTTTCCATCAGCCTTTAGCCTTTATATCTCTGATCGGGTAGCCTTTCGGCTAGCCTTTGGTAGCCTTTTTCAGCCTTTATGTAAAGCCTTTGTAGCCTTTGATGTGAGCCTTTAGAAGCCTTTGTCAGCCTTTTAGCCTTTAGCCTTTAGCCTTTTTAAGCCTTTTACAAGCCTTTACTCAGAGCCTTTACGAGCCTTTTAGCCTTTGCAGCCTTTTAGCCTTTTGATGAGCCTTTGCGGAGCCTTTTCTTTCAGCCTTTTGGCAGCCTTTAGCCTTTGTACAGCCTTTTTGAGCACAGCCTTTCGCGAAAGAGCCTTTATCAGCCTTTAAGCCTTTGCTAGCCTTTAGCCTTTTGAGCCTTTAGCCTTTGTATCTGTCTATCATCGAGCCTTTCTAAGCCTTTGCGGAAGCCTTTAGCCTTTGTCAGCCTTTCAAAGCCTTTAGCCTTTTATTCAAGCCTTTGAACCATAGCCTTTGGCAGCCTTTCAAGCCTTTGACGACAGCCTTTAGCCTTTCATTAGCCTTTTAGGAGGCTCATCCGTCTAGCCTTTAAATAGCCTTTAGCCTTTATAGCCTTTAAGCCTTTAGCCTTTTAAGCCTTTGAGAGCCTTTAAAGCCTTTAAACCAAGCCTTTGCGAAGCCTTTAGCCTTTAGCCTTTCGCAGCCTTTAGCCTTTCGAGCCTTTTGTAGCCTTTTGGAGAGCCTTTGGGCAAGCCTTTAGTATAAGCCTTTAGCCTTTTAGCCTTTCAAGCCTTTAGCCTTTAAGCCTTTGGCACAGCCTTTTGAGCCTTTCAGGAGCCTTTATTGGTGAGCCTTTAGTATAGCCTTTTCAGCCTTTGGCAGCCTTTAATGAAAGCCTTTGCTCAGCCTTTTTCAGCCTTTACAGCCTTTCAAGCCTTTAGCCACAAGCCTTTAGCCTTTAGCCTTTCAGCCTTTGCGAGCCTTTGTAGCCTTTAAGCCTTTCAGCCTTTAGCCTTTAGCCTTTTTCAAGCCTTTTCAGCCTTTCAAAGCCTTTCAAGCCTTTGAAGCCTTTCTAAGCCTTTGAGCCTTTGAGCCTTTGAGCCTTTAGCCTTTGTTCCTAGCCTTTATAGCCTTTTAGGCAGCCTTTCAGAGCCTTTTAAGCCTTTAGCCTTTCAGAAAGAGCCTTTAGCCCAGCCTTTTGATTAGCCTTTAGGGAACAGCCTTTAGCCTTTTAAGCCTTTGGTATACAATCAACGCAGCCTTTAGCCTTTAAGCCTTTTGGAGCCTTTCAGACTGATCCCAGCCTTTCAGCCTTTCTCAGCCTTTAAGCCTTTCTCCAAGCCTTTTGAGCCTTTTCGAGCCTTTAGTGAGCCTTTTGAAGCCTTTGTTTAGCCTTTTGTATAGGGTAGCCTTTAGCCTTTCCGGAAGCCTTTTGTAGCCTTTAAGCCTTTTGTCCGGGAAAGCCTTTGTAAGCCTTTAATGCAGCCTTTCCTATAGCCTTTAAGCCTTTCAGCCTTTTGGAGCCTTTTCTCAGCCTTTAGCCTTTCGCCAGCCTTTCTCCCGAGCAGCCTTTTAGAAAAAGCCTTTTAGCCTTTTACCGTGGACAGCCTTTCACGAGCCTTTACAGGCTAGCCTTTAGCCTTTGCTAGCCTTTTCCCAGCCTTTTGAGCCTTTAAGCCTTTCTAAGTTCTACGCTTGGGCTAAAGCCTTTAGCCTTTAAGCCTTTCAGCCTTTTGCAGCCTTTATATAACTTGAGCCTTTAGCCTTTAGCCTTTATAGCCTTTAGCCTTTTAGCCTTTTATATCCCTTAAGCCTTTGTAAGCCTTTAGCCTTTAAGCCTTTACGAGGAAAGCCTTTCATGCAGCCTTTAGCCTTTAGCCTTTGAGCCTTTCCAGCCTTTCAGCCTTTCAGCCTTTAGCCTTTAGCCTTTAGCCTTTTAGCCTTTATGAGCCTTTATAGCCTTTAGCCTTTTCACCAGCCTTTCCAGATGCACAAGCCTTTCAGCCTTTAGCCTTTCGAGCCTTTGGCTTATAGCCTTTCATCAGCCTTTCTAGCCTTTTAGCCTTTAGCCTTTAGCCTTTTCTAGCCTTTCAGCCTTTAGCCTTTTCGAAGCCTTTAGCCTTTTTAGCCTTTAGCTCAGCCTTTAGCCTTTATCTAACAGCCTTTAGCCTTTAGCCTTTAAAGCCTTTATGTCCAATTCTAACAGCCTTTAGCCTTTAAAGCCTTTGCAGCCTTTGAGCCTTTTAGCCTTTGAAGCCTTTAGCCTTTGTCAGCCTTTCCAGCCTTTTAGCCTTTAGCAGCCTTTAGTACGCCAGCCTTTAGCCTTTGTATAAGCCTTTAGCCTTTAGCCTTTCCACTAGCCTTTAGCCTTTAGAGGAGCGATAGCCTTTCAGCCTTTAGAAAGCCTTTGTTGCTGCTAGCCTTTGGGTTCTCAGCCTTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTTGTAGCCTTTTACATAGGATTGATTCAAAAGCCTTTTTGAGCCTTTCTGCATTAGCCTTTTCCTCTAGCCTTTAGCCTTTCGCAGCCTTTAGCCTTTTAGAGCCTTTAGATAGCCTTTCGCGACAGCCTTTTGTTTAGCCTTTAGCCTTTGTTAGCCTTTGAGCCTTTGAGCCTTTTAGCCTTTCCTAGCCTTTCAGCCTTTCCAAAGCCTTTGACAGGGTGTAGCCTTTCTAGCCTTTTTAGCCTTTAGCCTTTAAACTTAAGCCTTTTTAGCCTTTAGCCTTTCAACCCAGCCTTTAGCCTTTTAAGCCTTTAGCCTTTAGCCTTTTTAGAAGCCTTTTAGCCTTTAGCCTTTGGAGCCTTTCAGATCTCAGCCTTTTCGAGCCTTTTAGCCTTTTCAGAAAAGTAGCCTTTTTAGCAGCCTTTTAAAGCCTTTGGAGCCTTTAGCCTTTAGCCTTTGTAGCCTTTTCCCAAAAGCCTTTACAGCCTTTGTGAGCCTTTTAGTTCGTTTGAGCCTTTCCAGCCTTTCAGCCTTTAGCCTTTATAGCCTTTTGCGAGAAGCCTTTAAGCCTTTAGCCTTTTGACGTTCTAGAGCCTTTGGAGCCTTTCACGCGAGCCTTTCAAGCCTTTGACTCCGCAGCCTTTTCGCGACCAGCCTTTGCCGTGCCAGCCTTTAGCCTTTCAACACAGCCTTTAGCCTTTGGGCCGCAGAGCCTTTGAGTAGCCTTTAGCCTTTGACAGCCTTTAGCCTTTCTAGCCTTTGCAGCCTTTGTCTAGGTAGCCTTTAGCCTTTAGCCTTTCTAGCCTTTTAGCCTTTAGCCTTTTGAGCCTTTTGGAAGCCTTTCAGCCTTTAGCCTTTCGCGAGCCTTTGAGCCTTTACCCAGCCTTTACGGAGCCTTTAGCCTTTCCCATAGCCTTTAGCCTTTCCAGCCTTTAGCCTTTTAGCCTTTCAAATCTAAGCCTTTCGCATATATGGTAGCCTTTAGCCTTTAGCCTTTATGGTCCTTCAGTTTGAGCCTTTTAGAGCCTTTAAAGGAGCCTTTGTAAGACGAAGGTAGCCTTTAGCCTTTGCCAGCCTTTTTAGCCTTTAGCCTTTAAAAAGCCTTTGAGCCTTTAGCCTTTAGCCTTTGAGCCTTTAGCCTTTTCTCCTAGCCTTTCATAGCCTTTGAGCCTTTAGCCTTTTAGCCTTTTAGCCTTTAGCCTTTAGCCTTTGGAGGTCAGCCTTTATGTTAAAGCCTTTAGTTCCCAGCCTTTCAGCCTTTAGCCTTTAGCCTTTGAGCCTTTCAGCCTTTTAGCCTTTCAGCCTTTCAGCCTTTGAAGCCTTTTGTAGCCTTTGCCCGAGCCTTTAGCCTTTAGCCTTTCCCAACCCTGATCCGTAGCCTTTGGGCTGATCCTGAGCCTTTTCAGCCTTTAAGCCTTTAGCCTTTAGCCTTTGAGAAGCCTTTAGCCTTTCAGCCTTTAACAGCCTTTAAGCCTTTATAGCCTTTAGCCAGCCTTTGCAGCCTTTCAGTAGCCTTTAGCCTTTAGCCTTTCTAGCCTTTCTTGGAGCCTTTCCCAGCCTTTAAGAGCCTTTAGCCTTTTAGCCTTTCAGCCTTTAGCCTTTTCGTAGCCTTTGACCATTGTCAGCCTTTCTACTGAGCCTTTCATAGCCTTTTTTAGCCTTTCTAGCAGCCTTTGGAGCCTTTAGAAGAGCCTTTAGCCTTTTAAGCCTTTGAGCCTTTAACACAAGCCTTTATCTGGGCCGCGAGCCTTTTCAACCTAACTACAGCCTTTCTAAGCCTTTAGCCTTTAGCCTTTCAGCCTTTTAGCCTTTACCGAGCCTTTGCGGGAAGCCTTTAAAGAGCCTTTAGAAAAAGCCTTTGGGATAGCCTTTCCAGCCTTTCCAGCCTTTTTAGCCTTTTCCTCAAGATTTAGCCTTTGATGAAGCCTTTGAGCCTTTAGCCTTTCATTGAGCCTTTTAAGCCTTTCAGCCTTTTCTCATCAGCCTTTCACAGCCTTTCTACAGCCTTTAGCCTTTAGCCTTTGGAGCCTTTTCGCCCCGAGCCTTTAGCCTTTAGCCTTTTAGCCTTTCAGCCTTTGTAGCCTTTAGAGCCTTTGCTTAGCCTTTAGCCTTTAGTAGCCTTTAGATAGCCTTTTCTGGGAGCCTTTACAGCCTTTAGCCTTTAGCCTTTAGCCTTTTAAAGCCTTTCCCCAAAGCCTTTGTTGAGCCTTTAGCCTTTACAGTCTAGCCTTTAGCCTTTCAAGCCTTTACCTTAGCCTTTGGCAGCCTTTCTAGCCTTTAGCCTTTTCAGCCTTTAGCCTTTAAGCCTTTAGCCTTTTCGAGCCTTTGAGCCTTTAAGCCTTTATAAAAAGCCTTTAGCCTTTAAGCCTTTACCAGCCTTTAGCCTTTCAGCCTTTTATCGGAAAGCCTTTAAGCCTTTTAGCCTTTCAGCCTTTGAGCCTTTCAGCCTTTAGCCTTTGGCAAAGCCTTTTTGCAGCCTTTGGAAGCCTTTAGCCTTTTTCAAGCCTTTCAGCCTTTAGCCTTTGCACGTATTAGGAAGCCTTTTACTCTAAGCCTTTATCAGCCTTTAGCCTTTAGCCTTTAAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTAGCCTTTACGGTCAGCCTTTGGTAGCCTTTTCAGCCTTTAAGCCTTTAAGCCTTTGAGCCTTTAGCCTTTAGCCTTTGAGCCTTTAAGAGCCTTTCAGCCTTTTTTAGCCTTTTAGCCTTTGAGCCTTTCCTAGCCTTTCAAGCCTTTGAGCCTTTCGAAGCCTTTTAGCCTTTAGCCTTTAGCCTTTATGGAGCCTTTAGCCTTTAGCGGAGCCTTTGAGCCTTTACAGAGCCTTTAGCCTTTAGCCTTTTAAGCCTTTTGCAGCCTTTCAAAGAGCCTTTAGCCTTTACGGAGCCTTTAGCCTTTAAGCCTTTCTCACTAGCCTTTTTAGCCTTTGAGCCTTTATGACGAAGCCTTTAGCCTTTTGTCGTGACCTGAGCCTTTAGCCTTTACAGCCTTTCAGCCTTTAGCCTTTCTTAAAAGCCTTTTAGCCTTTTTGAGCCTTTACAGCCTTTCGAGCCTTTGAGCCTTTCCCAGCCTTTGAAGCCTTTTGGACAGAGCCTTTGCTAGCCTTTAGCCTTTTAGCCTTTAGCCTTTAGCCTTTACTTAGCCTTTTAGCCTTTATGGATAGCCTTTAGCCTTTGAGAGCCTTTGCCTAGCCTTTGAAGCCTTTTTAGCCTTTAACGAGCCTTTAGCCTTTAGCCTTTAGCCTTTAAGCCTTTAGCCTTTCGAGCCTTTCTCAGCCTTTGTAGCCTTTAGCCTTTAGAGCAGCCTTTAGCCTTTCCAGCCTTTAGCCTTTTCAGCCTTTAGCCTTTCAGCCTTTGCCCCGAGCACGTAGCCTTTACAGCCTTTAGCCTTTAGCCTTTTAGCCTTTACAGCCTTTTGAGCCTTTAGCCTTTGAAAGCCTTTTGAAGAGCCTTTCAGCCTTTCTTACTAGCCTTTGCAGCCTTTTAGCCTTTCCGAGCCTTTGATAGCCTTTGTCGGTAAGCCTTTGTAGAGCCTTTAGCCTTTAAGCCTTTGGTAAAGAGCCTTTTCAACAGCCTTTCGGAGCCTTTCGCTACAAGCCTTTTGGCCTAGCCTTTAGCCTTTCAGCCTTTCAAGAGCCTTTAGCCTTTCGCAGCCTTTATAGCCTTTCAGCCTTTCAGCCTTTAGCCTTTAGAGCCTTTGAGCCTTTCGTTATCTAAGCCTTTACTCCATAGCCTTTGAGCCTTTAGCCTTTGTCAGTCGAGCCTTTGTTCTTGAGCCTTTAGCCTTTGCAGCCTTTAGCCTTTTGTTTGTGGAGCCTTTAGCCTTTGAATACAGCCTTTAGCCTTTAGCCTTTAGCCTTTCTAGCCTTTCAGCAGCCTTTGTAGCCTTTGAACCAGCCTTTAGCCTTTTAGCCTTTTCCTTAGCCTTTCCAGCCTTTTAGTGAGCCTTTAGCCTTTGCACCAGCCTTTAGCCTTTAGCCTTTCAGCCTTTAGCCTTTCGAGCCTTTTAGCCTTTGAACAGCCTTTTGAGCCTTTGACGATATGAGCCTTTAGCCTTTTGTAGCCTTTTTTAGCCTTTGAACAGCCTTTGGAGTCAAGCCTTTACGCAGCCTTTCCAGCCTTTCAGCCTTTAGCCTTTGGTCAGCCTTTTCAGAGCCTTTGCGGTTAGCCTTTGAATAGCCTTTAAAGCCTTTCTCAGCCTTTGTAAGCCTTTAGCCTTTTAGCCTTTGTGAGCCTTTCAGCCTTTCCGAGCCTTTAGCCTTTGCCTACGGAAGCCTTTAGCCTTTGCTATCAGCTTGAGCCTTTTAGCCTTTAGTAGCAGCCTTTTAGCCTTTTAGCCTTTCAGCCTTTCTCTAGCCTTTAGCCTTTATCCGAGCCTTTACCAGCCTTTGAGCCTTTAGCCTTTATAGCCTTTATACGTAGCTAGCCTTTAGCCTTTAGAGCCTTTACCCTGTACCAGCCTTTAAGCCTTTCTCGTGAAGCCTTTAGCCTTTGAGCCTTTCGAGCCTTTAGCCTTTAGCCTTTAAGCCTTTTTGTGTGAGCCTTTAGCCTTTGGGGAGCCTTTAGCCTTTCAGCCTTTTAGCCTTTTCAAGCCTTTAGCCTTTAGCCTTTTGAGCCTTTAAAGCCTTTAGCCTTTAGGTAGCAAGCCTTTCGTTATAGCCTTTTATAAGCCTTTTTTAATGAGCCTTTAGCCTTTAGCCTTTGAGCAGCCTTTAGCCTTTAGTAGCCTTTTGATATTAGCCTTTCAGCCTTTAGCCTTTCCCCGAGCCTTTGTTAGAGCCTTTGCAGCCTTTGGAGCCTTTAGCCTTTCGGAGCCTTTAGCCTTTGGGACAGCCTTTAGCCTTTAGCCTTTGAAGCCTTTTGCAGCCTTTAAGATAGCCTTTGAGCCTTTTCAGCCTTTACAGCCTTTAAGCCTTTAGCCTTTGAGCCTTTGAGCCTTTTGAGCCTTTTAGCCTTTGTTGCAGCCTTTAGCCTTTAGCCTTTTAGCCTTTAGCCTTTAGCCTTTGAGCCTTTGAGCCTTTTAGCCTTTAGCCTTTGAGCCTTTTGGACAGCCTTTCTGAGCCTTTCGTAGCCTTTACCGCAAGCCTTTATAGCCTTTGAAGAGGAGCCTTTATAGCCTTTCAGAAGCCTTTTAAGCCTTTTCGCAGCCTTTTATCAGCCTTTAGCCTTTAGCCTTTTAGCCTTTCAGCCTTTAGCCTTTACAAGCCTTTAGCCTTTAGCCTTTATCAAGCCTTTCTAGCCTTTGAGCCTTTGTGAGCCTTTGTGTCAGCCTTTCAAGCCTTTTTAAGTACAGCCTTTACTCAGCCTTTATAGCCTTTGTCGTAAGCCTTTAGCCTTTAGCCTTTGAAAAGCCTTTACGCACAGACAAGTAGCCTTTCAGCCTTTAAGCCTTTGAGTATGTCCTTGAGCCTTTAAAAGAGCCTTTGGTAGCCTTTAGCCTTTAGCCTTTTATAGCCTTTAAGCCTTTAAGCCTTT", "AGCCTTTAG", 294);
        }

        [TestMethod]
        public void FrequentWordsTest()
        {
            FrequentWordsTest("ACTGACTCCCACCCC", 3, "CCC");
            FrequentWordsTest("ACGTTGCATGTCGCATGATGCATGAGAGCT", 4, new[] { "CATG", "GCAT" });
            FrequentWordsTest("CAGTGGCAGATGACATTTTGCTGGTCGACTGGTTACAACAACGCCTGGGGCTTTTGAGCAACGAGACTTTTCAATGTTGCACCGTTTGCTGCATGATATTGAAAACAATATCACCAAATAAATAACGCCTTAGTAAGTAGCTTTT", 4, "TTTT");
            FrequentWordsTest("TGGTAGCGACGTTGGTCCCGCCGCTTGAGAATCTGGATGAACATAAGCTCCCACTTGGCTTATTCAGAGAACTGGTCAACACTTGTCTCTCCCAGCCAGGTCTGACCACCGGGCAACTTTTAGAGCACTATCGTGGTACAAATAATGCTGCCAC", 3, "TGG");
            FrequentWordsTest("CCAGCGGGGGTTGATGCTCTGGGGGTCACAAGATTGCATTTTTATGGGGTTGCAAAAATGTTTTTTACGGCAGATTCATTTAAAATGCCCACTGGCTGGAGACATAGCCCGGATGCGCGTCTTTTACAACGTATTGCGGGGTAAAATCGTAGATGTTTTAAAATAGGCGTAAC", 5, new[] { "AAAAT", "GGGGT", "TTTTA" });
            FrequentWordsTest("ATACAATTACAGTCTGGAACCGGATGAACTGGCCGCAGGTTAACAACAGAGTTGCCAGGCACTGCCGCTGACCAGCAACAACAACAATGACTTTGACGCGAAGGGGATGGCATGAGCGAACTGATCGTCAGCCGTCAGCAACGAGTATTGTTGCTGACCCTTAACAATCCCGCCGCACGTAATGCGCTAACTAATGCCCTGCTG", 5, "AACAA");
            FrequentWordsTest("CGGAAGCGAGATTCGCGTGGCGTGATTCCGGCGGGCGTGGAGAAGCGAGATTCATTCAAGCCGGGAGGCGTGGCGTGGCGTGGCGTGCGGATTCAAGCCGGCGGGCGTGATTCGAGCGGCGGATTCGAGATTCCGGGCGTGCGGGCGTGAAGCGCGTGGAGGAGGCGTGGCGTGCGGGAGGAGAAGCGAGAAGCCGGATTCAAGCAAGCATTCCGGCGGGAGATTCGCGTGGAGGCGTGGAGGCGTGGAGGCGTGCGGCGGGAGATTCAAGCCGGATTCGCGTGGAGAAGCGAGAAGCGCGTGCGGAAGCGAGGAGGAGAAGCATTCGCGTGATTCCGGGAGATTCAAGCATTCGCGTGCGGCGGGAGATTCAAGCGAGGAGGCGTGAAGCAAGCAAGCAAGCGCGTGGCGTGCGGCGGGAGAAGCAAGCGCGTGATTCGAGCGGGCGTGCGGAAGCGAGCGG", 12, new[] { "CGGCGGGAGATT", "CGGGAGATTCAA", "CGTGCGGCGGGA", "CGTGGAGGCGTG", "CGTGGCGTGCGG", "GCGTGCGGCGGG", "GCGTGGAGGCGT", "GCGTGGCGTGCG", "GGAGAAGCGAGA", "GGAGATTCAAGC", "GGCGGGAGATTC", "GGGAGATTCAAG", "GTGCGGCGGGAG", "TGCGGCGGGAGA" });
        }

        private static void FrequentWordsTest(string text, int k, string expected)
        {
            FrequentWordsTest(text, k, new[] { expected });
        }

        private static void FrequentWordsTest(string text, int k, ICollection expected)
        {
            IEnumerable<string> words = Program.FrequentWords(text, k);
            CollectionAssert.AreEquivalent(expected, words.ToList());
        }

        private static void PatternCountTest(string text, string pattern, int expected)
        {
            int count = Program.PatternCount(text, pattern);
            Assert.AreEqual(expected, count);
        }
    }
}
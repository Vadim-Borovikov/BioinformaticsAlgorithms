using System;
using System.Collections;
using System.Text;
using BioinformaticsAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BioinformaticsAlgorithmsTests
{
    [TestClass]
    public class DnaStringTests
    {
        [TestMethod]
        public void DnaStringTest()
        {
            Console.WriteLine(GetSize(TestString));
            var dnaString = new DnaString(TestString);
            Console.WriteLine(GetSize(dnaString.Content));
            string s = dnaString.ToString();
            Assert.AreEqual(TestString, s);
        }

        private static int GetSize(string s)
        {
            return Encoding.ASCII.GetByteCount(s);
        }

        private static int GetSize(BitArray a) => (int)Math.Ceiling(a.Length / 8.0);

        private const string TestString = "ATCAATGATCAACGTAAGCTTCTAAGCATGATCAAGGTGCTCACACAGTTTATCCACAAC" +
                                          "CTGAGTGGATGACATCAAGATAGGTCGTTGTATCTCCTTCCTCTCGTACTCTCATGACCA" +
                                          "CGGAAAGATGATCAAGAGAGGATGATTTCTTGGCCATATCGCAATGAATACTTGTGACTT" +
                                          "GTGCTTCCAATTGACATCTTCAGCGCCATATTGCGCTGGCCAAGGTGACGGAGCGGGATT" +
                                          "ACGAAAGCATGATCATGGCTGTTGTTCTGTTTATCTTGTTTTGACTGAGACTTGTTAGGA" +
                                          "TAGACGGTTTTTCATCACTGACTAGCCAAAGCCTTACTCTGCCTGACATCGACCGTAAAT" +
                                          "TGATAATGAATTTACATGCTTCCGCGACGATTTACCTCTTGATCATCGATCCGATTGAAG" +
                                          "ATCTTCAATTGTTAATTCTCTTGCCTCGACTCATAGCCATGATGAGCTCTTGATCATGTT" +
                                          "TCCTTAACCCTCTATTTTTTACGGAAGAATGATCAAGCTGCTGCTCTTGATCATCGTTTC";
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BioinformaticsAlgorithms
{
    public class DnaString : IEquatable<DnaString>
    {
        public readonly BitArray Content;
        private int Length => Content.Length / 2;

        private DnaString(int length)
        {
            Content = new BitArray(length * 2);
        }

        public DnaString(string s)
        {
            var bits = new bool[s.Length * 2];
            for (int i = 0; i < s.Length; ++i)
            {
                char c = s[i];
                bool[] b = DnaChar.CharToBits(c);
                bits[i * 2] = b[0];
                bits[i * 2 + 1] = b[1];
            }
            Content = new BitArray(bits);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < (Content.Length - 1); i += 2)
            {
                result += DnaChar.BitsToChar(Content[i], Content[i + 1]);
            }
            return result;
        }

        #region Equality
        public bool Equals(DnaString other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Content.Length != other.Content.Length)
            {
                return false;
            }

            for (int i = 0; i < other.Content.Length; ++i)
            {
                if (Content[i] != other.Content[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is DnaString dnaString)
            {
                return Equals(dnaString);
            }

            return false;
        }

        public static bool operator ==(DnaString dna1, DnaString dna2) => Equals(dna1, dna2);
        public static bool operator !=(DnaString dna1, DnaString dna2) => !(dna1 == dna2);

        public override int GetHashCode()
        {
            if (Content == null)
            {
                return 0;
            }

            var map = new int[(int)Math.Ceiling(Content.Length / 8.0)];
            Content.CopyTo(map, 0);
            return map.Aggregate(17, (current, i) => current * 23 + i.GetHashCode());
        }

        #endregion // Equality

        #region PatternCount
        internal int PatternCount(DnaString pattern)
        {
            return PatternMatching(pattern).Count();
        }

        private int PatternCount(int patternStartIndex, int patternLength)
        {
            int result = 0;
            for (int i = 0; i <= (Content.Length - patternLength); i += 2)
            {
                if (IsSubstring(i, patternStartIndex, patternLength))
                {
                    ++result;
                }
            }
            return result;
        }

        private bool IsSubstring(int startIndex, DnaString pattern)
        {
            for (int i = 0; i < pattern.Content.Length; ++i)
            {
                if (Content[startIndex + i] != pattern.Content[i])
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSubstring(int startIndex, int patternStartIndex, int length)
        {
            for (int i = 0; i < length; ++i)
            {
                if (Content[startIndex + i] != Content[patternStartIndex + i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion // PatternCount

        #region FrequentWords
        internal IEnumerable<DnaString> FrequentWords(int k)
        {
            var amounts = new int[Length - k + 1];
            for (int i = 0; i <= (Length - k); ++i)
            {
                amounts[i] = PatternCount(i * 2, k * 2);
            }
            int maxAmount = amounts.Max();

            var frequentWords = new HashSet<DnaString>();
            for (int i = 0; i <= (Length - k); ++i)
            {
                if (amounts[i] == maxAmount)
                {
                    frequentWords.Add(Substring(i, k));
                }
            }
            return frequentWords;
        }
        #endregion // FrequentWords

        private DnaString Substring(int startIndex, int length)
        {
            var result = new DnaString(length);
            for (int i = 0; i < (length * 2); ++i)
            {
                result.Content[i] = Content[i + startIndex * 2];
            }
            return result;
        }

        #region ReverseComplement
        internal DnaString GetReverseComplement()
        {
            var result = new DnaString(Length);
            for (int i = 0; i < (Content.Length - 1); i += 2)
            {
                bool[] b = DnaChar.Flip(Content[result.Content.Length - i - 2],
                                        Content[result.Content.Length - i - 1]);
                result.Content[i] = b[0];
                result.Content[i + 1] = b[1];
            }
            return result;
        }
        #endregion // ReverseComplement

        #region PatternMatching
        internal IEnumerable<int> PatternMatching(DnaString pattern)
        {
            for (int i = 0; i <= (Length - pattern.Length); ++i)
            {
                if (IsSubstring(i * 2, pattern))
                {
                    yield return i;
                }
            }
        }
        #endregion // PatternMatching

        #region ClumpFinding
        internal IEnumerable<DnaString> ClumpFinding(int k, int windowLength, int minAmount)
        {
            var clumps = new HashSet<DnaString>();
            for (int i = 0; i <= (Length - windowLength); ++i)
            {
                DnaString window = Substring(i, windowLength);
                IEnumerable<DnaString> currentClumps = window.FrequentWords(k, minAmount);
                foreach (DnaString clump in currentClumps)
                {
                    clumps.Add(clump);
                }
            }
            return clumps;
        }

        private IEnumerable<DnaString> FrequentWords(int k, int minAmount)
        {
            var frequentWords = new HashSet<DnaString>();
            for (int i = 0; i <= (Length - k); ++i)
            {
                int amount = PatternCount(i * 2, k * 2);
                if (amount >= minAmount)
                {
                    frequentWords.Add(Substring(i, k));
                }
            }
            return frequentWords;
        }
        #endregion // ClumpFinding
    }
}

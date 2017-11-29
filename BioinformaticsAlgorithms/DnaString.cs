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
            Content = new BitArray(length);
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
        public int PatternCount(DnaString pattern)
        {
            int result = 0;
            for (int i = 0; i <= (Length - pattern.Length); ++i)
            {
                if (IsSubstring(i * 2, pattern))
                {
                    ++result;
                }
            }
            return result;
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
                    frequentWords.Add(Substring(i * 2, k * 2));
                }
            }
            return frequentWords;
        }
        #endregion // FrequentWords

        private DnaString Substring(int startIndex, int length)
        {
            var result = new DnaString(length);
            for (int i = 0; i < length; ++i)
            {
                result.Content[i] = Content[i + startIndex];
            }
            return result;
        }
    }
}

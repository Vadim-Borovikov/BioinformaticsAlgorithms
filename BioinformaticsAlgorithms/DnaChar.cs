﻿namespace BioinformaticsAlgorithms
{
    internal static class DnaChar
    {
        /// <summary>
        /// Two bits.
        /// 00 - A;
        /// 01 - T;
        /// 10 - G;
        /// 11 - C
        /// </summary>
        internal static bool[] CharToBits(char c)
        {
            c = char.ToUpper(c);
            return new[]
            {
                (c == 'G') || (c == 'C'),
                (c == 'T') || (c == 'C')
            };
        }

        internal static char BitsToChar(bool a, bool b)
        {
            if (a)
            {
                return b ? 'C' : 'G';
            }
            return b ? 'T' : 'A';
        }
    }
}

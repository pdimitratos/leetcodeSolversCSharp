using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Integers
{
    public class RomanIntegers
    {
        // https://leetcode.com/problems/roman-to-integer/
        /// <summary>
        /// Converts a string representation of a roman numeral to its equivalent integer value
        /// </summary>
        /// <param name="s">A roman numeral</param>
        /// <returns>The integer value</returns>
        public int RomanToInt(string s)
        {
            int currentValue;
            int previousValue = 0;
            int total = 0;
            // Read from the right to make the strange cases simpler
            for (int i = s.Length - 1; i >= 0; i--)
            {
                currentValue = RomanToInt(s[i]);
                total = currentValue < previousValue
                    ? total - currentValue
                    : total + currentValue;
                previousValue = currentValue;
                
            }
            return total;
        }

        // https://leetcode.com/problems/integer-to-roman/
        public string IntToRoman(int num)
        {
            // TODO: IIII => IV exception case
            StringBuilder result = new StringBuilder();
            while (num > 0)
            {
                result.Append(ExtractNextRomanCharacter(ref num));
            }
            return result.ToString();
        }


        private int RomanToInt(char c)
        {
            switch (c)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default:
                    throw new ArgumentOutOfRangeException($"Expected valid roman numeral between I and M, but received {c}");

            }
        }

        private string ExtractNextRomanCharacter(ref int i)
        {
            if (i < 1) throw new ArgumentOutOfRangeException(nameof(i));

            var characterTranslations = new List<(string, int)>()
            {
                ("M", 1000),
                ("CM", 900),
                ("D", 500),
                ("CD", 400),
                ("C", 100),
                ("XC", 90),
                ("L", 50),
                ("XL", 40),
                ("X", 10),
                ("IX", 9),
                ("V", 5),
                ("IV", 4),
                ("I", 1)
            };

            foreach (var translation in characterTranslations)
            {
                if (TryExtractRomanCharacter(ref i, translation.Item2))
                {
                    return translation.Item1;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(i));
        }

        private bool TryExtractRomanCharacter(ref int i, int romanValue)
        {
            if (i >= romanValue)
            {
                i = i - romanValue;
                return true;
            }
            return false;
        }
    }
}

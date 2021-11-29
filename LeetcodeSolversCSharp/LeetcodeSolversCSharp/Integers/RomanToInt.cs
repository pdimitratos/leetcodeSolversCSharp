using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Integers
{
    public class RomanToIntSolver
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
    }
}

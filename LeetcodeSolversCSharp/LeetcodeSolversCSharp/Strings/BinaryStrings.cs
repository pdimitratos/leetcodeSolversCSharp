using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Strings
{
    public static class BinaryStrings
    {
        public static string AddBinary(string a, string b)
        {
            var previousDigits = new Stack<char>();
            bool carryForward = false;
            int shortestStringLength = Math.Min(a.Length, b.Length);
            for (int i = 1; i <= shortestStringLength; i++)
            {
                char valA = a[a.Length - i];
                char valB = b[b.Length - i];
                char digitToPush = valA == valB
                    ? '0'
                    : '1';
                if (carryForward)
                {
                    carryForward = digitToPush == '1'
                        || valA == '1' && valB == '1';
                    digitToPush = digitToPush == '0' ? '1' : '0';
                }
                else
                {
                    carryForward = valA == '1' && valB == '1';
                }
                previousDigits.Push(digitToPush);
            }
            string longestString = a.Length > b.Length ? a : b;
            for (int i = longestString.Length - 1 - shortestStringLength; i >= 0; i--)
            {
                char digitToPush = longestString[i];
                if (carryForward)
                {
                    carryForward = digitToPush == '1';
                    digitToPush = digitToPush == '0' ? '1' : '0';
                }
                previousDigits.Push(digitToPush);
            }
            if (carryForward)
            {
                previousDigits.Push('1');
            }
            return new string(previousDigits.ToArray());
        }
    }
}

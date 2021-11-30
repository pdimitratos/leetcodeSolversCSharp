using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Strings
{
    public static class PalindromeExtensions
    {
        // https://leetcode.com/problems/longest-palindromic-substring
        public static string LongestPalindrome(this string s)
        {
            string longestPalindrome = string.Empty;
            string reversedString = new string(s.Reverse().ToArray());
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < reversedString.Length - i; j++)
                {
                    bool hasPalindrome = false;
                    for (
                        int palindromeLookaheadIndex = 0;
                        palindromeLookaheadIndex < reversedString.Length - j - i;
                        palindromeLookaheadIndex++)
                    {
                        if (reversedString[j + palindromeLookaheadIndex] != s[i + palindromeLookaheadIndex])
                        {
                            hasPalindrome = false;
                            break;
                        }
                        hasPalindrome = true;
                    }

                    if (hasPalindrome)
                    {
                        string currentPalindrome = reversedString.Substring(j, reversedString.Length - i - j);
                        longestPalindrome = currentPalindrome.Length > longestPalindrome.Length
                            ? currentPalindrome
                            : longestPalindrome;
                    }
                }
            }
            return longestPalindrome;
        }
    }
}

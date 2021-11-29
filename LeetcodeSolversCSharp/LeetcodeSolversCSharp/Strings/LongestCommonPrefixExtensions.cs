using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.strings
{
    public static class LongestCommonPrefixExtensions
    {
        //https://leetcode.com/problems/longest-common-prefix/
        public static string LongestCommonPrefix(this string[] strs)
        {
            string longestCommonPrefix = string.Empty;
            for(int i = 0; i < strs.Select(str => str.Length).Min(); i++)
            {
                char current = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j][i] != current)
                    {
                        return longestCommonPrefix;
                    }
                }
                longestCommonPrefix += current;
            }
            return longestCommonPrefix;
        }
    }
}

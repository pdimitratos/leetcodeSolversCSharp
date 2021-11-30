using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetcodeSolversCSharp.Strings;
using NUnit.Framework;

namespace LeetcodeSolversCSharpTests.Strings
{
    public class PalindromeExtensionsTests
    {
        [TestCase("babad", "bab")]
        [TestCase("cbbd", "bb")]
        [TestCase("a", "a")]
        [TestCase("ac", "a")]
        [TestCase("aacabdkacaa", "aca")]
        public void ValidateExampleBehavior_AddBinary(string input, string expectedOutput)
        {
            Assert.AreEqual(expectedOutput, input.LongestPalindrome());
        }
    }
}

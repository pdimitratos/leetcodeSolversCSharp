using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.strings;

namespace LeetcodeSolversCSharpTests.Strings
{
    public class LongestCommonPrefixTests
    {
        [TestCase(new string[] { "flower", "flow", "flight" }, "fl")]
        [TestCase(new string[] { "dog", "racecar", "car" }, "")]
        public void ValidateExampleBehavior(string[] input, string expectedResult)
        {
            Assert.AreEqual(expectedResult, input.LongestCommonPrefix());
        }
    }
}

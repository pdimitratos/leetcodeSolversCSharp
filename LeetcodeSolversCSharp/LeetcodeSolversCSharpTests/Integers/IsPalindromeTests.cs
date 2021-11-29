using NUnit.Framework;
using LeetcodeSolversCSharp;

namespace LeetcodeSolversCSharpTests
{
    public class IsPalindromeTests
    {
        [TestCase(121, true)]
        [TestCase(-121, false)]
        [TestCase(10, false)]
        [TestCase(-101, false)]
        public void ValidateExampleBehavior(int input, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, input.IsPalindrome());
        }
    }
}
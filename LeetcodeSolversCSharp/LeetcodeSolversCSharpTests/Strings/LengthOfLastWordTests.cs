using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.strings;
using LeetcodeSolversCSharp.Strings;

namespace LeetcodeSolversCSharpTests.Strings
{
    public class LengthOfLastWordTests
    {
        [TestCase("Hello World", 5)]
        [TestCase("   fly me   to   the moon  ", 4)]
        [TestCase("luffy is still joyboy", 6)]
        public void ValidateExampleBehavior(string input, int expectedResult)
        {
            var objectUnderTest = new LengthOfLastWordSolver();

            Assert.AreEqual(expectedResult, objectUnderTest.LengthOfLastWord(input));
        }
    }
}

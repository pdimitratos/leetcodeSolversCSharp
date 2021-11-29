using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.Integers;

namespace LeetcodeSolversCSharpTests.Integers
{
    public class RomanToIntTests
    {
        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void ValidateExampleBehavior(string input, int expectedResult)
        {
            var objectUnderTest = new RomanToIntSolver();

            var result = objectUnderTest.RomanToInt(input);

            Assert.AreEqual(expectedResult, result);
        }
    }
}

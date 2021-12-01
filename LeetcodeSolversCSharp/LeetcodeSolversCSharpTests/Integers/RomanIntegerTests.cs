using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.Integers;

namespace LeetcodeSolversCSharpTests.Integers
{
    public class RomanIntegerTests
    {
        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void ValidateExampleBehavior_RomanToInt(string input, int expectedResult)
        {
            var objectUnderTest = new RomanIntegers();

            var result = objectUnderTest.RomanToInt(input);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        [TestCase(58, "LVIII")]
        [TestCase(1994, "MCMXCIV")]
        public void ValidateExampleBehavior_IntToRoman(int input, string expectedResult)
        {
            var objectUnderTest = new RomanIntegers();

            var result = objectUnderTest.IntToRoman(input);

            Assert.AreEqual(expectedResult, result);
        }
    }
}

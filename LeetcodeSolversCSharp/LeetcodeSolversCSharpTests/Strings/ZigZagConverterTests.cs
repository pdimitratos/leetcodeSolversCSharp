using NUnit.Framework;
using LeetcodeSolversCSharp.Strings;

namespace LeetcodeSolversCSharpTests.Strings
{
    internal class ZigZagConverterTests
    {
        [TestCase("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [TestCase("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        [TestCase("A", 1, "A")]
        public void ValidateExampleBehavior(string input, int inputRows, string expectedResult)
        {
            var objectUnderTest = new ZigZagConverter();

            Assert.AreEqual(expectedResult, objectUnderTest.Convert(input, inputRows));
        }
    }
}

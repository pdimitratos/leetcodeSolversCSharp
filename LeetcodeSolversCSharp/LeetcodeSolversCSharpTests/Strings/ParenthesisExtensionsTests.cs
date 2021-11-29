using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.Strings;

namespace LeetcodeSolversCSharpTests.Strings
{
    internal class ParenthesisExtensionsTests
    {
        [TestCase("()", true)]
        [TestCase("()[]{}", true)]
        [TestCase("(]", false)]
        [TestCase("([)]", false)]
        [TestCase("{[]}", true)]
        public void ValidateExampleBehavior(string input, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, input.IsValid());
        }
    }
}

using NUnit.Framework;
using LeetcodeSolversCSharp;

namespace LeetcodeSolversCSharpTests
{
    public class IsPalindromeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Input_121_Returns_True()
        {
            Assert.IsTrue(121.IsPalindrome());
        }

        [Test]
        public void Input__121_Returns_False()
        {
            Assert.IsFalse((-121).IsPalindrome());
        }

        [Test]
        public void Input_10_Returns_False()
        {
            Assert.IsFalse(10.IsPalindrome());
        }

        [Test]
        public void Input__101_Returns_False()
        {
            Assert.IsFalse((-101).IsPalindrome());
        }
    }
}
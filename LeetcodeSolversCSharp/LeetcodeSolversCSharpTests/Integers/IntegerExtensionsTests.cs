using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.DataStructures;
using LeetcodeSolversCSharp.Integers;

namespace LeetcodeSolversCSharpTests.Integers
{
    internal class IntegerExtensionsTests
    {
        [TestCase(123, 321)]
        [TestCase(-123, -321)]
        [TestCase(120, 21)]
        [TestCase(0, 0)]
        [TestCase(1534236469, 0)]
        public void ValidateExampleBehavior_Reverse(int input, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, input.Reverse());
        }

        // Wow, this function is terrible.
        [TestCase("", 0)]
        [TestCase("2147483648", 2147483647)]
        [TestCase("42", 42)]
        [TestCase("    -42", -42)]
        [TestCase("4193 with words", 4193)]
        [TestCase("words and 987", 0)]
        [TestCase("-91283472332", -2147483648)]
        [TestCase("-6147483648", -2147483648)]
        public void ValidateExampleBehavior_MyAtoi(string input, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, input.MyAtoi());
        }
    }
}

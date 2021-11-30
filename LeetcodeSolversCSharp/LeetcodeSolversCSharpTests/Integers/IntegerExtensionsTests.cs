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
        public void ValidateExampleBehavior_RemoveDuplicates(int input, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, input.Reverse());
        }
    }
}

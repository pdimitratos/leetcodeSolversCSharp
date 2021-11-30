using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetcodeSolversCSharp.Strings;
using NUnit.Framework;

namespace LeetcodeSolversCSharpTests.Strings
{
    public class BinaryStringsTests
    {

        [TestCase("11", "1", "100")]
        [TestCase("1010", "1011", "10101")]
        [TestCase("1111", "1111", "11110")]
        public void ValidateExampleBehavior_AddBinary(string inputA, string inputB, string expectedOutput)
        {
            Assert.AreEqual(expectedOutput, BinaryStrings.AddBinary(inputA, inputB));
        }
    }
}

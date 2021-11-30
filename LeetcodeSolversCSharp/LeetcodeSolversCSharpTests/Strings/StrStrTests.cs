using NUnit.Framework;
using LeetcodeSolversCSharp.Strings;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharpTests.Strings
{
    internal class StrStrTests
    {
        [TestCase("hello", "ll", 2)]
        [TestCase("aaaaa", "bba", -1)]
        [TestCase("", "", 0)]
        public void ValidateExampleBehavior(string inputHaystack, string inputNeedle, int expectedResult)
        {
            var objectUnderTest = new StrStrSolver();

            Assert.AreEqual(expectedResult, objectUnderTest.StrStr(inputHaystack, inputNeedle));
        }
    }
}

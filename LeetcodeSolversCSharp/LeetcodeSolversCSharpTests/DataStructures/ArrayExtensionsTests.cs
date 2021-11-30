using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.DataStructures;

namespace LeetcodeSolversCSharpTests.DataStructures
{
    internal class ArrayExtensionsTests
    {
        [TestCase(new int[] { 1, 1, 2 }, 2)]
        [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
        public void ValidateExampleBehavior(int[] input, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, input.RemoveDuplicates());
        }
    }
}

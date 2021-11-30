using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.DataStructures;

namespace LeetcodeSolversCSharpTests.DataStructures
{
    internal class ArrayExtensionsTests
    {
        [TestCase(new int[] { 1, 1, 2 }, 2)]
        [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
        public void ValidateExampleBehavior_RemoveDuplicates(int[] input, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, input.RemoveDuplicates());
        }

        [TestCase(new int[] { 3, 2, 2, 3 }, 3, 2)]
        [TestCase(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
        public void ValidateExampleBehavior_RemoveValue (int[] inputArray, int inputValueToRemove, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, inputArray.RemoveValue(inputValueToRemove));
        }

        [TestCase(new int[] { 1, 3, 5, 6 }, 5 , 2)]
        [TestCase(new int[] { 1, 3, 5, 6 }, 2 , 1)]
        [TestCase(new int[] { 1, 3, 5, 6 }, 7 , 4)]
        [TestCase(new int[] { 1, 3, 5, 6 }, 0 , 0)]
        [TestCase(new int[] { 1 }, 0 , 0)]
        public void ValidateExampleBehavior_SearchInsert(int[] input, int targetInput, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, input.SearchInsert(targetInput));
        }
    }
}

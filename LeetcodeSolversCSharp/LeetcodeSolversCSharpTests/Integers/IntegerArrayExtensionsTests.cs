using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.Integers;
using System.Collections.Generic;

namespace LeetcodeSolversCSharpTests.DataStructures
{
    internal class IntegerArrayExtensionsTests
    {
        [TestCase(new int[] { 1, 1, 2 }, 2)]
        [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
        public void RemoveDuplicates_ValidateExampleBehavior(int[] input, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, input.RemoveDuplicates());
        }

        [TestCase(new int[] { 3, 2, 2, 3 }, 3, 2)]
        [TestCase(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
        public void RemoveValue_ValidateExampleBehavior(int[] inputArray, int inputValueToRemove, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, inputArray.RemoveValue(inputValueToRemove));
        }

        [TestCase(new int[] { 1, 3, 5, 6 }, 5 , 2)]
        [TestCase(new int[] { 1, 3, 5, 6 }, 2 , 1)]
        [TestCase(new int[] { 1, 3, 5, 6 }, 7 , 4)]
        [TestCase(new int[] { 1, 3, 5, 6 }, 0 , 0)]
        [TestCase(new int[] { 1 }, 0 , 0)]
        public void SearchInsert_ValidateExampleBehavior(int[] input, int targetInput, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, input.SearchInsert(targetInput));
        }

        [TestCase(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 5, 4, -1, 7, 8 }, 23)]
        public void MaxSubArray_ValidateExampleBehavior(int[] inputArray, int expectedOutput)
        {
            Assert.AreEqual(expectedOutput, inputArray.MaxSubArray());
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 })]
        [TestCase(new int[] { 0 }, new int[] { 1 })]
        [TestCase(new int[] { 9 }, new int[] { 1 , 0 })]
        public void PlusOne_ValidateExampleBehavior(int[] inputArray, int[] expectedOutput)
        {
            Assert.AreEqual(expectedOutput, inputArray.PlusOne());
        }

        

    }
}

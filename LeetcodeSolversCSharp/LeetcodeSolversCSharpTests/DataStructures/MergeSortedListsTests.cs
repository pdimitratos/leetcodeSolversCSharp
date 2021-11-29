using NUnit.Framework;
using LeetcodeSolversCSharp;
using LeetcodeSolversCSharp.DataStructures;
using LeetcodeSolversCSharp.LeetcodeProvided;

namespace LeetcodeSolversCSharpTests.DataStructures
{
    internal class MergeSortedListsTests
    {
        [TestCase(
            new int[] {1, 2, 4},
            new int[] {1, 3, 4},
            new int[] {1, 1, 2, 3, 4, 4}
        )]
        [TestCase(
            new int[] { },
            new int[] { },
            new int[] { }
        )]
        [TestCase(
            new int[] { },
            new int[] { 0 },
            new int[] { 0 }
        )]
        public void ValidateExampleBehavior(
            int[] firstList,
            int[] secondList,
            int[] expectedResult)
        {
            var objectUnderTest = new MergeSortedLists();

            var result = objectUnderTest.MergeTwoLists(
                    ListNode.CreateFromArray(firstList),
                    ListNode.CreateFromArray(secondList)
                )?.ToArray()
                ?? new int[] { };

            Assert.AreEqual(expectedResult, result);
        }
    }
}

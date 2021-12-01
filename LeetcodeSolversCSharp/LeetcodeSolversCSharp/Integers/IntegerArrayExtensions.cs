using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Integers
{
    public static class IntegerArrayExtensions
    {
        public static int RemoveDuplicates(this int[] nums)
        {
            int currentIndex = 0;
            int displacement = 0;
            int previousValue = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == previousValue)
                {
                    displacement++;
                }
                else
                {
                    nums[i - displacement] = nums[i];
                    previousValue = nums[i];
                    currentIndex++;
                }
            }


            return currentIndex;
        }

        public static int RemoveValue(this int[] nums, int val)
        {
            int currentIndex = 0;
            int displacement = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    displacement++;
                }
                else
                {
                    nums[i - displacement] = nums[i];
                    currentIndex++;
                }
            }


            return currentIndex;
        }

        public static int SearchInsert(this int[] nums, int target)
        {
            int index = (nums.Length - 1) / 2;
            int stepSize = (index + 1) / 2;
            int covered = 0;
            while (covered < nums.Length / 2)
            {
                if (nums[index] == target)
                    return index;

                if (nums[index] < target)
                {
                    index += stepSize;
                }
                else
                {
                    index -= stepSize;
                }
                covered += stepSize;
                stepSize = stepSize / 2;
                if (stepSize < 1)
                    stepSize = 1;
                if (index < 0)
                    index = 0;
            }

            if (nums[index] < target)
            {
                return index + 1;
            }

            return index;
        }

        // https://leetcode.com/problems/maximum-subarray/
        public static int MaxSubArray(this int[] nums)
        {
            int[] largestLeftSubarray = new int[nums.Length];
            int currentMax = largestLeftSubarray[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                largestLeftSubarray[i] = Math.Max(
                    nums[i],
                    largestLeftSubarray[i - 1] + nums[i]);

                currentMax = Math.Max(currentMax, largestLeftSubarray[i]);
            }

            return currentMax;
        }

        // https://leetcode.com/problems/plus-one/
        public static int[] PlusOne(this int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] = digits[i] + 1;
                if (digits[i] > 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    return digits;
                }
            }
            int[] resultWithExtraDigit = new int[digits.Length + 1];
            resultWithExtraDigit[0] = 1;
            Array.Copy(digits, 0, resultWithExtraDigit, 1, digits.Length);
            return resultWithExtraDigit;
        }

        // https://leetcode.com/problems/3sum/
        public static IList<IList<int>> ThreeSum(this int[] nums)
        {
            var result = new Dictionary<int, IDictionary<int, int>>();
            if (nums.Length <= 2) return new List<IList<int>>();


            nums = ThreeSumDeduplicate(nums);


            // Presorting the list allows selection of one negative and one positive number
            // allowing the creation of a triplet by finding a single number that matches those two
            // This also allows increased efficiency by bailing early when a solution can never be found.
            List<int> convertedNums = new List<int>(nums);
            convertedNums.Sort();
            int[] orderedNums = convertedNums.ToArray();
            int zeroIndex = FindCenterIndexInOrderedArray(orderedNums, 0, false);

            for (int i = 0; i <= zeroIndex; i++)
                for (int j = orderedNums.Length - 1; j >= zeroIndex; j--)
                {
                    if (result.TryGetValue(orderedNums[i], out IDictionary<int, int> existingTriplets)
                        && existingTriplets.TryGetValue(orderedNums[j], out _))
                    {
                        break; // We already have this triplet
                    }

                    bool isDescending = orderedNums[i] + orderedNums[j] >= 0;
                    int desiredTripleCompletion = -1 * (orderedNums[i] + orderedNums[j]);
                    int k = FindCenterIndexInOrderedArray(orderedNums, desiredTripleCompletion, isDescending);

                    for (;
                        k > i && k < j;
                        k += isDescending ? -1 : 1)
                    {
                        int currentSum = orderedNums[i] + orderedNums[j] + orderedNums[k];
                        // Bail when further k values can never create a triple
                        if (isDescending
                                ? currentSum < 0
                                : currentSum > 0)
                        {
                            break;
                        }

                        if (i != j
                            && i != k
                            && j != k
                            && 0 == currentSum)
                        {
                            var orderedTriplet = new List<int> { orderedNums[i], orderedNums[j], orderedNums[k] }
                                .OrderBy(x => x)
                                .ToList();

                            // Skip duplicates
                            if (!result.TryGetValue(orderedTriplet[0], out IDictionary<int, int> currentSubdictionary))
                            {
                                currentSubdictionary = result[orderedTriplet[0]] = new Dictionary<int, int>();
                            }
                            currentSubdictionary[orderedTriplet[1]] = orderedTriplet[2];
                        }
                    }
                }
            return result
                .SelectMany(kvp => kvp.Value
                    .Select(kvp2 => (IList<int>)new List<int> { kvp.Key, kvp2.Key, kvp2.Value }))
                .ToList();
        }

        private static int[] ThreeSumDeduplicate(int[] nums)
        {
            var counts = new Dictionary<int, int>();
            int runningTotal = 0;
            foreach (int num in nums)
            {
                if (!counts.TryGetValue(num, out int currentCount))
                {
                    counts[num] = 1;
                    runningTotal++;
                }
                else
                {
                    if (currentCount == 1
                        || currentCount == 2 && num == 0)
                    {
                        counts[num]++;
                        runningTotal++;
                    }
                }
            }
            int[] result = new int[runningTotal];
            int currentIndex = 0;
            foreach (var countInfo in counts)
            {
                for (int i = 0; i < countInfo.Value; i++)
                {
                    result[currentIndex] = countInfo.Key;
                    currentIndex++;
                }
            }
            return result;
        }

        private static int FindCenterIndexInOrderedArray(int[] orderedNums, int valueToFind, bool errHigh)
        {
            int index = Array.BinarySearch(orderedNums, valueToFind);
            if (index < 0)
                index = ~index; // Zero not found, convert from bitwise compliment to find nearest index
            
            int leastZeroIndex = index;
            while (leastZeroIndex > 0 && orderedNums[leastZeroIndex - 1] == valueToFind)
                leastZeroIndex--;

            int greatestZeroIndex = index;
            while (greatestZeroIndex < orderedNums.Length - 1 && orderedNums[greatestZeroIndex + 1] == valueToFind)
                greatestZeroIndex++;

            return errHigh
                ? (leastZeroIndex + greatestZeroIndex + 1) / 2
                : (leastZeroIndex + greatestZeroIndex) / 2;
        }
    }
}

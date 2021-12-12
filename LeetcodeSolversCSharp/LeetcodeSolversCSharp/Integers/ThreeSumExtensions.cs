using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Integers
{
    public static class ThreeSumExtensions
    {
        // https://leetcode.com/problems/3sum/
        public static IList<IList<int>> ThreeSum(this int[] nums)
        {
            if (nums.Length <= 2) return new List<IList<int>>();
            int[] orderedNums = PreprocessForThreeSum(ref nums);
            Dictionary<int, IDictionary<int, int>> result = MapTripletsWithSum(orderedNums, 0, out _);
            return result
                .SelectMany(kvp => kvp.Value
                    .Select(kvp2 => (IList<int>)new List<int> { kvp.Key, kvp2.Key, kvp2.Value }))
                .ToList();
        }

        public static int ThreeSumClosest(this int[] nums, int target)
        {
            if (nums.Length <= 2) return 0;
            int[] orderedNums = PreprocessForThreeSum(ref nums);

            MapTripletsWithSum(orderedNums, target, out int result);
            return result;
        }

        private static int[] PreprocessForThreeSum(ref int[] nums)
        {
            nums = ThreeSumDeduplicate(nums);


            // Presorting the list allows selection of one negative and one positive number
            // allowing the creation of a triplet by finding a single number that matches those two
            // This also allows increased efficiency by bailing early when a solution can never be found.
            List<int> convertedNums = new List<int>(nums);
            convertedNums.Sort();
            int[] orderedNums = convertedNums.ToArray();
            return orderedNums;
        }

        
        // TODO: split ThreeSum and ThreeSumClosest paths, since one doesn't need the out param
        // and the other doesn't need the return value
        private static Dictionary<int, IDictionary<int, int>> MapTripletsWithSum(int[] orderedNums, int target, out int closest)
        {
            closest = int.MaxValue;
            int previousDifferenceFromTarget = int.MaxValue;
            var result = new Dictionary<int, IDictionary<int, int>>();
            int targetIndex = FindCenterIndexInOrderedArray(orderedNums, target / 3, false);
            if (targetIndex > orderedNums.Length - 2)
                targetIndex = orderedNums.Length - 2;

            for (int i = 0; i <= targetIndex; i++)
                for (int j = orderedNums.Length - 1; j >= targetIndex; j--)
                {
                    if (result.TryGetValue(orderedNums[i], out IDictionary<int, int> existingTriplets)
                        && existingTriplets.TryGetValue(orderedNums[j], out _))
                    {
                        break; // We already have this triplet
                    }

                    bool isDescending = orderedNums[i] + orderedNums[j] >= target;
                    int desiredTripleCompletion = target - (orderedNums[i] + orderedNums[j]);
                    int k = FindCenterIndexInOrderedArray(orderedNums, desiredTripleCompletion, isDescending);
                    if (k <= i) k = i + 1;
                    if (k >= j) k = j - 1;

                    isDescending = k > (i + j) / 2;

                    for (;
                        k > i && k < j;
                        k += isDescending ? -1 : 1)
                    {
                        int currentSum = orderedNums[i] + orderedNums[j] + orderedNums[k];
                        int differenceFromTarget = Math.Abs(currentSum - target);
                        if (differenceFromTarget < previousDifferenceFromTarget)
                        {
                            previousDifferenceFromTarget = differenceFromTarget;
                            closest = currentSum;
                        }

                        // Bail when further k values can never create a triple
                        // For ThreeSumClosest this should also indicate values getting further from the target
                        // (Maybe, this could be a source of a logic error)
                        if (isDescending
                                ? currentSum < target
                                : currentSum > target)
                        {
                            break;
                        }

                        if (i != j
                            && i != k
                            && j != k
                            && target == currentSum)
                        {
                            // Order by is slow, consider replacing the Linq if this ever needs to be larger than 3 elements
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

            return result;
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
                    if (currentCount < 3)
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

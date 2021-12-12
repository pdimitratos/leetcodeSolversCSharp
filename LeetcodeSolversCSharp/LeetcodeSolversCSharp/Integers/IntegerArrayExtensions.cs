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

    }
}

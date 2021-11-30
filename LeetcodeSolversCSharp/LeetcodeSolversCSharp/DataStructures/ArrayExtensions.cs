using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.DataStructures
{
    public static class ArrayExtensions
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

        public static int RemoveValue (this int[] nums, int val)
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
            int stepSize = (index + 1)/ 2;
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
    }
}

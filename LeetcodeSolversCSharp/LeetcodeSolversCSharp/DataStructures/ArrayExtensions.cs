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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Integers
{
    public class WaterContainers
    {
        // https://leetcode.com/problems/container-with-most-water/
        public int MaxArea(int[] height)
        {
            int highestWaterCapacity = 0;
            for (int i = 0; i < height.Length - 1; i++)
            {               
                for (int j = height.Length - 1; j >= i + 1; j--)
                {
                    int currentWaterCapacity = Math.Min(height[i], height[j]) * (j - i);
                    if (currentWaterCapacity > highestWaterCapacity)
                    {
                        highestWaterCapacity = currentWaterCapacity;
                    }
                    if (height[j] >= height[i])
                    {
                        // Highest possible water volume for i
                        // since everything else is left and/or shorter than i
                        break;
                    }
                }
            }

            return highestWaterCapacity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day1
{
    public class SonarDepth
    {
        // https://adventofcode.com/2021/day/1
        public int CountDepthIncreases(int[] orderedDepthMeasurements)
        {
            int depthIncreases = 0;
            int previousMeasurement = int.MaxValue;

            for (int i = 0; i < orderedDepthMeasurements.Length; i++)
            {
                if (previousMeasurement < orderedDepthMeasurements[i])
                {
                    depthIncreases++;
                }
                previousMeasurement = orderedDepthMeasurements[i];
            }

            return depthIncreases;
        }
    }
}

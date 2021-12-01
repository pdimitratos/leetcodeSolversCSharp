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

        // https://adventofcode.com/2021/day/1#part2
        public int CountWindowedDepthIncreases(int[] orderedDepthMeasurements)
        {
            if (orderedDepthMeasurements.Length <= 2)
                throw new ArgumentOutOfRangeException(nameof(orderedDepthMeasurements));

            int[] orderedWindows = new int[orderedDepthMeasurements.Length - 2];
            orderedWindows[0] = orderedDepthMeasurements.Take(3).Sum();
            int depthIncreases = 0;

            for (int i = 1; i < orderedDepthMeasurements.Length - 2; i++)
            {
                orderedWindows[i] = orderedWindows[i - 1]
                    - orderedDepthMeasurements[i - 1]
                    + orderedDepthMeasurements[i + 2];
                if (orderedWindows[i - 1] < orderedWindows[i])
                {
                    depthIncreases++;
                }
            }

            return depthIncreases;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Integers
{
    public static class IntegerExtensions
    {
        public static int Reverse(this int x)
        {
            bool isNegative = x < 0;
            x = isNegative ? -x : x;
            int workingTotal = 0;
            int currentPlaceValue = 1;
            Stack<int> digitStack = new Stack<int>();
            while (x > 0)
            {
                digitStack.Push(x % 10);
                x = x / 10;
            }

            while (digitStack.TryPop(out int newDigit))
            {
                int newDigitValue = (newDigit * currentPlaceValue);
                if (newDigit != 0
                    && (currentPlaceValue > int.MaxValue / newDigit
                        || int.MaxValue - newDigitValue < workingTotal))
                {
                    return 0;
                }
                workingTotal += newDigitValue;
                currentPlaceValue = currentPlaceValue * 10;
            }

            return isNegative
                ? -1 * workingTotal
                : workingTotal;
        }
    }
}

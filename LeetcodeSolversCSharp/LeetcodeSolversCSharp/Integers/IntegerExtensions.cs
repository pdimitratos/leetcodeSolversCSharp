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

        // https://leetcode.com/problems/string-to-integer-atoi
        public static int MyAtoi(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            int result = 0;
            int currentDigitValue = 0;
            s = s.TrimStart();
            bool isNegative = s[0] == '-';
            int startingValue = s[0] == '-' || s[0] == '+'
                ? 1
                : 0;
            for (int i = startingValue; i < s.Length; i++)
            {
                bool isReadComplete = false;
                char current = s[i];
                switch (current)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        currentDigitValue = CharToDigit(current);
                        break;
                    default:
                        isReadComplete = true;
                        break;
                }
                if (isReadComplete)
                {
                    break;
                }
                else
                {
                    var previousResult = result;
                    if (result > int.MaxValue / 10)
                    {
                        return isNegative ? int.MinValue : int.MaxValue;
                    }
                    result = result * 10;
                    result += currentDigitValue;
                    if (previousResult > result) // Overflow
                    {
                        return isNegative ? int.MinValue : int.MaxValue;
                    }
                }
            }

            return isNegative
                ? -result
                : result;
        }

        private static int CharToDigit(char c)
        {
            // There's probably a more efficient way of doing this with
            // direct casting based on the character's numeric value.
            // But I'm too lazy to look up the offset.
            switch (c)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                default:
                    throw new ArgumentOutOfRangeException(nameof(c));
            }
        }
    }
}

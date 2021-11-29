using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Strings
{
    public static class ParenthesisExtensions
    {
        public static bool IsValid(this string s)
        {
            var stack = new Stack<char>();
            char previous;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(s[i]);
                        break;
                    case ')':
                    case ']':
                    case '}':
                        if (stack.Count == 0)
                            return false;

                        previous = stack.Pop();
                        if (!DoParenthesisMatch(previous, s[i]))
                        {
                            return false;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(s), "input can only contain parenthesis characters");
                }
            }
            return stack.Count == 0;
        }

        private static bool DoParenthesisMatch(char opener, char closer)
        {
            switch (opener)
            {
                case '(':
                    return closer == ')';
                case '[':
                    return closer == ']';
                case '{':
                    return closer == '}';
                default:
                    throw new ArgumentOutOfRangeException(nameof(opener));
            }
        }
    }

    
}

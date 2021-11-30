using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Strings
{
    public class ZigZagConverter
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;

            int zigZagIndex = 0;
            char[] zigZagOrder = new char[s.Length];
            for (int i = 0; i < s.Length; i = i + 2 * (numRows - 1))
            {
                zigZagOrder[zigZagIndex] = s[i];
                zigZagIndex++;
            }
            int intermediateRows = numRows - 2;
            for (int rowOffset = 1; rowOffset <= intermediateRows; rowOffset++)
            {
                bool isDownward = true;
                int rowsAbove = rowOffset - 1;
                int rowsBelow = intermediateRows - rowOffset;
                for (
                    int i = rowOffset;
                    i < s.Length;
                    i += !isDownward
                        ? 2 * rowsBelow + 2
                        : 2 * rowsAbove + 2)
                {
                    isDownward = !isDownward;
                    zigZagOrder[zigZagIndex] = s[i];
                    zigZagIndex++;
                }
            }
            for (int i = numRows - 1; i < s.Length; i = i + 2 * (numRows - 1))
            {
                zigZagOrder[zigZagIndex] = s[i];
                zigZagIndex++;
            }
            return new string(zigZagOrder);
        }
    }
}

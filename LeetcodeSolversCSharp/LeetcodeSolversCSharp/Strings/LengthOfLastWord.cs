using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Strings
{
    public class LengthOfLastWordSolver
    {
        public int LengthOfLastWord(string s)
        {
            return s.Trim().Split(' ').Last().Length;
        }
    }
}

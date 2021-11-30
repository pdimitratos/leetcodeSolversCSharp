using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.Strings
{
    public class StrStrSolver
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle == string.Empty) return 0;

            // Not what I'd do in an interview, but...
            return haystack.IndexOf(needle);
        }
    }
}

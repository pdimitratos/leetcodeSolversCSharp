using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSolversCSharp.LeetcodeProvided
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public int[] ToArray()
        {
            List<int> list = new List<int>();
            list.Add(val);
            ListNode? current = this;
            while (current.next != null)
            {
                list.Add(current.next.val);
                current = current.next;
            }
            return list.ToArray();
        }

        // Constructor for tests
        public static ListNode? CreateFromArray(int[] vals)
        {
            if (vals.Length == 0)
                return null;

            ListNode? current = null;
            ListNode? previous = null;
            for (int i = vals.Length - 1; i >= 0; i--)
            {
                current = new ListNode(vals[i], previous);
                previous = current;
            }
            return current;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetcodeSolversCSharp.LeetcodeProvided;

namespace LeetcodeSolversCSharp.DataStructures
{
    
    
    public class MergeSortedLists
    {
        public ListNode? MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode? mergedList = null;
            if (list1 is null && list2 is null)
                return null;

            if (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    mergedList = list1;
                    list1 = list1.next;
                }
                else
                {
                    mergedList = list2;
                    list2 = list2.next;
                }
            }
            else
            {
                if (list1 is null)
                {
                    mergedList = list2;
                    list2 = list2.next;
                }
                else
                {
                    mergedList = list1;
                    list1 = list1.next;
                }
            }

            ListNode workingList = mergedList;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    workingList.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    workingList.next = list2;
                    list2 = list2.next;
                }
                workingList = workingList.next;
            }

            workingList.next = list1 ?? list2;

            return mergedList;
        }

        
    }
}

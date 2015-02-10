using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    class FindElementFromEnd
    {
        public static void Code()
        {
            #region Find K-th node from end
            /* Get the Kth node from end of a linked list. It counts from 1 here, so the 1st node from end is the tail of list. 
             * For instance, given a linked list with 6 nodes, whose value are 1, 2, 3, 4, 5, 6, its 3rd node from end is the node with value 4.
             */

            //Solution  http://codercareer.blogspot.in/2011/10/no-10-k-th-node-from-end.html

            JabzLinkedList<int> findElementFromEnd = new JabzLinkedList<int>();

            for (int i = 1; i <= 25; i++)
            {
                findElementFromEnd.Add(i);
            }

            var result = FindKthNodeFromEnd(findElementFromEnd.Head, 2);

            Console.WriteLine(result.Value);


            #endregion
            Console.WriteLine("\r\n*****");
        }
        public static JabzLLNode<int> FindKthNodeFromEnd(JabzLLNode<int> start, int k)
        {
            JabzLLNode<int> P1 = start;
            int i = 1;
            while (i < k)
            {
                P1 = P1.Next;
                i++;
            }
            var P2 = start;
            while (P1.Next != null)
            {
                P1 = P1.Next;
                P2 = P2.Next;
            }

            return P2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    class FindMiddleElementInSinglePass
    {
        public static void Code()
        {

            #region Find Middle Element in a single pass
            //Solution - http://www.geeksforgeeks.org/write-a-c-function-to-print-the-middle-of-the-linked-list/

            JabzLinkedList<int> findMiddle = new JabzLinkedList<int>();

            for (int i = 1; i <= 25; i++)
            {
                findMiddle.Add(i);
            }

            var result = FindMiddleElement(findMiddle.Head);

            Console.WriteLine(result.Value);

            #endregion
            Console.WriteLine("\r\n*****");


        }


        public static JabzLLNode<int> FindMiddleElement(JabzLLNode<int> start)
        {
            var current = start;
            var middle = start;
            while (current != null)
            {
                if (current.Next != null
                    && current.Next.Next != null)
                {
                    current = current.Next.Next;
                    middle = middle.Next;
                }
                else
                    break;
            }
            return middle;
        }
    }
}

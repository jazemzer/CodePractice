using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    class ReverseCompleteList
    {
        public static void Code()
        {

            #region Reverse Linked list

            JabzLinkedList<int> reverseAll = new JabzLinkedList<int>();

            for (int i = 1; i <= 6; i++)
            {
                reverseAll.Add(i);
            }

            ReverseList(reverseAll);

            //Printing output
            for (JabzLLNode<int> item = reverseAll.Head; item != null; item = item.Next)
            {
                Console.Write(item.Value + " -> ");
            }
            #endregion
            Console.WriteLine("\r\n*****");

        }

        public static void ReverseList(JabzLinkedList<int> listToReverse)
        {
            JabzLLNode<int> prev2Prev = null;
            var prev = listToReverse.Head;
            var current = listToReverse.Head.Next;
            while (current != null)
            {
                prev.Next = prev2Prev;
                prev2Prev = prev;
                prev = current;
                current = current.Next;
            }
            prev.Next = prev2Prev;
            listToReverse.Head = prev;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    public class SwapKthNodeFromStartToEnd
    {
        public static void Implementation()
        {
            JabzLinkedList<int> myList = new JabzLinkedList<int>();

            for (int i = 1; i <= 9; i++)
            {
                myList.Add(i);
            }

            SwapNodes(myList, 5);

            //Printing output
            for (JabzLLNode<int> item = myList.Root; item != null; item = item.Next)
            {
                Console.Write(item.Value + " -> ");
            }
        }

        private static void SwapNodes(JabzLinkedList<int> list, int k)
        {
            if (list.Root == null)
                return;

            var P1 = list.Root;
            var P2 = list.Root;
            JabzLLNode<int> startPrev = null;
            JabzLLNode<int> start = null;
            JabzLLNode<int> endPrev = null;

            int loop = k;
            while (loop > 1)
            {
                if(P1.Next != null)
                {
                    if (loop == 2)
                    {
                        startPrev = P1;
                    }
                    P1 = P1.Next;
                }
                else
                {
                    throw new Exception("K is out of Range");
                }
                loop--;
            }
            start = P1;

            while(P1.Next != null)
            {
                P1 = P1.Next;
                endPrev = P2;
                P2 = P2.Next;
            }

            if(startPrev != null)
                startPrev.Next = P2;
            var temp = start.Next;
            start.Next = P2.Next;
            endPrev.Next = start;
            P2.Next = temp;

            if(k == 1)
            {
                list.Root = P2;
            }
            
        }
    }
}

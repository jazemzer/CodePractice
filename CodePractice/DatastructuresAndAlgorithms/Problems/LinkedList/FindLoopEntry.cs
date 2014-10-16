using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    class FindLoopEntry
    {
        public static void Code()
        {
            #region Find entry node of the loop
            /* If there is a loop in a linked list, how to get the entry node of the loop? 
             * The entry node is the first node in the loop from head of list. 
             * For instance, the entry node of loop in the list of Figure 1 is the node with value 3.
             */

   

            JabzLinkedList<int> loopInput = new JabzLinkedList<int>();

            Random rnd = new Random();
            int pick = rnd.Next(1, 25);

            JabzLLNode<int> loopStart = null;
            JabzLLNode<int> lastAddedNode = null;
            for (int i = 1; i <= 25; i++)
            {
                lastAddedNode = loopInput.Add(i);
                if (i == pick)
                {
                    loopStart = lastAddedNode;
                }
            }

            lastAddedNode.Next = loopStart;

            Console.WriteLine(pick);
            var result = FindLoopEntryNode(loopInput.Root);
            Console.WriteLine(result.Value);
            #endregion

        }
        public static JabzLLNode<int> FindLoopEntryNode(JabzLLNode<int> start)
        {
            var P1 = start;
            var P2 = start;

            JabzLLNode<int> entryNode = null;
            JabzLLNode<int> intersectNode = null;
            while (P1 != null)
            {
                if (P1.Next != null
                    && P1.Next.Next != null)
                {
                    P1 = P1.Next.Next;
                    P2 = P2.Next;

                    if (P1 == P2)
                    {
                        intersectNode = P1;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            int noOfElementsinLoop = 0;
            if (intersectNode != null)
            {
                do
                {
                    P2 = P2.Next;
                    noOfElementsinLoop++;
                } while (P1 != P2);

                var P3 = start;
                var P4 = start;

                while (noOfElementsinLoop > 0)
                {
                    P4 = P4.Next;
                    noOfElementsinLoop--;
                }

                do
                {
                    P3 = P3.Next;
                    P4 = P4.Next;
                } while (P3 != P4);

                entryNode = P3;
            }

            return entryNode;

        }

     
    }
}

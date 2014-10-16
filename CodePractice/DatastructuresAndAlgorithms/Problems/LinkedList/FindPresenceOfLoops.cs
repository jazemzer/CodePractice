using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    class FindPresenceOfLoops
    {
        public static void Code()
        {

            #region Find presence of Loops

            //Solution - http://codercareer.blogspot.in/2012/01/no-29-loop-in-list.html

            JabzLinkedList<int> skipReverse = new JabzLinkedList<int>();

            for (int i = 1; i <= 11; i++)
            {
                skipReverse.Add(i);
            }

            var hasloop = HasLoops(skipReverse.Root);
            Console.WriteLine(hasloop);

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


            hasloop = HasLoops(loopInput.Root);
            Console.WriteLine(hasloop);

            #endregion
            Console.WriteLine("\r\n*****");

        }

        public static bool HasLoops(JabzLLNode<int> start)
        {
            bool result = false;

            var P1 = start;
            var P2 = start;

            while (P2 != null)
            {
                if (P2.Next != null
                   && P2.Next.Next != null)
                {
                    P1 = P1.Next;
                    P2 = P2.Next.Next;

                    if (P1 == P2)
                    {
                        result = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

            }

            return result;
        }

    }
}

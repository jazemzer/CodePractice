using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    class SkipKElementsAndReverse
    {
        public static void Code()
        {
            #region Skip K elements and Reverse

            /* Given number k, for Single linked list, skip k nodes and then reverse k nodes, till the end.
             */

            //Hint - http://www.careercup.com/question?id=5838726617890816

            JabzLinkedList<int> skipReverse = new JabzLinkedList<int>();

            for (int i = 1; i <= 11; i++)
            {
                skipReverse.Add(i);
            }

            //SkipAndReverse(skipReverse.Root, 3);
            //SkipAndReverse2(skipReverse.Root, 3);
            SkipAndReverseRecursive(skipReverse.Root, 3, true);

            //Printing output
            for (JabzLLNode<int> item = skipReverse.Root; item != null; item = item.Next)
            {
                Console.Write(item.Value + " -> ");
            }

            #endregion
            Console.WriteLine("\r\n*****");

        }


        public static void SkipAndReverse2(JabzLLNode<int> start, int k)
        {
            JabzLLNode<int> current = start;
            bool isSkip = true;
            int i = 1;

            while (current != null)
            {
                if (isSkip)
                {
                    i = 1;
                    while (current != null && i < k) //The loop runs for K - 1 only so that the end item of skip iteration is held in current
                    {
                        current = current.Next;
                        i++;
                    }
                    isSkip = false;
                }
                else
                {
                    var nextStart = current.Next; //Start with the nK + 1 th item 
                    JabzLLNode<int> p = nextStart;
                    JabzLLNode<int> q = null;
                    JabzLLNode<int> r = null;

                    i = 1;
                    while (p != null && i <= k)
                    {
                        r = q;
                        q = p;
                        p = p.Next;
                        q.Next = r;
                        i++;
                    }

                    current.Next = q;
                    if (nextStart != null)
                        nextStart.Next = p;

                    current = p;

                    isSkip = true;
                }
            }
        }

        public static JabzLLNode<int> SkipAndReverseRecursive(JabzLLNode<int> start, int k, bool isSkip)
        {

            JabzLLNode<int> current = start;
            JabzLLNode<int> returnNode = start;
            JabzLLNode<int> currentTail = null; //CurrentTail and current refer to the same thing but here for readability 
            JabzLLNode<int> nextStart = null;
            int i = 1;

            if (current != null)
            {
                if (isSkip)
                {
                    i = 1;
                    while (current != null && i < k) //The loop runs for K - 1 only so that the end item of skip iteration is held in current
                    {
                        current = current.Next;
                        i++;
                    }
                    currentTail = current;
                    nextStart = current.Next;
                }
                else
                {
                    currentTail = current;
                    JabzLLNode<int> p = current;
                    JabzLLNode<int> q = null;
                    JabzLLNode<int> r = null;

                    i = 1;
                    while (p != null && i <= k)
                    {
                        r = q;
                        q = p;
                        p = p.Next;
                        q.Next = r;
                        i++;
                    }

                    returnNode = q;
                    nextStart = p;
                }
                if (currentTail != null)
                    currentTail.Next = SkipAndReverseRecursive(nextStart, k, !isSkip);
            }
            return returnNode;
        }
        public static void SkipAndReverse(JabzLLNode<int> start, int k)
        {
            JabzLLNode<int> temp = start;
            int i = 1;
            while (i < k)
            {
                temp = temp.Next;
                i++;
            }

            JabzLLNode<int> p = temp.Next;
            JabzLLNode<int> q = null;
            JabzLLNode<int> r = null;

            while (p != null)
            {
                r = q;
                q = p;
                p = p.Next;
                q.Next = r;
            }

            temp.Next = q;
        }
    }
}

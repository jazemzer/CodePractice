using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    public class ReverseEveryKElements
    {
        public static void Implementation()
        {

            JabzLinkedList<int> reverseAll = new JabzLinkedList<int>();

            for (int i = 1; i <= 8; i++)
            {
                reverseAll.Add(i);
            }


            reverseAll.Root = ReverseK(reverseAll.Root);

            //Printing output
            for (JabzLLNode<int> item = reverseAll.Root; item != null; item = item.Next)
            {
                Console.Write(item.Value + " -> ");
            }
        }

        private static JabzLLNode<int> ReverseK(JabzLLNode<int> root)
        {
            if(root == null)
            {
                return null;
            }

            var end = root;
            var p = root;
            JabzLLNode<int> p2p = null;
            var c = root.Next;

            var counter = 3;
            while(c != null && counter > 0)
            {
                p.Next = p2p;
                p2p = p;
                p = c;
                c = c.Next;
                counter--;
            }

            if (counter > 0)
            {
                end.Next = null;
                p.Next = p2p;
                return p;
            }
            else
            {
                end.Next = ReverseK(p);
            }
            return p2p;
        }
    }
}

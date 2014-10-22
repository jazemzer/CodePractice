using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    public class ReverseListUsingRecursion
    {
        public static void Implementation()
        {

            JabzLinkedList<int> reverseAll = new JabzLinkedList<int>();

            for (int i = 1; i <= 6; i++)
            {
                reverseAll.Add(i);
            }

            ReverseUsingRecursion(reverseAll.Root, reverseAll);

            //Printing output
            for (JabzLLNode<int> item = reverseAll.Root; item != null; item = item.Next)
            {
                Console.Write(item.Value + " -> ");
            }
        }

        private static JabzLLNode<int> ReverseUsingRecursion(JabzLLNode<int> node, JabzLinkedList<int> list)
        {
            if(node.Next != null)
            {
                var result = ReverseUsingRecursion(node.Next, list);
                result.Next = node;
                node.Next = null;
            }
            else
            {
                list.Root = node;
            }
            return node;
        }
    }
}

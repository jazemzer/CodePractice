using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks.BinarySearchTree
{
    public class CreateBSTFromSortedLinkedList
    {

        public static void Implementation()
        {
            LLNode head = new LLNode(1);
            LLNode curr = head;

            for(int i = 2; i < 11; i++)
            {
                curr.Next = new LLNode(i);
                curr = curr.Next;
            }


            Node root = null;
            PopulateBST(ref root, head, null);
        }

        /// <summary>
        ///     This is a nlogn solution
        /// </summary>
        /// <param name="node"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private static void PopulateBST(ref Node node, LLNode start, LLNode end)
        {
            LLNode prev = null;
            LLNode p1, p2;

            p1 = p2 = start;

            if (start == null)
                return;

            while (p2.Next != null
                    && p2.Next.Next != null
                    && p2 != end
                    && p2.Next != end)
            {
                prev = p1;
                p1 = p1.Next;
                p2 = p2.Next.Next;
            }

            node = new Node(p1.Data);

            if(prev != null)
                PopulateBST(ref node.Left, start, prev);

            if (start != end) //When there is only one element left
            {
                PopulateBST(ref node.Right, p1.Next, end);
            }

        }

        internal class LLNode
        {
            internal LLNode Next;
            internal int Data;

            internal LLNode(int d)
            {
                Data = d;
            }

        }
        internal class Node
        {
            internal Node Left;
            internal Node Right;
            internal int Data;

            internal Node(int d)
            {
                Data = d;

            }
        }
                
    }
}

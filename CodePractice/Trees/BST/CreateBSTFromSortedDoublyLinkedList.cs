using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks.BinarySearchTree
{
    public class CreateBSTFromSortedDoublyLinkedList
    {

        public static void Implementation()
        {
            Node root = null;

            //Construct doubly linked list

            DLLNode head = null;

            DLLNode temp = null;
            for(int i = 6; i > 0; i--)
            {
                temp = new DLLNode(i);
                temp.Next = head;
                if(head != null)    //For handling base condition
                {
                    head.Prev = temp;
                }
                head = temp;
            }

            PopulateBST(ref root, head, null);
        }

        private static void PopulateBST(ref Node node, DLLNode start, DLLNode end)
        {
            if (start == null)
                return;

            DLLNode p1, p2;
            p1 = p2 = start;

            while(p2 != null
                && p2.Next != null
                &&  p2.Next.Next != null
                && p2 != end
                && p2.Next != end)
            {
                p1 = p1.Next;
                p2 = p2.Next.Next;
            }

            node = new Node(p1.Data);

            if(p1 != start)
            {
                PopulateBST(ref node.Left, start, p1.Prev);
            }
            if(start != end)
            {
                PopulateBST(ref node.Right, p1.Next, end);
            }
        }

        internal class DLLNode
        {
            internal DLLNode Prev;
            internal DLLNode Next;
            internal int Data;

            internal DLLNode(int d)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks
{
    /// <summary>
    /// http://www.geeksforgeeks.org/reverse-level-order-traversal/
    /// </summary>
    public class ReverseLevelOrder
    {

        public static void Implementation()
        {
            Node root = new Node(4);
            root.Left = new Node(2);
            root.Right = new Node(7);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(3);
            root.Right.Right = new Node(8);
            root.Right.Left = new Node(5);
            root.Right.Right.Right = new Node(9);
            root.Right.Left.Right = new Node(6);

            //ReverseLevelOrderRightToLeft(root);

            ReverseLevelOrderLeftToRight(root);
        }

        private static void ReverseLevelOrderLeftToRight(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);

            Node temp = null;
            while (queue.Count > 0)
            {
                temp = queue.Dequeue();

               
                if (temp.Right != null)
                    queue.Enqueue(temp.Right);

                if (temp.Left != null)
                    queue.Enqueue(temp.Left);


                stack.Push(temp);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop().Data + " ");
            }
        }

        private static void ReverseLevelOrderRightToLeft(Node node)
        {
            Stack<Node> stack = new Stack<Node>();

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(node);

            Node temp = null;
            while(queue.Count > 0)
            {
                temp = queue.Dequeue();

                if (temp.Left != null)
                    queue.Enqueue(temp.Left);

                if (temp.Right != null)
                    queue.Enqueue(temp.Right);

                stack.Push(temp);
            }

            while(stack.Count > 0)
            {
                Console.Write(stack.Pop().Data + " " );
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks.BinaryTree
{
    /// <summary>
    /// http://www.geeksforgeeks.org/write-a-c-program-to-find-the-maximum-depth-or-height-of-a-tree/
    /// </summary>
    public class MaxDepthofBinaryTree
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

            Console.WriteLine(MaxDepth(root));
            Console.WriteLine(MaxDepthWithoutRecursion(root));
        }

        private static int MaxDepthWithoutRecursion(Node root)
        {
            if (root == null)
                return 0;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            int height = 0;

            Node temp = null;
            while(queue.Count > 0)
            {
                height++;

                var nodes = queue.Count;
                while(nodes > 0)
                {
                    temp = queue.Dequeue();
                    if (temp.Left != null)
                        queue.Enqueue(temp.Left);

                    if (temp.Right != null)
                        queue.Enqueue(temp.Right);

                    nodes--;
                }
            }

            return height;
        }
        private static int MaxDepth(Node node)
        {
            if (node == null)
                return 0;

            var left = MaxDepth(node.Left);
            var right = MaxDepth(node.Right);

            if (left > right)
                return left + 1;
            else
                return right + 1;
            
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

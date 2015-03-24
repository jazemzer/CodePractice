using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Trees.BinaryTree
{
    class SizeOfBinaryTree
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

            Console.WriteLine(SizeOfTree(root));

        }

        private static int SizeOfTree(Node node)
        {
            if (node == null)
                return 0;
            return SizeOfTree(node.Left) + SizeOfTree(node.Right) + 1;
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

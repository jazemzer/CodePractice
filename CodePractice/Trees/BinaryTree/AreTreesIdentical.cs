using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Trees.BinaryTree
{
    class AreTreesIdentical
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

            Node root1 = new Node(4);
            root1.Left = new Node(2);
            root1.Right = new Node(7);
            root1.Left.Left = new Node(1);
            root1.Left.Right = new Node(3);
            root1.Right.Right = new Node(8);
            root1.Right.Left = new Node(5);
            root1.Right.Right.Right = new Node(9);
            root1.Right.Left.Right = new Node(6);

            Console.WriteLine(CheckSimilarity(root, root1));
        }

        private static bool CheckSimilarity(Node node1, Node node2)
        {
            if (node1 == null && node2 == null)
                return true;

            if((node1 == null && node2 != null)
                || (node2 == null && node1 != null)
                || (node1.Data != node2.Data))
            {
                return false;
            }

            return CheckSimilarity(node1.Left, node2.Left)
                && CheckSimilarity(node1.Right, node2.Right);

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

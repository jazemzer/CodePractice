using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Trees.BinaryTree
{
    class MirrorATree
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

            InOrder(root);
            Console.WriteLine();

            Mirror(ref root);

            InOrder(root);
            Console.WriteLine();
        }

        private static void Mirror(ref Node node)
        {
            if (node == null)
                return;

            if (node.Left != null)
                Mirror(ref node.Left);

            if (node.Right != null)
                Mirror(ref node.Right);

            var temp = node.Right;
            node.Right = node.Left;
            node.Left = temp;
        }


        static void InOrder(Node node)
        {
            if (node == null)
                return;

            if (node.Left != null)
                InOrder(node.Left);

            Console.Write(node.Data + " ");

            if (node.Right != null)
                InOrder(node.Right);

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

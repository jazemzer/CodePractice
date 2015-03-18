using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Trees.BST
{
    class WidthOfBinaryTree
    {


        public static void Implementation()
        {

            Node root = null;
            DeserializeBST(ref root);

            Console.WriteLine(DiameterThroughRoot(root));

        }

        private static void DeserializeBST(ref Node node)
        {
            var temp = Console.ReadLine();

            if (string.IsNullOrEmpty(temp))
            {
                return;
            }

            if (temp != "TERM")
            {
                var data = Convert.ToInt32(temp);
                node = new Node(data);

                DeserializeBST(ref node.Left);
                DeserializeBST(ref node.Right);
            }
        }

        private static int DiameterThroughRoot(Node node)
        {
            if (node == null)
                return 0;
            return HeightOf(node.Left) + HeightOf(node.Right) + 1;
        }

        private static  int HeightOf(Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(HeightOf(node.Left), HeightOf(node.Right)) + 1;
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

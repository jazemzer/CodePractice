using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Trees.BinaryTree
{
    class SumOfAllLeftLeaves
    {

        public static void Implementation()
        {
            Node root = new Node(4);
            root.Left = new Node(2);
            root.Right = new Node(7);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(3);
            root.Right.Left = new Node(5);
            root.Right.Right = new Node(8);
            root.Right.Right.Left = new Node(9);
            root.Right.Left.Right = new Node(6);

            int sum = 0;            
            RecursiveSummer(root, ref sum);
        }

        private static void RecursiveSummer(Node node , ref int sum)
        {
            if(node.Left != null)                
            {
                if(node.Left.Left == null
                    && node.Left.Right == null)
                {
                    sum += node.Left.Data;
                }
                RecursiveSummer(node.Left, ref sum);
            }

            if(node.Right != null)
            {
                RecursiveSummer(node.Right, ref sum);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Trees.BinaryTree
{
    class PrintAllRootToLeafPaths
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
            root.Right.Right.Left = new Node(22);
            root.Right.Right.Right = new Node(9);
            root.Right.Left.Right = new Node(6);

            var output = new List<int>();
            PrintToLeaf(root, 0, output);
        }

        private static void PrintToLeaf(Node node, int index, List<int> output)
        {
            if (index < output.Count)
            {
                output[index] = node.Data;
            }
            else
            {
                output.Add(node.Data);
            }

            if (node.Left == null
                && node.Right == null)
            {
                for (int i = 0; i <= index; i++)
                {
                    Console.Write(output[i] + " ");
                }
                Console.WriteLine();
                return;
            }

            if(node.Left != null)
                PrintToLeaf(node.Left, index + 1, output);
            if (node.Right != null)
                PrintToLeaf(node.Right, index + 1, output);

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

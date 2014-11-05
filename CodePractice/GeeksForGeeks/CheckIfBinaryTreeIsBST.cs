using CodePractice.DatastructuresAndAlgorithms.Algorithms.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks
{
    /// <summary>
    /// http://www.geeksforgeeks.org/a-program-to-check-if-a-binary-tree-is-bst-or-not/
    /// http://leetcode.com/2010/09/determine-if-binary-tree-is-binary.html
    /// </summary>
    public class CheckIfBinaryTreeIsBST
    {
        public static void Implementation()
        {

            var tree = new BinaryTree<int>();
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(1);
            tree.Insert(3);


            Console.WriteLine(tree.IsBST());


            // Another simplified approach
            //Idea - Traverse down the tree keeping track of the narrowing min and max allowed values, looking at each node only once

            // Cant be used in generic fashion
            Node root = new Node(3);
            root.Left = new Node(2);
            root.Right = new Node(5);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(4);

            Console.WriteLine(IsBST(root, int.MinValue, int.MaxValue));
        }

        private static bool IsBST(Node node, int min, int max)
        {
            if (node == null)
                return true;

            if(node.Data > min
                && node.Data < max)
            {
                if (!IsBST(node.Left, min, node.Data))
                    return false;
                if (!IsBST(node.Right, node.Data, max))
                    return false;
            }
            else
            {
                return false;
            }

            return true;
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

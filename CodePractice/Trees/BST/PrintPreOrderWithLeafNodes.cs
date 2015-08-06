using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Trees.BST
{
    public class PrintPreOrderWithLeafNodes
    {

        //From a binary search tree the leaf nodes are removed to get another tree and then leaf nodes are removed from that tree also. 
        //The process is continued till all the nodes of the tree are removed.
        //Given a set of inputs where each line contains the leaf nodes removed in a iteration. 
        //Print the pre-order traversal of the binary tree.

        //For example:
        //BDHPY
        //CM
        //GQ
        //K

        //Output would be:
        //KGCBDHQMPY
        public static void Implementation()
        {
            List<string> input = new List<string>();

            string temp;
            while (!string.IsNullOrEmpty(temp = Console.ReadLine()))
            {
                input.Add(temp);
            }

            StringBuilder leftTree = new StringBuilder();
            StringBuilder rightTree = new StringBuilder();
            var root = input[input.Count - 1][0];
            for (int i = 0; i < input.Count - 1; i++)
            {
                foreach (char node in input[i].Reverse())
                {
                    if (node <= root)
                        leftTree.Insert(0, node);
                    else
                        rightTree.Insert(0, node);
                }
            }

            Console.WriteLine(leftTree.Insert(0, root).Append(rightTree));

            //TODO: Handle this scenario
            //AD
            //C
            //B
            //E
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

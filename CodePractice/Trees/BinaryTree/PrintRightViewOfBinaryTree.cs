using CodePractice.DatastructuresAndAlgorithms.Algorithms.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks
{
    /// <summary>
    /// http://www.geeksforgeeks.org/print-right-view-binary-tree-2/
    /// </summary>
    public class PrintRightViewOfBinaryTree
    {
        public static void Implementation()
        {
            var input = Enumerable.Range(1, 6).ToArray();

            var tree = new BinaryTree<int>();

            tree.Insert(25);
            tree.Insert(12);
            tree.Insert(40);
            tree.Insert(33);
            tree.Insert(21);

            for (int i = 1; i < 8; i++)
            {
                tree.Insert(i);
            }

            for (int i = 13; i < 15; i++)
            {
                tree.Insert(i);
            }

            for (int i = 34; i < 35; i++)
            {
                tree.Insert(i);
            }

            tree.PrintRightView(x => Console.WriteLine(x + " "));

        }
    }
}

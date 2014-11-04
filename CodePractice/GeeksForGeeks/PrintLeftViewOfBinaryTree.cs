using CodePractice.DatastructuresAndAlgorithms.Algorithms.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks
{
    /// <summary>
    /// http://www.geeksforgeeks.org/print-left-view-binary-tree/
    /// </summary>
    public class PrintLeftViewOfBinaryTree
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

            for (int i = 1; i < 5; i++)
            {
                tree.Insert(i);
            }

            for (int i = 13; i < 18; i++)
            {
                tree.Insert(i);
            }

            for (int i = 34; i < 37; i++)
            {
                tree.Insert(i);
            }

            tree.PrintLeftView(x => Console.Write(x + " "));

        }
    }
}

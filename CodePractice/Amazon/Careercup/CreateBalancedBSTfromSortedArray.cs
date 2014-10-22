using CodePractice.DatastructuresAndAlgorithms.Algorithms.Balanced_BST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Amazon.Careercup
{
    public class CreateBalancedBSTfromSortedArray
    {
        public static void Implementation()
        {
            //var input = new int[] { 1, 2, 3, 4, 5, 6 };

            //var input = new int[] { 6, 5,4 ,3, 2};
            var input = new int[] { 6, 10, 4, 8, 12, 2, 3, 5, 7, 9, 11, 13};
            var tree = new AATree<int, int>();
            foreach(var i in input)
            {
                tree.Insert(i, 45);
            }

            tree.TraverseInOrder((k, v) => Console.Write(k + " "));
            Console.WriteLine();
            tree.TraversePreOrder((k, v) => Console.Write(k + " "));
            Console.WriteLine();
            tree.TraversePostOrder((k, v) => Console.Write(k + " "));
            Console.WriteLine();

            Console.WriteLine(tree.Search(11));
            Console.WriteLine(tree.Max());
            Console.WriteLine(tree.Min());
        }
    }
}

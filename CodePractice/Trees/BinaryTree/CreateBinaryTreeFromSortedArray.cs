using CodePractice.DatastructuresAndAlgorithms.Algorithms.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Amazon.Careercup
{
    public class CreateBinaryTreeFromSortedArray
    {
        public static void Implementation()
        {
            int[] input = Enumerable.Range(1, 12).ToArray();
            var tree = new BinaryTree<int>(input, true);

            tree.Inorder(x => Console.Write(x + " "));
            tree.LevelOrder(x => Console.Write(x + " "));

            Console.WriteLine(" Level order zig zag");
            tree.LevelOrderZigZag(x => Console.Write(x + " "));

            
            Console.Read();
        }

        
    }
}

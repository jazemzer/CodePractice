using CodePractice.DatastructuresAndAlgorithms.Algorithms.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BinaryTree.Traversal
{
    //Print a binary tree in zig zag way... that is: 
    //......a......... 
    //....b....c....... 
    //..d...e...f...g.. 
    //.h.i.j.k.l.m.n.o. 

    //should be printed as a-c-b-d-e-f-g-o-n-m-l-k-j-i-h 

    /// <summary>
    /// http://www.careercup.com/question?id=57945
    /// </summary>
    public class BinaryTreeZigZagLevelOrder
    {
        public static void Implementation()
        {
            char[] input = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i','j', 'k', 'l', 'm', 'n', 'o' };
            var tree = new BinaryTree<char>(input);

            tree.LevelOrderZigZag(x => Console.Write(x + " "));


            Console.Read();
        }
    }
}

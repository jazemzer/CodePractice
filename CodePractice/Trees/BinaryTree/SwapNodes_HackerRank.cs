using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Input
//11
//2 3
//4 -1
//5 -1
//6 -1
//7 8
//-1 9
//-1 -1
//10 11
//-1 -1
//-1 -1
//-1 -1
//2
//2
//4

namespace CodePractice.Trees.BinaryTree
{
    class SwapNodes_HackerRank
    {


        public static void Implementation()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            var nodeArray = new Node[N + 1];

            //Discarding zeroth index for practical purposes
            var root = nodeArray[1] = new Node(1);
            Node current = null;
            for(int i = 1; i <= N; i++)
            {
                current = nodeArray[i];

                var children =  Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
                if(children[0] != -1)
                {
                    current.Left = nodeArray[children[0]] = new Node(children[0]);
                }

                if (children[1] != -1)
                {
                    current.Right = nodeArray[children[1]] = new Node(children[1]);
                }
            }

            int T = Convert.ToInt32(Console.ReadLine());
            while(T > 0)
            {
                int K = Convert.ToInt32(Console.ReadLine());

                var i = 1;
                while ((K * i) <= N)
                {
                    FindNodesAt(root, 1, K * i, SwapChildren);
                    i++;

                    
                }

                InOrderTraversal(root, d => Console.Write(d.Data + " "));
                Console.WriteLine();

                T--;
            }


        }

        private static void SwapChildren(Node current)
        {
            var temp = current.Left;
            current.Left = current.Right;
            current.Right = temp;
        }

        private static void FindNodesAt(Node current, int currentLevel, int requestedLevel, Action<Node> swapAction)
        {
            if (current == null)
                return;

            if(currentLevel == requestedLevel)
            {
                swapAction(current);
                return;
            }

            FindNodesAt(current.Left, currentLevel + 1, requestedLevel, swapAction);
            FindNodesAt(current.Right, currentLevel + 1, requestedLevel, swapAction);
        }


        private static void InOrderTraversal(Node current, Action<Node> action)
        {
            if (current != null)
            {
                InOrderTraversal(current.Left, action);
                action(current);
                InOrderTraversal(current.Right, action);
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

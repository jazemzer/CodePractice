using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Algorithms.BinaryTree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private Node root;
        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(T[] input, bool issorted = false)
        {
            if (!issorted)
            {
                root = new Node();

                Node current = root;
                int index = 0;

                var queue = new Queue<Node>();
                current.Data = input[index];
                queue.Enqueue(current);

                while(queue.Count > 0 )
                {
                    current = queue.Dequeue();
                    if (index + 1 >= input.Length)
                        break;
                    current.Left = new Node() { Data = input[++index] };
                    queue.Enqueue(current.Left);

                    if (index + 1 >= input.Length)
                        break;
                    current.Right = new Node() { Data = input[++index] };
                    queue.Enqueue(current.Right);

                }

            }
            else
            {
                int left, right, middle;
                left = 0;
                right = input.Length - 1;

                root = Populate(input, left, right);
            }
        }

        private Node Populate(T[] input, int left, int right)
        {
            if (left > right)
                return null;

            int middle = left + ((right - left) / 2);
            var node = new Node();
            node.Data = input[middle];

            node.Left = Populate(input, left, middle - 1);
            node.Right = Populate(input, middle + 1, right);

            return node;
            
        }

        public void LevelOrderZigZag(Action<T> printAction)
        {
            LevelOrderZigZag(root, printAction);
        }

        /// <summary>
        /// http://www.geeksforgeeks.org/level-order-traversal-in-spiral-form/
        /// </summary>
        /// <param name="node"></param>
        /// <param name="printAction"></param>
        private void LevelOrderZigZag(Node node, Action<T> printAction)
        {
            if (node == null)
                return;

            var fromRight = new Stack<Node>();
            var fromLeft = new Stack<Node>();

            fromLeft.Push(node);

            while(fromRight.Count != 0
                || fromLeft.Count != 0)
            {
                while(fromRight.Count != 0)
                {
                    var current = fromRight.Pop();
                    printAction(current.Data);

                    if (current.Right != null)
                        fromLeft.Push(current.Right);

                    if (current.Left != null)
                        fromLeft.Push(current.Left);
                }

                while (fromLeft.Count != 0)
                {
                    var current = fromLeft.Pop();
                    printAction(current.Data);

                    if (current.Left != null)
                        fromRight.Push(current.Left);

                    if (current.Right != null)
                        fromRight.Push(current.Right);

                   
                }
            }
        }


        public void LevelOrder(Action<T> printAction)
        {
            LevelOrder(root, printAction);
        }

        /// <summary>
        /// http://www.geeksforgeeks.org/level-order-tree-traversal/
        /// </summary>
        /// <param name="node"></param>
        /// <param name="printAction"></param>
        private void LevelOrder(Node node, Action<T> printAction)
        {
            if (node == null)
                return;

            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while(queue.Count > 0)
            {
                Node current = queue.Dequeue();
                printAction(current.Data);
                
                if(current.Left != null)
                    queue.Enqueue(current.Left);

                if(current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }

        public void Inorder(Action<T> printAction)
        {
            PrintInorder(root, printAction);
        }

        private void PrintInorder(Node node, Action<T> printAction)
        {
            if (node == null)
                return;

            PrintInorder(node.Left, printAction);
            printAction(node.Data);
            PrintInorder(node.Right, printAction);
        }

        internal class Node
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
    }

   
}

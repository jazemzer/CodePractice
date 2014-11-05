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

        public bool IsBST()
        {
            Node prev = new Node(default(T));
            return IsBSTUtil(root, ref prev);
        }

        private bool IsBSTUtil(Node node, ref Node prev)
        {
            if(node == null)
            {
                return true;
            }

            if (!IsBSTUtil(node.Left, ref prev))
                return false;

            if(node.Data.CompareTo(prev.Data) > 0)
            {
                prev = node;

                if (!IsBSTUtil(node.Right, ref prev))
                    return false;
            }
            else
            {
                return false;
            }
            return true;
        }
        public void PrintLeftView(Action<T> printAction)
        {
            int visitedLevel = 0;
            PrintLeftView(root, 1, ref visitedLevel, printAction);
        }

        private void PrintLeftView(Node node, int level, ref int visitedLevel, Action<T> printAction)
        {
            if (node == null)
                return; 

            if(level > visitedLevel)
            {
                printAction(node.Data);
                visitedLevel = level;
            }

            PrintLeftView(node.Left, level + 1, ref visitedLevel, printAction);
            PrintLeftView(node.Right, level + 1, ref visitedLevel, printAction);
        }

        public void PrintRightView(Action<T> printAction)
        {
            int visited = 0;
            PrintRightView(root, 1, ref visited, printAction);
        }

        private void PrintRightView(Node node, int level, ref int visitedLevel, Action<T> printAction)
        {
            if (node == null)
                return;

            if(level > visitedLevel)
            {
                printAction(node.Data);
                visitedLevel = level;
            }

            PrintRightView(node.Right, level + 1, ref visitedLevel, printAction);
            PrintRightView(node.Left, level + 1, ref visitedLevel, printAction);
        }

        public bool Insert(T data)
        {
            return Insert(ref root, data);
        }

        private bool Insert(ref Node node, T data)
        {
            if (node == null)
            {
                node = new Node(data);
                return true;
            }

            int compare = data.CompareTo(node.Data);
            if (compare == 0)
            {
                // Same key present
                return false;
            }
            else if(compare < 0)
            {
                return Insert(ref node.Left, data);
            }
            else
            {
                return Insert(ref node.Right, data);
            }
        }

        public BinaryTree(T[] input, bool issorted = false)
        {
            if (!issorted)
            {
                int index = 0;

                root = new Node(input[index]);

                Node current = root;

                var queue = new Queue<Node>();
                queue.Enqueue(current);

                while(queue.Count > 0 )
                {
                    current = queue.Dequeue();
                    if (index + 1 >= input.Length)
                        break;
                    current.Left = new Node(input[++index]);
                    queue.Enqueue(current.Left);

                    if (index + 1 >= input.Length)
                        break;
                    current.Right = new Node(input[++index]);
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
            var node = new Node(input[middle]);

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
            internal T Data;
            internal Node Left;
            internal Node Right;

          
            internal Node(T data)
            {
                Data = data;
                Left = Right = null;
            }
        }
    }

   
}

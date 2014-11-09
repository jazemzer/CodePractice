using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks.BinaryTree
{
    public class BinaryTreeTraversalWithoutRecursion
    {

        public static void Implementation()
        {
            Node root = new Node(4);
            root.Left = new Node(2);
            root.Right = new Node(7);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(3);
            root.Right.Right = new Node(8);
            root.Right.Left = new Node(5);
            root.Right.Right.Right = new Node(9);
            root.Right.Left.Right = new Node(6);

            InOrder(root);

            Console.WriteLine();
            //PostOrderRecursion(root);
            PreOrer(root);
            Console.WriteLine();

            PostOrder(root);
        }

        private static void PostOrder(Node root)
        {
            var stack = new Stack<Node>();

            Node current = root;

            while(true)
            {
                while(current != null)
                {
                    stack.Push(current);
                    current = current.Left; // != null ? current.Left : current.Right;
                }

                if (stack.Count > 0)
                {
                    while(stack.Count > 0)
                    {
                        var prev = stack.Pop();
                        Console.Write(prev.Data + " ");

                        if (stack.Count > 0)
                        {
                            current = stack.Peek().Right;

                            if (current != prev)
                            {
                                break;
                            }
                        }
                        else
                            break;
                    }
                }
                else
                    break;
            }
        }
        private static void PostOrderRecursion(Node node)
        {
            if (node == null)
                return;

            PostOrderRecursion(node.Left);
            PostOrderRecursion(node.Right);

            Console.Write(node.Data + " ");

        }
        private static void PreOrer(Node root)
        {
            var stack = new Stack<Node>();

            Node current = root;
            while(true)
            {

                while(current != null)
                {
                    Console.Write(current.Data + " ");
                    stack.Push(current);
                    current = current.Left;
                }

                if(stack.Count > 0)
                {
                    current = stack.Pop().Right;
                }
                else
                {
                    break;
                }
            }
        }

        private static void InOrder(Node root)
        {
            var stack = new Stack<Node>();

            Node current = root;
            while(true)
            {
                while(current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                if(stack.Count > 0)
                {
                    var topElement = stack.Pop();
                    Console.Write(topElement.Data + " ");

                    current = topElement.Right;
                }
                else
                {
                    //End when stack is empty
                    break;
                }
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

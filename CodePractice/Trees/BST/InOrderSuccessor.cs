using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Trees.BST
{
    class InOrderSuccessor
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


            FindPredecessor(root, 7);
        }

        private static Node found = null;
        private static Node successor = null;

        private static bool FindPredecessor(Node node, int key)
        {
            if (node == null)
            {
                return found != null;
            }

            if (key > node.Data)
            {
                if (!FindPredecessor(node.Right, key))
                    return false;
            }
            else
            {
                if (key == node.Data)
                {
                    found = node;
                }

                if (!FindPredecessor(node.Left, key))
                    return false;
            }

            if (found != null)
            {
                successor = node;

                found = null;
            }

            return true;
        }

        private static bool FindSuccessor(Node node, int key)
        {
            if(node == null)
            {
                return found != null;
            }

            if(key < node.Data)
            {
                if (!FindSuccessor(node.Left, key))
                    return false;
            }
            else
            {
                if(key == node.Data)
                {
                    found = node;
                }

                if (!FindSuccessor(node.Right, key))
                    return false;
            }

            if(found != null)
            {
                successor = node;

                found = null;
            }

            return true;
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

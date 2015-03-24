using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Trees.BST
{
    class InsertSearchAndDeletion
    {

        public static void Implementation()
        {
            Node root = new Node(4);
            root.Left = new Node(2);
            root.Right = new Node(7);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(3);
            root.Right.Right = new Node(10);
            root.Right.Left = new Node(5);
            root.Right.Right.Left = new Node(8);
            root.Right.Right.Right = new Node(12);
            root.Right.Left.Right = new Node(6);


            InOrder(root);
            Console.WriteLine();

            Console.WriteLine(Search(root, 5)== null);
            Console.WriteLine(Search(root, 15) == null);

            Insert(ref root, 15);
            InOrder(root);
            Console.WriteLine();

            Delete(ref root, 7);
            InOrder(root);
            Console.WriteLine();
        }
        static Node ToBeDeleted = null;
        static bool Delete(ref Node node, int key)
        {
            if (node == null)
                return ToBeDeleted != null; 

            if (key < node.Data)
            {
                if (!Delete(ref node.Left, key))
                    return false;
            }
            else
            {
                if (key == node.Data)
                {
                    ToBeDeleted = node;
                }

                if (!Delete(ref node.Right, key))
                    return false;
            }

            if(ToBeDeleted != null)
            {
                //Copy data
                ToBeDeleted.Data = node.Data;

                node = node.Right;

                ToBeDeleted = null;
            }

            return true;

        }

        static void InOrder(Node node)
        {
            if (node == null)
                return;

            if (node.Left != null)
                InOrder(node.Left);

            Console.Write(node.Data + " ");

            if (node.Right != null)
                InOrder(node.Right);

        }

        static bool Insert(ref Node root, int key)
        {
            if (root == null)    //Means element is already present
            {
                root = new Node(key);
                return true;
            }

            if (root.Data == key)
                return false;

            if (key < root.Data)
                return Insert(ref root.Left, key);

            return Insert(ref root.Right, key);

        }


        static Node Search(Node node, int key)
        {
            if (node == null || node.Data == key)
                return node;

            if (key < node.Data)
                return Search(node.Left, key);

            return Search(node.Right, key);

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

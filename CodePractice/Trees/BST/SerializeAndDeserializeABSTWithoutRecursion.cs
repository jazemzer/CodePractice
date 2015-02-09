using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks
{

    /// <summary>
    /// http://www.geeksforgeeks.org/construct-bst-from-given-preorder-traversal-set-2/
    /// </summary>
    public class SerializeAndDeserializeABSTWithoutRecursion
    {
        public static void Implementation()
        {
            Node root = new Node(4);
            root.Left = new Node(2);
            root.Right = new Node(7);
            root.Left.Left = new Node(1);
            //root.Left.Left.Left = new Node(int.MinValue);
            root.Left.Right = new Node(3);
            root.Right.Right = new Node(8);
            root.Right.Left = new Node(5);
            root.Right.Right.Right = new Node(9);
            root.Right.Left.Right = new Node(6);

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            PreOrderSerialization(root, ref writer);
            writer.Flush();

            stream.Position = 0;

            var reader = new StreamReader(stream);
            var serialized = reader.ReadToEnd();

            stream.Position = 0;
            var dsr = new StreamReader(stream);
            Node newRoot = DeserializeBST(dsr);

        }

        private static Node DeserializeBST(StreamReader reader)
        {
            if (reader == null
                || reader.Peek() < 0)
                return null;

            var data = Convert.ToInt32(((char)reader.Read()).ToString());

            Node root = new Node(data);
            Stack<Node> stack = new Stack<Node>();

            stack.Push(root);

            Node temp = null;
            Node parent = null;
            while(reader.Peek() >= 0)
            {
                data = Convert.ToInt32(((char)reader.Read()).ToString());
                temp = null;
                parent = null;
                while (stack.Count > 0)
                {
                    temp = stack.Peek();
                    if(temp != null
                        && temp.Data < data)
                    {
                        parent = stack.Pop();
                    }
                    else
                    {
                        break;
                    }
                }

                if(parent != null)
                {
                    var newNode = new Node(data); 
                    parent.Right = newNode;
                    stack.Push(newNode);
                }
                else
                {
                    parent = stack.Peek();
                    var newNode = new Node(data); 
                    parent.Left = newNode;
                    stack.Push(newNode);
                }
                    
            }
            return root;
        }

        private static void PreOrderSerialization(Node node, ref StreamWriter writer)
        {
            if (node == null)
                return;
            writer.Write(node.Data);
            PreOrderSerialization(node.Left, ref writer);
            PreOrderSerialization(node.Right, ref writer);
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

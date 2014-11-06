using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks
{
    /// <summary>
    /// Serialization 
    ///         http://leetcode.com/2010/09/saving-binary-search-tree-to-file.html
    /// Deserialization
    ///         http://www.geeksforgeeks.org/construct-bst-from-given-preorder-traversa/
    /// 
    /// </summary>
    public class SerializeAndDeserializeABST
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
            Node newRoot = null;

            DeserializeBST(ref newRoot, int.MinValue, int.MaxValue, dsr);

        }

        private static void DeserializeBST(ref Node node, int min, int max, StreamReader reader)
        {
            if (reader == null
                || reader.Peek() < 0)
                return;

            var data =  Convert.ToInt32(((char)reader.Peek()).ToString());

            if(data > min && data < max)
            {
                node = new Node(data);
                reader.Read();
                DeserializeBST(ref node.Left, min, data, reader);
                DeserializeBST(ref node.Right, data, max, reader);
            }
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

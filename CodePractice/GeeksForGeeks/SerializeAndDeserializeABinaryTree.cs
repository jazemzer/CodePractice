using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodePractice.GeeksForGeeks
{
    /// <summary>
    /// http://www.geeksforgeeks.org/serialize-deserialize-binary-tree/
    /// http://www.cs.usfca.edu/~brooks/S04classes/cs245/lectures/lecture11.pdf
    /// 
    /// http://leetcode.com/2010/09/serializationdeserialization-of-binary.html
    /// </summary>
    public class SerializeAndDeserializeABinaryTree
    {
        public static void Implementation()
        {
            Node root = new Node(4);
            root.Left = new Node(2);
            root.Right = new Node(5);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(3);
            root.Right.Right = new Node(8);
            root.Right.Right.Left = new Node(7);


            
            var stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            SerializeTree(root, ref writer);

            // The string is currently stored in the 
            // StreamWriters buffer. Flushing the stream will 
            // force the string into the MemoryStream.
            writer.Flush();

            // If we dispose the StreamWriter now, it will close 
            // the BaseStream (which is our MemoryStream) which 
            // will prevent us from reading from our MemoryStream
            //DON'T DO THIS - sw.Dispose();

            // The StreamReader will read from the current 
            // position of the MemoryStream which is currently 
            // set at the end of the string we just wrote to it. 
            // We need to set the position to 0 in order to read 
            // from the beginning.
            stream.Position = 0;
            var sr = new StreamReader(stream);
            Console.WriteLine("Serialized stream : " + sr.ReadToEnd());

            Node newRoot = null;
            stream.Position = 0;
            var dsr = new StreamReader(stream);
            DeSerializeTree(ref newRoot, dsr);
        }

        private static void DeSerializeTree(ref Node node, StreamReader reader)
        {
            if (reader == null
                || reader.Peek() < 0)
                return;

            var character = (char)reader.Read();
            if(character == '#')
                return;
            else
            {
                node = new Node(Convert.ToInt32(character.ToString()));
                DeSerializeTree(ref node.Left, reader);
                DeSerializeTree(ref node.Right, reader);
            }

        }
        private static void SerializeTree(Node node, ref StreamWriter writer)
        {
            if(node == null)
            {
                writer.Write("#");
                return;
            }

            writer.Write(node.Data);
            SerializeTree(node.Left, ref writer);
            SerializeTree(node.Right, ref writer);
        }

        private static void OptimizedSerializeTree(Node node, ref StreamWriter writer)
        {
            if (node == null)
            {
                return;
            }

            writer.Write(node.Data);
            if (node.Left == null && node.Right == null)
            {
                return;
            }

            if(node.Left != null 
                && node.Right != null)
            {
                writer.Write("~");
            }

            if (node.Left == null)
            {
                writer.Write("#");
            }
            else
            {
                OptimizedSerializeTree(node.Left, ref writer);
            }

            if (node.Right == null)
            {
                writer.Write("#");
            }
            else
            {
                OptimizedSerializeTree(node.Right, ref writer);
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

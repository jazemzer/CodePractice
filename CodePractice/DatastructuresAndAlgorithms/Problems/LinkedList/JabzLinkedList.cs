using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    public class JabzLinkedList<T>
    {
        public JabzLLNode<T> Root { get; set; }
        public JabzLLNode<T> Last
        {
            get
            {
                var current = Root;
                if (current == null)
                {
                    return null;
                }
                while (current.Next != null) //The above if loop exists becasue of the condition within while
                {
                    current = current.Next;
                }
                return current;
            }
        }

        public JabzLLNode<T> Add(T data)
        {
            JabzLLNode<T> newNode = new JabzLLNode<T>();
            newNode.Value = data;

            if (Root == null)
                Root = newNode;
            else
                Last.Next = newNode;
            return newNode;
        }

        public void Delete(JabzLLNode<T> node)
        {
            if (Root == node)
            {
                Root = node.Next;
                node.Next = null;
            }
            else
            {
                JabzLLNode<T> current = Root;
                while (current != null)
                {
                    if (current.Next == node)
                    {
                        current.Next = node.Next;
                        node.Next = null;
                        break;
                    }
                    current = current.Next;
                }
            }
        }
    }

    public class JabzLLNode<T>
    {
        public JabzLLNode<T> Next { get; set; }
        public T Value { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Algorithms.LinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public T Data { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }

        public DoublyLinkedListNode(T data)
        {
            Data = data;
        }
    }
    
    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;
        private DoublyLinkedListNode<T> tail;
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        public void Insert(T data)
        {
            var newNode = new DoublyLinkedListNode<T>(data);

            if(head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;

                tail = newNode;
            }
        }

        public void Reverse()
        {
            tail = head;

            DoublyLinkedListNode<T> tempPrev = null;
            var tempCurr = head;
            while (tempCurr != null)
            {
                tempCurr.Prev = tempCurr.Next;
                tempCurr.Next = tempPrev;

                tempPrev = tempCurr;
                tempCurr = tempCurr.Prev;
            }

            head = tempPrev;
        }

        public void TraverseAndPrint()
        {
            var temp = head;
            while(temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }


    }
}

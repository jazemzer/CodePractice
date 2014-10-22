using CodePractice.DatastructuresAndAlgorithms.Algorithms.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Amazon.Careercup
{
    public class ReverseDoublyLinkedList
    {
        public static void Implementation()
        {
            var dll = new DoublyLinkedList<int>();

            dll.Insert(1);
            dll.Insert(2);
            dll.Insert(3);
            dll.Insert(4);
            dll.Insert(5);
            dll.Insert(6);

            //dll.TraverseAndPrint();

            dll.Reverse();

            Console.WriteLine("***************");
            dll.TraverseAndPrint();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList;

namespace CodePractice.LinkedList
{
    public class AddingTwoLists
    {

        public static void Implementation()
        {
            var A = new int[] { 9, 2, 3 , 4};
            var B = new int[] { 9, 0, 1 };

            var inputA = new JabzLinkedList<int>();
            for (int i = 0; i < A.Length; i++)
            {
                inputA.Add(A[i]);
            }

            var inputB = new JabzLinkedList<int>();
            for (int i = 0; i < B.Length; i++)
            {
                inputB.Add(B[i]);
            }


            #region Adjusting lengths
            var pointerA = inputA.Head;
            var pointerB = inputB.Head;

            while (pointerA != null
                || pointerB != null)
            {
                if(pointerA == null)
                {
                    // Add a dummy node at head
                    var temp = inputA.Head;
                    inputA.Head = new JabzLLNode<int>();
                    inputA.Head.Next = temp;
                }
                else if (pointerB == null)
                {
                    // Add a dummy node at head
                    var temp = inputB.Head;
                    inputB.Head = new JabzLLNode<int>();
                    inputB.Head.Next = temp;
                }

                pointerA = pointerA != null ? pointerA.Next : null;
                pointerB = pointerB != null ? pointerB.Next : null;
            }

            #endregion

            JabzLinkedList<int> result = null;



            var carry = WithRecursion(inputA.Head, inputB.Head, ref result);

            if (carry > 0)
                result.Add(carry);

            ReverseList(result);
            result.Print();

            //Without recursion
            result = null;
            result = WithoutRecusion(inputA, inputB);
            result.Print();

          

        }

        private static int WithRecursion(JabzLLNode<int> pointerA, JabzLLNode<int> pointerB, ref JabzLinkedList<int> result)
        {
            //Checking one list is sufficient as the other list is of the same length
            if (pointerA == null)
            {
                result = new JabzLinkedList<int>();
                return 0;
            }

            var carry = WithRecursion(pointerA.Next, pointerB.Next, ref result);
            var sum = (pointerA != null ? pointerA.Value : 0) + (pointerB != null ? pointerB.Value : 0) + carry;

            if (sum > 9)
            {
                sum %= 10;
                carry = 1;
            }
            else
                carry = 0;

            result.Add(sum);
            return carry;

        }
        private static JabzLinkedList<int> WithoutRecusion(JabzLinkedList<int> inputA, JabzLinkedList<int> inputB)
        {

            ReverseList(inputA);
            ReverseList(inputB);

            var pointerA = inputA.Head;
            var pointerB = inputB.Head;

            int sum = 0, carry = 0;
            var result = new JabzLinkedList<int>();
            while (pointerA != null
                || pointerB != null)
            {
                sum = (pointerA != null ? pointerA.Value : 0) + (pointerB != null ? pointerB.Value : 0) + carry;
                if (sum > 9)
                {
                    sum %= 10;
                    carry = 1;
                }
                else
                    carry = 0;

                result.Add(sum);
                pointerA = pointerA != null ? pointerA.Next : null;
                pointerB = pointerB != null ? pointerB.Next : null;
            }

            if (carry > 0)
            {
                result.Add(carry);
            }

            ReverseList(result);

            return result;
            
        }

        private static void ReverseList(JabzLinkedList<int> list)
        {
            JabzLLNode<int> current = list.Head;
            JabzLLNode<int> temp = null;
            JabzLLNode<int> prev = null;

            while (current != null)
            {
                temp = current.Next;
                current.Next = prev;
                prev = current;

                current = temp;
            }

            list.Head = prev;
        }
                
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList
{
    class CheckPalindrome
    {
        public static void Code()
        {

            #region Check Palindrome or not
            //Question - http://basicalgos.blogspot.in/2012/06/58-linked-list-related-questions.html

            List<string> inputset = new List<string>()
            {
                "malayalam",
                "aviddiva",
                "unnk",
                "testinpu"
            };
            foreach (var palindrome in inputset)
            {
                JabzLinkedList<char> palindromeList = new JabzLinkedList<char>();
                foreach (var s in palindrome)
                {
                    palindromeList.Add(s);
                }

                bool isPalindrome = CheckPalindromeList(palindromeList.Root);

                Console.WriteLine(string.Format("{0} : {1}", palindrome, isPalindrome));
            }

            #endregion
            Console.WriteLine("\r\n*****");

        }

        public static bool CheckPalindromeList(JabzLLNode<char> start)
        {
            bool result = true;

            #region Finding Middle element

            var P1 = start;
            var P2 = start;
            bool isOdd = false;
            while (P2 != null)
            {
                if (P2.Next != null)
                {
                    if (P2.Next.Next != null)
                    {
                        P2 = P2.Next.Next;
                        P1 = P1.Next;
                    }
                    else
                    {
                        isOdd = false;
                        break;
                    }
                }
                else
                {
                    isOdd = true;
                    break;
                }
            }
            #endregion

            var middle = P1.Next;

            JabzLLNode<char> prev2prev = null;
            var prev = middle;
            var curr = middle.Next;

            while (curr != null)
            {
                prev.Next = prev2prev;
                prev2prev = prev;
                prev = curr;
                curr = curr.Next;
            }
            prev.Next = prev2prev;

            var lefttHalf = start;
            var reversedRightHalf = prev;

            for (; reversedRightHalf != null; reversedRightHalf = reversedRightHalf.Next, lefttHalf = lefttHalf.Next)
            {
                if (lefttHalf.Value != reversedRightHalf.Value)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

    }
}

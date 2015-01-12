using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    /// <summary>
    ///     EPI - Reverse words in a sentence with O(1) space. Eg., 'Alice likes Bob' to 'Bob likes Alice' 
    /// </summary>
    class ReverseWordsInSentence
    {

        public static void Implementation()
        {

            Console.WriteLine(Logic("Alice likes Bob"));
        }

        public static unsafe string Logic(string input)
        {
            Reverse(input);

            fixed (char* start = input)
            {
                char* left = start;
                char* right = start;
                char* end = start + (input.Length - 1);

                while (right <= end)
                {
                    if (*right == ' ')
                    {
                        PointReversal(left, right - 1);
                        left = right + 1;
                    }
                    right += 1;
                }

                PointReversal(left, right-1);

            }

            return input;
        }

        public static string Reverse(string phrase)
        {
            unsafe
            {
                fixed(char* start = phrase)
                {
                    char* left = start;
                    char* right = start + (phrase.Length - 1);
                    PointReversal(left, right);
                }
            }
            return phrase;
        }

        public static unsafe void PointReversal(char* left, char* right)
        {
            char temp = ' ';
            while (left < right)
            {
                temp = *right;
                *right = *left;
                *left = temp;

                left += 1;
                right -= 1;
            }
        }
    }
}

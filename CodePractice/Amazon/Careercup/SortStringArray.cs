using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Amazon.Careercup
{
    public class SortStringArray
    {
        /// <summary>
        /// Suppose we are given an array of strings over some finite alphabet(say the letters a to z). 
        /// Each string can have a different number of characters, but the total number of characters in all the strings is n. 
        /// Show how to sort the strings in alphabetical order in O(n) time.
        /// http://www.careercup.com/question?id=5699965263282176
        ///  </summary>
        public static void Code()
        {
            // Use Radix Sort - MSD

            var input = new List<string>()
            {
                "za",
                "Zasd",
                "a",
                "aa",
                "bsdfsda",
                "bsdw",
                "bsda",
                "AA"
            };

            var finalBucket = new Queue<string>[26];
            var tempBucket = new Queue<string>[26];

            for (int i = 0; i < 26; i++)
            {
                tempBucket[i] = new Queue<string>();
                finalBucket[i] = new Queue<string>();
            }

            var characterPosition = 0;
            var end = input.Count;
            var index = 0;
            int charValue = 0;
            var tempInput = string.Empty;

            while (true)
            {
                var areItemsLeft = false;
                for (int i = 0; i < end; i++)
                {
                    tempInput = input[i];

                    if (characterPosition >= tempInput.Length)
                    {
                        charValue = tempInput[0];
                        charValue = charValue > 96 ? charValue - 97 : charValue - 65;
                        finalBucket[charValue].Enqueue(tempInput);
                    }
                    else
                    {
                        areItemsLeft = true;
                        charValue = tempInput[characterPosition];
                        // A - 65 Z - 90                
                        // a- 97 z - 122
                        charValue = charValue > 96 ? charValue - 97 : charValue - 65;
                        tempBucket[charValue].Enqueue(tempInput);
                    }
                }

                //Breaking condition
                if (!areItemsLeft)
                {
                    break;
                }


                index = 0;

                foreach (var queue in tempBucket)
                {
                    while (queue.Count > 0)
                    {
                        input[index++] = queue.Dequeue();
                    }
                }

                end = index;
                characterPosition++;
            }

            // Printing output from final bucket
            index = 0;
            foreach (var bucket in finalBucket)
            {
                while (bucket.Count > 0)
                {
                    input[index ++] = bucket.Dequeue();
                }
            }

            Console.ReadLine();
        }
                
    }
}

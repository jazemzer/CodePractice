using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class RadixSort
    {
        public static void Implementation()
        {
            int[] input = new[] { 46, 2, 1000, 345,237, 4, };

            //NumberSort(input);

            string[] inpuStrings = new string[] {"abc","aa","b","acd","def","ff","a","zs"};
            StringSort(inpuStrings);
        }

        private static void StringSort(string[] input)
        {
            var finalBucket = new Queue<string>[26];    //Holds the final result
            var bucket = new Queue<string>[26];

            //Instantiate Empty buckets
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new Queue<string>();
                finalBucket[i] = new Queue<string>();
            }
            
            //The sort algorithm is case-insensitive
            // int of a is 97

            var charPosition = 0;
            var index = 0;  //Starting from the MSD
            char character;
            
            var end = input.Length; //This will vary for each iteration 

            Queue<string> currBucket = null;

            while (true)
            {
                bool endCondition = true;
                for (int i = 0; i < end; i++)
                {
                    if (charPosition + 1 >= input[i].Length)
                    {
                        character = input[i].ToLower()[0]; //Lowercase string and take the MSD character
                        index = character - 97;
                        finalBucket[index].Enqueue(input[i]); 
                    }
                    else
                    {
                        endCondition = false;
                        character = input[i].ToLower()[charPosition]; 
                        index = character - 97;
                        bucket[index].Enqueue(input[i]);
                    }                    
                }

                //Breaking condition
                if(endCondition)
                {
                    break;
                }

                //Reusing Index and repopulating input array                 
                index = 0;
                for (int i = 0; i < bucket.Length; i++)
                {
                    currBucket = bucket[i];
                    while (currBucket.Count > 0)
                    {
                        input[index++] = currBucket.Dequeue();
                    }
                }

                // Moving to the next significant position
                charPosition += 1;

                //Adjusting looping ending for next iteration
                end = index;
            }

            //Populating the final array
            index = 0;
            for (int i = 0; i <  finalBucket.Length; i++)
            {
                currBucket = finalBucket[i];
                while (currBucket.Count > 0)
                {
                    input[index++] = currBucket.Dequeue();
                }
            }
        }

        private static void NumberSort(int[] input)
        {
            var bucket = new Queue<int>[10];

            //Instantiate Empty buckets
            for (int i = 0; i < 10; i++)
            {
                bucket[i]= new Queue<int>();
            }

            var digit = 1;
            var index = 0;

            Queue<int> currBucket = null;
            while (true)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    index = Math.Abs((input[i] / digit) % 10);
                    bucket[index].Enqueue(input[i]);
                }

                //Breaking condition
                if (bucket[0].Count == input.Length)
                {
                    break;
                }


                //Retrieve from buckets
                index = 0;
                for (int i = 0; i < bucket.Length; i++)
                {
                    currBucket = bucket[i];
                    while (currBucket.Count > 0)
                    {
                        input[index++] = currBucket.Dequeue();
                    }
                }

                digit *= 10;
            }
        }
    }
}

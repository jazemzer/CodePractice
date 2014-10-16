using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class CountingSort
    {
        /// <summary>
        /// For simplicity, consider the data in the range 0 to 9. 
        /// Input data: 1, 4, 1, 2, 7, 5, 2
        ///     1) Take a count array to store the count of each unique object.
        ///   Index:     0  1  2  3  4  5  6  7  8  9
        ///   Count:     0  2  2  0   1  1  0  1  0  0
        /// 
        ///   2) Modify the count array such that each element at each index 
        ///   stores the sum of previous counts. 
        ///   Index:     0  1  2  3  4  5  6  7  8  9
        ///   Count:     0  2  4  4  5  6  6  7  7  7
        /// 
        /// The modified count array indicates the position of each object in the output sequence.
        /// 
        ///   3) Output each object from the input sequence followed by decreasing its count by 1.
        ///     Process the input data: 1, 4, 1, 2, 7, 5, 2. Position of 1 is 2. 
        ///     Put data 1 at index 2 in output. Decrease count by 1 to place next data 1 at an index 1 smaller than this index.
        /// http://www.geeksforgeeks.org/counting-sort/
        /// </summary>
        public static void Implementation()
        {
            int[] input = new[] { 10,11,46,18,23,56,98,45 };
            int M = 10, N = 100;
            Sort(input, M, N);
        }


        public static void Sort(int[] input, int M, int N)
        {
            // Bring lower range to Zero Index
            var freq = new int[N - M + 1];

            // Create Frequency Array
            foreach (int t in input)
            {
                freq[t - M] += 1;
            }

            // Create Cumulative frequency array
            for (var i = 1; i < freq.Length; i++)
            {
                freq[i] += freq[i -1];
            }

            var output = new int[input.Length];
            // Look up Cumulative frequency array and map the input to the appropriate position in new array. 
            // Decrement cum. freq count for corresponding slot after each input number
            foreach (int t in input)
            {
                var position = freq[t - M]--;
                output[position - 1] = t;
            }
        }
    }
}

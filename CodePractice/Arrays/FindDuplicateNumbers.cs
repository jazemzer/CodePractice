using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSArrays
{
    /// <summary>
    /// An array contains n numbers ranging from 0 to n-1. There are some numbers duplicated in the array. 
    /// It is not clear how many numbers are duplicated or how many times a number gets duplicated. 
    /// How do you find a duplicated number in the array? For example, if an array of length 7 contains 
    /// the numbers {2, 3, 1, 0, 2, 5, 3}, the implemented function (or method) should return either 2 or 3.
    /// </summary>
    public class FindDuplicateNumbers
    {

        public static void Implementation()
        {
            var input = new int[] { 2, 2, 3, 1, 0, 3};

            var result = FindDuplicates(input).ToList();
            foreach (var findDuplicate in result)
            {
                Console.WriteLine(findDuplicate);
            }
            Console.ReadLine();
        }

        private static IEnumerable<int> FindDuplicates(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != i)  
                {
                    if (input[input[i]] == input[i])
                    {
                        yield return input[i];
                    }
                    else //Swap the elements
                    {
                        
                        var temp = input[i];
                        input[i] = input[input[i]];
                        //Using array index as temp below is the key
                        input[temp] = temp;
                    }
                }
            }
        }
    }
}

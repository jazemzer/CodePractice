using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class NumberAppearingOnce
    {
        /// <summary>
        /// In an array, all numbers appear three times except one which only appears only once. Please find the unique number.
        /// http://codercareer.blogspot.in/2013/12/no-50-numbers-appearing-once.html
        /// </summary>
        public static void Implementation()
        {

            var input = new int[] { 1, 1, 1, 3, 3, 3, 3 };

            var result = 0;

            var counter = 0;

            var bitmask = 1;
            while (counter < 32)
            {
                var tempCount = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if((input[i] & bitmask) != 0)
                    {
                        tempCount++;
                    }
                }

                if(tempCount % 3 > 0)
                {
                    result |= bitmask;
                }
                counter++;

                bitmask <<= 1;
            }

            Console.WriteLine(result);
        }
                
    }
}

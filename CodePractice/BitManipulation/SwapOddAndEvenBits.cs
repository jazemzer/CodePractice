using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class SwapOddAndEvenBits
    {
        /// <summary>
        /// http://www.careercup.com/question?id=14922694
        /// 
        /// Write a program to swap odd and even bits of a 32-bit unsigned integer with as few instructions as possible. 
        /// (bit-0 and bit-1 are swapped, bit-2 and bit-3 are swapped and so on)
        /// </summary>
        public static void Implementation()
        {

            //Using unsigned integer because the sign bit is ignored in shift operations and unchecked keyword is needed as well

            var inputs = new UInt32[] { 7, 4, UInt32.MinValue, UInt32.MaxValue, 0xAAAAAAAA };

            var oddMask = 0x55555555;
            var evenMask = 0xAAAAAAAA;

            foreach (var input in inputs)
            {
                Console.WriteLine(" ***** " + input);
                Console.WriteLine(Convert.ToString(input, 2));
                var rightShift = (input & evenMask) >> 1;
                Console.WriteLine(Convert.ToString(rightShift, 2));
                var leftShift = (input & oddMask) << 1;
                Console.WriteLine(Convert.ToString(leftShift, 2));
                var result = rightShift | leftShift;
                Console.WriteLine(Convert.ToString(result, 2));
                Console.WriteLine(result);
            }


        }
                
    }
}

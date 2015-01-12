using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class ReverseBits
    {

        public static void Implementation()
        {
            uint input = 0xAFAFAFAF;

            Console.WriteLine(Convert.ToString(input, 2));
            Console.WriteLine(Convert.ToString(WithCaching(input), 2));
        }

        /// <summary>
        ///     Use a lookup table for 16 bits 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static uint WithCaching(uint input)
        {
            var lookup = new uint[UInt16.MaxValue + 1];
            for (uint i = 0; i <= UInt16.MaxValue; i++)
            {
                lookup[i] = SinglePass(i);
            }

            var bitMask = 0xFFFF;            

            var no_of_bits = sizeof(uint) * 8;
            var maskLength = 16;

            uint result = 0;
            result = lookup[(input & bitMask)] 
                | (lookup[input >> (1 * maskLength) & bitMask] >> (1 * maskLength))
               ;
            return result;
        }

        /// <summary>
        ///     As you pass from LSD to MSD create another stream of bits
        /// </summary>
        private static uint SinglePass(uint input)
        {
            int no_of_bits = sizeof(uint) * 8;
            uint result = 0;

            while(no_of_bits > 0)
            {
                if((input & 1 )!= 0)
                {
                    result ^= (uint) 1 << (no_of_bits - 1);
                }
                input = input >> 1;
                no_of_bits--;
            }
            return result;
        }

        /// <summary>
        ///     Use two pointers and flip digits at respective locations if the bits are different.
        /// </summary>
        private static uint Crude(uint input)
        {
            //Have two pointers
            uint leftP = 0x80000000;
            uint rightP = 0x00000001;
            int count = 0;

            int no_of_bits = sizeof(int) * 4;

            //Go until midpoint
            while (count < no_of_bits/2)
            {
                // Retrieve left and right elements
                uint rightBit = (input & rightP)>>count;

                // Be aware of zero index so the MSB is one less
                uint leftBit = (input & leftP)>> (no_of_bits - count - 1);
                
                // Only if the bits are not matching swapping them benefits
                if(rightBit != leftBit)
                {
                    // Swap one after another to avoid filling everything with ones
                    input ^= leftP;
                    input ^= rightP;
                }
                count++;

                // Shift pointers by one bit each side
                leftP >>= 1;
                rightP <<= 1; 
            }
            return input;
        }
    }
}

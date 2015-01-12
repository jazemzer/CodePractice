using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class SwapBitPositions
    {

        public static void Implementation()
        {
            int input = 0xAAAA;

            int i = 13;
            int j = 0;

            int mask = 1 << i | 1 << j;
            Console.WriteLine(Convert.ToString(mask, 2));

            // check if the bits are different
            if ( (input >> i & 1) != (input >> j & 1))
            {
                // XOR with a mask to flip the bits
                input ^= mask;
            }

            Console.WriteLine(Convert.ToString(input, 2));
        }
                
    }
}

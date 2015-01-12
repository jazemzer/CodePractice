using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class ComputeParity
    {
        public static void Implementation()
        {

            //Console.WriteLine(Convert.ToString(-3, 2));

            var inputs = new long[] { -1, 4, long.MinValue, long.MaxValue };

            foreach (var input in inputs)
            {
                Console.WriteLine("***********");

                Console.WriteLine(ComputeParityBruteForce(input));
                Console.WriteLine(ComputeParityBruteForceOptimized(input));
                Console.WriteLine(ComputeParityCached(input));
                Console.WriteLine(ComputeParityParallelXOR(input));

            }
        }

        private static long ComputeParityBruteForce(long input)
        {

            long result = 0;

            while(input > 0)
            {
                result = result ^ (input & 1);
                input = input >> 1;
            }

            return result;

        }

        private static long ComputeParityBruteForceOptimized(long input)
        {

            long result = 0;

            while (input > 0)
            {
                input = input & (input - 1);
                //Remove the last set bit
                result = result ^ 1;
            }

            return result;

        }

        private static long ComputeParityCached(long input)
        {
            //var bitMask = Convert.ToInt32("FFFF", 16);

            var bitMask = Int16.MaxValue;
            var lookupTable = new int[bitMask + 1];

            for(int i = 0 ; i <= bitMask; i++)
            {
                lookupTable[i] = (int) ComputeParityBruteForceOptimized(i);
            }

            // 2 ^ 16  = 65536 is manageable

            long result = 0;
            result = lookupTable[input & bitMask] ^
                lookupTable[(input >> (3 * bitMask)) & bitMask] ^
                lookupTable[(input >> (2 * bitMask)) & bitMask] ^
                lookupTable[(input >> bitMask) & bitMask];

            return result;
        }

        private static long ComputeParityParallelXOR(long input)
        {
            long result = 0;
            //http://stackoverflow.com/questions/17350906/computing-the-parity


            input ^= input >> 1;
            input ^= input >> 2;
            input ^= input >> 4;
            input ^= input >> 8;
            input ^= input >> 16;
            input ^= input >> 32;

            result = input & 1;
            return result;
        }
                
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class ClosestNeighbourByWeight
    {
        /// <summary>
        ///     Find closest integer with same parity
        /// </summary>
        public static void Implementation()
        {

            uint input = 0xA;


            Console.WriteLine(Convert.ToString(input, 2));

            for (int i = 0; i < sizeof(uint); i++)
            {
                //if adjacent bits are variying '01' or '10'
                if ((((input >> i) & 1) ^ ((input >> i + 1) & 1) ) != 0)
                {
                    //swap them
                    input ^= (uint)(3 << i);
                    break;
                }
            }

            Console.WriteLine(Convert.ToString(input, 2));
        }
                
    }
}

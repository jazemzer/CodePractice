using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class CheckIntegerIs2PowerX
    {

        public static void Implementation()
        {
            var inputs = new int[] { 2, 4, -2, 5, 12};

            Console.WriteLine(Convert.ToString(-4, 2));

            //Negative numbers don't feature in powers of 2
            foreach(var input in inputs)
            {
                if(input > 0 
                    && (input & (input -1)) == 0)
                {
                    Console.WriteLine(input);
                }
            }
        }
                
    }
}

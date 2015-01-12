using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class SwapWithoutATempVariable
    {

        public static void Implementation()
        {
            int x = 4, y = -5;

            x = x ^ y;
            y = x ^ y;
            x = x ^ y;

            Console.WriteLine(x);
            Console.WriteLine(y);

        }
                

    }
}

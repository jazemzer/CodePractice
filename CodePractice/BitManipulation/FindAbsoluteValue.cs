using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class FindAbsoluteValue
    {

        public static void Implementation()
        {


            int v = -3;
            int mask = v >> 31;

            Console.WriteLine(Convert.ToString(v, 2));
            Console.WriteLine(Convert.ToString(v + mask, 2));
            Console.WriteLine(Convert.ToString((v + mask) ^ mask, 2));

            Console.WriteLine((v + mask) ^ mask);

        }
                
    }
}

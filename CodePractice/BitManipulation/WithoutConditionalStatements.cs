using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    public class WithoutConditionalStatements
    {
        /// <summary>
        /// Consider the statement 
        ///     result = a ? b : c; 
        ///     Implement the above statement without using any conditional statements.
        ///     http://www.careercup.com/question?id=5089834754375680
        /// </summary>

        public static void Implementation()
        {
            bool a = true;

            int b = 3;
            int c = 4;

            Console.WriteLine(Convert.ToInt32(a) * b + Convert.ToInt32(!a) * c);
        }
                
    }
}

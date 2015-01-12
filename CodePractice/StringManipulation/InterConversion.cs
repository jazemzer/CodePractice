using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    class InterConversion
    {

        public static void Implementation()
        {

            Console.WriteLine(ToString(-1234));
            Console.WriteLine(ToInt("-24343234324234324234"));
        }

        private static string ToString(int input)
        {
            var result = new StringBuilder();

            var lookup = "0123456789";

            bool isNegative = false;

            if(input < 0)
            {
                isNegative = true;
                input = -input;
            }

            while (input > 0)
            {
                var rem = input % 10;
                result.Append(lookup[rem]);
                input = input/ 10;
            }

            if (isNegative)
                result.Append('-');

            return new String(result.ToString().Reverse().ToArray());
        }

        private static int ToInt(string input)
        {
            int len = input.Length;
            int result = 0;

            int i = 0;
            bool isNegative = false;

            try
            {


                if (input[i] == '-')
                {
                    isNegative = true;
                    i++;
                }
                for (; i < len; i++)
                {
                    // Checks for overflow errors
                    checked
                    {
                        //Trick to convert characters to integers is by negating it with the start character
                        result += ((input[i] - '0') * (int)Math.Pow(10, len - 1 - i));
                    }
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Overflow exception occurred! ");
            }
            return isNegative? -result : result;
        }
                
    }
}

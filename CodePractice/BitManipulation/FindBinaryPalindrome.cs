using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BitManipulation
{
    class FindBinaryPalindrome
    {

        /// <summary>
        /// http://www.geeksforgeeks.org/check-binary-representation-number-palindrome/
        /// </summary>
        public static void Implementation()
        {
            unchecked
            {
                Int16 input = (Int16)0xFA5F;

                Console.WriteLine(Convert.ToString(input, 2));

                int leftPosition = sizeof(Int16) * 8 - 1;
                int rightPosition = 0;

                bool isPalindrome = true;
                while (leftPosition > rightPosition)
                {
                    var leftBit = (input >> leftPosition) & 1;
                    var rightBit = (input >> rightPosition) & 1;

                    if (leftBit != rightBit)
                    {
                        isPalindrome = false;
                        break;
                    }

                    leftPosition--;
                    rightPosition++;
                }


                Console.WriteLine(isPalindrome);
            }
        }
                
    }
}

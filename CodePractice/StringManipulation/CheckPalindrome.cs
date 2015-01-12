using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    class CheckPalindrome
    {

        public static void Implementation()
        {
            Console.WriteLine(Logic("malayalam"));
        
        }


        private static bool Logic(string input)
        {
            bool result = true;

            int left = 0;
            int right = input.Length - 1; 

            //Doesnt take care of case insensitivity or non-alphanumeric characters

            while(left < right)
            {
                if(input[left] != input[right])
                {
                    result = false;
                    break;
                }
                left++;
                right--;
            }

            return result;
        }
                
    }
}

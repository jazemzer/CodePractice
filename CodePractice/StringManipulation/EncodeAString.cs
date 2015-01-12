using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    class EncodeAString
    {

        public static void Implementation()
        {
            string input = "AABBCCDDeeaab";
            var output = new StringBuilder();

            char previous = ' ';
            char current = ' ';

            var counter = 0; 
            for(int i = 0; i < input.Length; i ++)
            {
                current = input[i];
                if(previous != current)
                {
                    if(i > 0)
                    {
                        output.Append(previous);
                        output.Append(counter);
                    }
                    counter = 1;
                    previous = current;
                }
                else 
                {
                    counter++;
                }
            }
            output.Append(previous);
            output.Append(counter);

            Console.WriteLine(output);
        }
                
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    public class RemoveDuplicateCharacters
    {
        public static void Implementation()
        {
            string input = "AABBCCDDeeaabb";

            var output = new StringBuilder();

            HashSet<char> lookup = new HashSet<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!lookup.Contains(input[i]))
                {
                    lookup.Add(input[i]);
                    output.Append(input[i]);
                }
            }

            Console.WriteLine(output);
        }
                
    }
}

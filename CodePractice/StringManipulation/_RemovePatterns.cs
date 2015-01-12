using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    class _RemovePatterns
    {

        public static void Implementation()
        {
            //Console.WriteLine(RemovePattern("Jabez", "Jab"));
            //Console.WriteLine(RemovePattern("aacbbdccaac", "ac"));
            Console.WriteLine(RemovePattern("aacaaccd", "ac"));
            
        }

        private static string RemovePattern(string input, string pattern)
        {
            //Base Conditions
            if (input == null || pattern == null || input.Length < pattern.Length)
                return input;


            var output = new StringBuilder();

            int patternPosition = 0;

            var temp = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == pattern[patternPosition])
                {
                    patternPosition++;

                    if (patternPosition == pattern.Length)
                    {
                        temp.Clear();
                        patternPosition = 0;
                    }
                    else
                    {
                        temp.Append(input[i]);
                    }
                }
                else
                {
                    if (temp.Length > 0)
                    {
                        output.Append(temp);
                        temp.Clear();
                        patternPosition = 0;
                        i--;
                    }
                    else
                    {
                        output.Append(input[i]);
                    }
                }
            }

            return output.ToString();
        }
                
    }

    enum States
    {
        Initial,
        Matching,
    }
}

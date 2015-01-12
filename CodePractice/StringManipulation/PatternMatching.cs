using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    class PatternMatching
    {

        public static void Implementation()
        {

            Print(FindPattern("AAAAAAAAAAAAAAAAAA", "AAAAA"));
            Print(FindPattern("AAAAAAAAAAAAAAAAAA", null));
        }

        private static void Print(IEnumerable<int> indexes)
        {
            if(indexes != null)
            {
                foreach(var item in indexes)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        private static IEnumerable<int> FindPattern(string input, string pattern)
        {
            if (input == null || pattern == null || input.Length < pattern.Length)
            {
                yield return -1;
                yield break;
            }

            int N = input.Length;
            int M = pattern.Length;
            for(int i = 0; i <= N - M; i++)
            {
                int j; 
                for(j = 0; j < M; j++)
                {
                    if (input[i + j] != pattern[j])
                        break;
                }

                if(j == M)
                    yield return i;
            }

        }
                
    }
}

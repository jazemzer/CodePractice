using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    class PatternMatchingKMP
    {
        public static void Implementation()
        {
            var input = "ABABDABACDABABCABAB";
            var pattern = "ABABCABAB";

            var lps = ComputeLPS(pattern);

        }

        // LPS - Longest Proper Prefix of a sub pattern which is also a suffix
        private static int[] ComputeLPS(string pattern)
        {
            var lps = new int[pattern.Length];
            lps[0] = 0; //First element is always zero

            int i = 1;

            int m = pattern.Length;
            int len = 0;  //Length of previous longest prefix
            while (i < m)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }



            return lps;
        }
                 
    }
}

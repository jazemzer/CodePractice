using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    /// <summary>
    ///     EPI - Given a string, remove each 'b' and replace each 'a' by 'dd'. use O(1) additional storage. Assume s has enough space for final result.
    /// </summary>
    class ReplaceAndRemove
    {

        public static void Implementation()
        {
            Console.WriteLine(Logic("abacaa  b "));
            Console.WriteLine(Logic("acaa   "));
        }

        private static string Logic(string input)
        {
            unsafe
            {
                // Must pin object on heap so that it doesn't gets relocated by garbage collector 
                fixed (char* start = input)
                {
                    #region Compacting  Scenarios like this 'aa b'
                    // Create another pointer allow incrementation 
                    char* left = start;
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] != 'b'
                            && input[i] != ' ')
                        {
                            *left = input[i];
                            left += 1;
                        }
                    }
                    #endregion

                    // Moving back the left pointer to point to the last element
                    left -= 1;

                    char* right = start + (input.Length - 1);
                    while(left >= start)
                    {
                        if(*left == 'a')
                        {
                            *right = 'd';
                            right -= 1;

                            *right = 'd';
                        }
                        else
                        {
                            *right = *left;
                        }
                        right -= 1;
                        left -= 1;
                    }

                }
            }

            return input;
        }
                
    }
}

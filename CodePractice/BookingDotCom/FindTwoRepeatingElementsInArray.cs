﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BookingDotCom
{
    class FindTwoRepeatingElementsInArray
    {
        private static void Code()
        {
            int[] arr = { 1, 3, 4, 5, 2, 3, 1 };
            int size = arr.Length;

            int xor = arr[0]; /* Will hold xor of all elements */
            int set_bit_no;  /* Will have only single set bit of xor */
            int i;
            int n = size - 2;
            int x = 0, y = 0;

            /* Get the xor of all elements in arr[] and {1, 2 .. n} */
            for (i = 1; i < size; i++)
                xor ^= arr[i];
            for (i = 1; i <= n; i++)
                xor ^= i;

            /* Get the rightmost set bit in set_bit_no */
            set_bit_no = xor & ~(xor - 1);

            /* Now divide elements in two sets by comparing rightmost set
             bit of xor with bit at same position in each element. */
            for (i = 0; i < size; i++)
            {
                if ((arr[i] & set_bit_no) == set_bit_no)
                    x = x ^ arr[i]; /*XOR of first set in arr[] */
                else
                    y = y ^ arr[i]; /*XOR of second set in arr[] */
            }
            for (i = 1; i <= n; i++)
            {
                if ((i & set_bit_no) == set_bit_no)
                    x = x ^ i; /*XOR of first set in arr[] and {1, 2, ...n }*/
                else
                    y = y ^ i; /*XOR of second set in arr[] and {1, 2, ...n } */
            }
            Console.WriteLine("X and y are {0}, {1}", x, y);
        }
    }
}

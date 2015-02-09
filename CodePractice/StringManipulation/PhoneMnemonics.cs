using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    class PhoneMnemonics
    {

        public static void Implementation()
        {
            string input = "79";

            var output = new char[input.Length];

            Recurser(input, 0, ref output);
        }

        static Dictionary<int, string> lookup = new Dictionary<int, string>(){
                {0, "0"},
                {1, "1"},
                {2, "ABC"},
                {3, "DEF"},
                {4, "GHI"},
                {5, "JKL"},
                {6, "MNO"},
                {7, "PQRS"},
                {8, "TUV"},
                {9, "WXYZ"},
            };

        private static void Recurser(string input, int index, ref char[] output)
        {
            if(index > input.Length - 1)
            {
                Console.WriteLine( new string(output));
                return;
            }

            var options = lookup[input[index] - '0'];

            for (int i = 0; i < options.Length; i++)
            {
                output[index] = options[i];
                Recurser(input, index + 1, ref output);
            }
        }
                
    }
}

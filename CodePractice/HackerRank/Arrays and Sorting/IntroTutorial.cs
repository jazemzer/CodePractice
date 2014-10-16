using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class IntroTutorial
    {
        public static void Code()
        {
        //    int V = Convert.ToInt32(Console.ReadLine());
        //    int N = Convert.ToInt32(Console.ReadLine());
        //    int input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
            int V = 21;
            int N = 100;
            var input = Array.ConvertAll("2 4 8 12 15 19 21 24 26 29 30 32 35 36 41 44 49 52 57 58 59 64 65 68 73 77 80 82 85 88 93 97 101 105 108 111 115 118 122 127 130 131 132 134 135 136 138 141 144 146 151 153 158 160 165 169 171 176 179 184 187 190 194 197 200 205 210 215 217 222 225 230 231 236 239 243 244 246 248 253 254 256 258 262 263 267 272 274 277 280 284 285 289 291 295 297 301 305 310 312".Split(' '), Convert.ToInt32);
            BinarySearch(input, V, 0, N - 1);
            Console.ReadLine();
        }
        private static void BinarySearch1(int[] input, int value, int start, int end)
        {
            while (start <= end)
            {
                int mid = (start + end) / 2;
                int midValue= input[mid];
                if (value == midValue)
                {
                    Console.WriteLine(mid);
                    break;
                }
                else if (value < midValue)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }

            }
        }

        private static void BinarySearch(int[] input, int value, int start, int end)
        {
            if (start <= end)
            {
                int mid = (start + end) / 2;
                if (input[mid] == value)
                {
                    Console.WriteLine(mid);
                    return;
                }
                else if (input[mid] > value)
                {
                    BinarySearch(input, value, start, mid - 1);
                }
                else
                {
                    BinarySearch(input, value, mid + 1, end);
                }
            }
        }
    }
}

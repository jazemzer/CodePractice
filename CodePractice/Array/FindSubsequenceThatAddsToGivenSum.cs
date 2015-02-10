using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSArrays
{
    class FindSubsequenceThatAddsToGivenSum
    {

        public static void Implementation()
        {
            //int[] numbers = { 3, 9, 8, 4, 5, 7, 10 };
            //int target = 15;
            //int[] numbers = { 1, 1, 1 , 3 ,4, 5 };
            //int target = 5;
            //sum_up(new List<int>(numbers.ToList()), target);
            //NaiveSubSetSolution(numbers, target);

            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int sum = 37;
            FindSum(sum, numbers);
        }

        public static void FindSum(int sum, int[] numbers)
        {
            for (int i = numbers.Length - 1; i >= 0 && numbers[i] * i > sum; i--)
            {
                bool result = FindSum(sum, numbers, i);
                if (result)
                    break;
            }
        }

        public static bool FindSum(int sum, int[] numbers, int end)
        {
            bool result = false;
            if (end >= 0)
            {
                if (sum == numbers[end])
                {
                    Console.WriteLine(numbers[end]);
                    result = true;
                }
                else if (numbers[end] < sum)
                {
                    result = FindSum(sum - numbers[end], numbers, end - 1);
                    if (result)
                    {
                        Console.WriteLine(numbers[end]);
                    }
                }
                else if (numbers[end] > sum)
                {
                    while (end >= 0 && numbers[end] > sum)
                    {
                        end--;
                    }
                    result = FindSum(sum, numbers, end);
                }
            }
            return result;
        }

        public static string ToBin(int value, int len)
        {
            return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
        }

        static void NaiveSubSetSolution(int[] input, int target)
        {
            int sum = 0;
            string binary = "";
            int arrayLength = input.Length;
            List<int> output;
            
            //Assuming N is small
            int twoPowerN = (int) Math.Pow(2,arrayLength);
            for (int i = 1; i < twoPowerN; i++)
            {
                sum = 0;
                binary = ToBin(i, arrayLength);
                                
                output = new List<int>();
                for (int j = arrayLength - 1; j >= 0; j--)
                {
                    if (binary[j] == '1')
                    {
                        sum += input[j];
                        output.Add(input[j]);
                    }
                    if (sum > target)
                    {
                        break;
                    }
                }

                if (sum == target)
                {
                    Console.WriteLine(string.Join(",", output));
                }
            }
        }

        static void sum_up_recursive(List<int> numbers, int target, List<int> part)
        {
            int s = 0;
            foreach (int x in part)
            {
                s += x;
            }
            if (s == target)
            {
                Console.WriteLine("sum(" + string.Join(",", part.Select(n => n.ToString()).ToArray()) + ")=" + target);
            }
            if (s >= target)
            {
                return;
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                var remaining = new List<int>();
                int n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    remaining.Add(numbers[j]);
                }
                var part_rec = new List<int>(part);
                part_rec.Add(n);

                Console.WriteLine(string.Join(",", remaining) + " ******** " + string.Join(",", part_rec));
                sum_up_recursive(remaining, target, part_rec);
            }
        }
        static void sum_up(List<int> numbers, int target)
        {
            sum_up_recursive(numbers, target, new List<int>());
        }

        //Rippers implementation
        //public static void Implementation()
        //{
        //    int sum = 9;


        //    //if (int.TryParse(Console.ReadLine(), out sum))
        //    {
        //        var input = "1 1 2 3 4 5 6 7 8 9";

        //        if (input != null)
        //        {
        //            var numbers = input.Split(' ');

        //            var lookup = new Dictionary<int, string>();

        //            foreach (var i in numbers)
        //            {
        //                var num = int.Parse(i);

        //                var toLook = sum - num;

        //                if (lookup.ContainsKey(toLook))
        //                {
        //                    Console.WriteLine("{0}, {1}", lookup[toLook], num);
        //                }
        //                else
        //                {
        //                    var keys = new List<int>(lookup.Keys);

        //                    foreach (var key in keys)
        //                    {
        //                        var path = lookup[key];

        //                        if (key + num < sum)
        //                        {
        //                            path = path + num.ToString(CultureInfo.InvariantCulture);

        //                            if (!lookup.ContainsKey(key + num))
        //                            {
        //                                lookup.Add(key + num, path);
        //                            }
        //                        }
        //                    }

        //                    if (!lookup.ContainsKey(num))
        //                    {
        //                        lookup.Add(num, num.ToString(CultureInfo.InvariantCulture) + ",");
        //                    }
        //                }
        //            }
        //        }                
        //    }
        //}

        //public static void Implementation()
        //{
        //    //int[] input = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        //    //int[] input = new[] { 1, 1, 3, 4, 5, 6, 7 };
        //    int[] input = new[] { 2, 3, 3, 4, 6, 7 };

        //    int k = 9;

        //    var hashMap = new Dictionary<int, int>();
        //    hashMap.Add(0, -1);

        //    var currSum = 0;
        //    var cumuIndex = 0;
        //    var loopIndex = 0;

        //    bool isRunningSequenceFound = false;

        //    for (; loopIndex < input.Length; loopIndex++)
        //    {
        //        currSum += input[loopIndex];

        //        if (hashMap.ContainsKey(currSum - k))
        //        {
        //            cumuIndex = hashMap[currSum - k];
        //            isRunningSequenceFound = true;
        //            break;
        //        }

        //        if (!hashMap.ContainsKey(currSum))
        //            hashMap.Add(currSum, loopIndex);
        //    }

        //    if (isRunningSequenceFound)
        //    {
        //        for (int a = cumuIndex + 1; a <= loopIndex; a++)
        //        {
        //            Console.Write(input[a] + " ");
        //        }
        //    }
        //    else
        //    {
        //        int j = input.Length - 1;
        //        while (j >= 0)
        //        {
        //            var right = input[j];
        //            if (hashMap.ContainsKey(currSum - right))
        //            {

        //            }
        //            j--;
        //        }
        //    }

        //}
    }
}

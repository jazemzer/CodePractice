using CodePractice.Amazon.Careercup;
using CodePractice.Arrays;
using CodePractice.BitManipulation;
using CodePractice.Codility;
using CodePractice.CodingInterviews;
using CodePractice.CSharp;
using CodePractice.CSharp.Threading;
using CodePractice.DatastructuresAndAlgorithms.Algorithms.Logic;
using CodePractice.DatastructuresAndAlgorithms.Problems.LinkedList;
using CodePractice.Design.FlightBooking;
using CodePractice.Design.Tautology;
using CodePractice.DesignPatterns;
using CodePractice.GeeksForGeeks;
using CodePractice.GeeksForGeeks.BinarySearchTree;
using CodePractice.GeeksForGeeks.BinaryTree;
using CodePractice.Graph;
using CodePractice.LinkedList;
using CodePractice.StringManipulation;
using CodePractice.Trees.BinaryTree;
using CodePractice.Trees.BST;
using CSharp.Threading;
using DSArrays;
using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;  

namespace CodePractice
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(@"D:\Works\CodePractice\CodePractice\Input.txt"));

            DetectCycleInGraph.Implementation();

            return;
            var N = Convert.ToInt32(Console.ReadLine());

            var markers = new bool[N];

            var primes = 0;

            markers[0] = true;
            for (int i = 1; i < N; i++)
            {
                if (!markers[i])
                {
                    int temp = 2;
                    int num = i;
                    while ( (num = (i + 1) * temp) <= N)
                    {
                        markers[num - 1] = true;
                        temp++;
                    }
                }
            }


            for (int i = 0; i < N; i++)
            {
                if (!markers[i])
                    primes++;
            }

            Console.WriteLine(primes);

            Console.Read();
        }


       

    }
}

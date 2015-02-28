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
using CodePractice.LinkedList;
using CodePractice.StringManipulation;
using CSharp.Threading;
using DSArrays;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;  

namespace CodePractice
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string input = "((!a & !c) | !(b&c))";

            

            //input = "(!a&c)";
            var res = new EBNFConvertor().ConvertInfixToPostFix(input);

            //CodePractice.StringManipulation.PhoneMnemonics.Implementation();

            //Yet to solve - http://basicalgos.blogspot.in/2012/06/58-linked-list-related-questions.html

            //Theory
            // http://www.geeksforgeeks.org/linked-list-vs-array/
        }
    }
}

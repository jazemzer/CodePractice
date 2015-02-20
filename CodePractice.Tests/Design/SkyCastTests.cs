using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CodePractice.Design.SkyCast;

namespace CodePractice.Tests.Design
{
    [TestClass]
    public class SkyCastTests
    {
        [TestMethod]
        public void Testing_Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K()
        {
            List<int> input = new List<int>() { 1, 3, 3, 4, 6, 7, 8, 9, 10, 15, 18, 245 };

            var utility = new  BinarySearchHelper();

            var index = utility.Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K(input, 5);
            Assert.AreEqual(index, 4);

            index = utility.Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K(input, 2);
            Assert.AreEqual(index, 1);

            index = utility.Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K(input, 3);
            Assert.AreEqual(index, 1);

            index = utility.Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K(input, 245);
            Assert.AreEqual(index, 11);

            index = utility.Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K(input, 345);
            Assert.AreEqual(index, -1);

            index = utility.Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K(input, -23);
            Assert.AreEqual(index, 0);

        }

        [TestMethod]
        public void Testing_Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K()
        {
            List<int> input = new List<int>() { 1, 3, 3, 4, 6, 7, 8, 9, 10, 15, 18, 245 };

            var utility = new BinarySearchHelper();

            var index = utility.Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K(input, 5);
            Assert.AreEqual(index, 3);

            index = utility.Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K(input, 2);
            Assert.AreEqual(index, 0);

            index = utility.Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K(input, 3);
            Assert.AreEqual(index, 2);

            index = utility.Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K(input, 245);
            Assert.AreEqual(index, 11);

            index = utility.Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K(input, 345);
            Assert.AreEqual(index, 11);

            index = utility.Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K(input, -23);
            Assert.AreEqual(index, -1);

        }

        [TestMethod]
        public void Testing_CalculatingCost()
        {

            var utility = new MasterBrain(new UpDownCostCalculator(new BinarySearchHelper()));

            var cost = utility.CalculateCost(1, 250, new List<int>() {5, 7, 9}, new List<int> (){15, 14, 17, 1, 17});
            Assert.AreEqual(cost, 7);

            cost = utility.CalculateCost(103, 108, new List<int>() { 104}, new List<int>() { 105, 106, 107, 103, 105 });
            Assert.AreEqual(cost, 8);

            cost = utility.CalculateCost(1, 100, new List<int>() { 78, 79, 80, 3 }, new List<int>() { 10, 13, 13 ,100, 99, 98, 77, 81 });
            Assert.AreEqual(cost, 12);

            cost = utility.CalculateCost(1, 200, new List<int>() , new List<int>() { 1 ,100, 1, 101 });
            Assert.AreEqual(cost, 7);

        }

        [TestMethod]
        public void Testing_UpDownCost()
        {
            var utility = new UpDownCostCalculator(new BinarySearchHelper());

            var cost = utility.CalculateUpDownCost(103, 108, 103, 107, new List<int> { 104 });
            Assert.AreEqual(cost, 2);


        }
    }
}

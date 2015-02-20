using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.SkyCast
{
    public class BinarySearchHelper : IBinarySearchHelper
    {
        public int Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K(List<int> items, int itemToFind)
        {
            var left = 0;
            var right = items.Count - 1;

            var lowest = -1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (items[mid] >= itemToFind)
                {
                    // To avoid out of range errors 
                    // If the mid point attains zero it means k is below the first element
                    if (mid == 0 || items[mid - 1] < itemToFind)
                    {
                        lowest = mid;
                        break;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else
                {
                    left = mid + 1;
                }
            }
            return lowest;
        }

        public int Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K(List<int> items, int itemToFind)
        {
            var left = 0;
            var right = items.Count - 1;

            var highest = -1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (items[mid] <= itemToFind)
                {
                    // To avoid out of range errors 
                    // If the mid point shifts to extreme right it means k is above the last element
                    if (mid + 1 == items.Count || items[mid + 1] > itemToFind)
                    {
                        highest = mid;
                        break;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    right = mid - 1;
                }
            }
            return highest;
        }
    }
}

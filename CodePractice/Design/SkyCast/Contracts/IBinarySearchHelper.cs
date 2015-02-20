using System;
using System.Collections.Generic;
namespace CodePractice.Design.SkyCast
{
    public interface IBinarySearchHelper
    {
        int Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K(List<int> items, int itemToCompare);
        int Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K(List<int> items, int itemToCompare);
    }
}

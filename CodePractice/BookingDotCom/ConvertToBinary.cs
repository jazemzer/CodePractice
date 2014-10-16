using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BookingDotCom
{
    class ConvertToBinary
    {
        static string Code(int number)
        {
            if (number > 1)
            {
                var remainder = 0;
                return Code(number / 2) + ((number % 2 == 0) ? "0" : "1");
            }

            return number.ToString();
        }
    }
}

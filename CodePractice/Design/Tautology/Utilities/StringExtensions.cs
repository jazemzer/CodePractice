using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Utilities
{
    public static class StringExtensions
    {
        public static TokenEnumerator GetTokenEnumerator(this string input)
        {
            return new TokenEnumerator(input);
        }
    }
}

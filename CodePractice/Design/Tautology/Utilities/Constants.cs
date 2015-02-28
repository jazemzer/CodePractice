using CodePractice.Design.Tautology.Contracts;
using CodePractice.Design.Tautology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Utilities
{
    public sealed class Constants
    {
        public static readonly char DefaultToken = '\0';    // Unicode null to avoid magic characters 
        public static readonly char PositionalTrue = '1';
        public static readonly char PositionalFalse = '0';
        public static readonly char LogicalAnd = '&';
        public static readonly char LogicalOr = '|';
        public static readonly char UnaryNot = '!';
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Model
{
    public class PositionalStatement
    {
        public PositionalStatement Left { get; set; }
        public PositionalStatement Right { get; set; }

        public bool IsNegated { get; set; }
        public char PositionalVariable { get; set; }
        public char Operator { get; set; }

        public string ReducedEquivalent { get; set; }

        public override string ToString()
        {
            if (Left != null && Right != null)
            {
                return Left.ToString() + Operator + Right.ToString();
            }
            return IsNegated ? "!" + PositionalVariable.ToString() : PositionalVariable.ToString();
        }
    }
}

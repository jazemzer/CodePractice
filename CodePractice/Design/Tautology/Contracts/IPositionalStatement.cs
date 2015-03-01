using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Contracts
{
    public interface IPositionalStatement
    {
        IPositionalStatement Left { get; set; }
        IPositionalStatement Right { get; set; }

        bool IsNegated { get; set; }
        char PositionalVariable { get; set; }
        char Operator { get; set; }

        void CopyFrom(IPositionalStatement from);
    }
}

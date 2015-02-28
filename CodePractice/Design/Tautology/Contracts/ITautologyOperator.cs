using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Contracts
{
    public interface ITautologyOperator
    {
        void AttemptToSimplify(IPositionalStatement statement);
    }
}

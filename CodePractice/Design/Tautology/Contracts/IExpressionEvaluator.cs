using System;
namespace CodePractice.Design.Tautology.Contracts
{
    public interface IExpressionEvaluator
    {
        bool EvaluatePostFixExpression(string postFixNotation);
    }
}

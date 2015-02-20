using System;
namespace CodePractice.Design.Tautology.Contracts
{
    public interface IExpressionConvertor
    {
        string ConvertInfixToPostFix(string inFixNotation);
    }
}

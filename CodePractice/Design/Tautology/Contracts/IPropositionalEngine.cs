using System;
namespace CodePractice.Design.Tautology.Contracts
{
    interface IPropositionalEngine
    {
        bool CheckTautology(string positionalStatement);
    }
}

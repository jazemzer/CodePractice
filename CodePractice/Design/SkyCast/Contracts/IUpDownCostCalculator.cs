using System;
using System.Collections.Generic;
namespace CodePractice.Design.SkyCast
{
    public interface IUpDownCostCalculator
    {
        int CalculateUpDownCost(int startChannel, int endChannel, int toChannel, int fromChannel, List<int> blockedChannels);
    }
}

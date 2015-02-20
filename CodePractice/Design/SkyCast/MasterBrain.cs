using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.SkyCast
{
    public class MasterBrain
    {

        private IUpDownCostCalculator upDownCalculator;

        public MasterBrain():this(new UpDownCostCalculator())
        {

        }

        public MasterBrain(IUpDownCostCalculator upDownCalculator)
        {
            this.upDownCalculator = upDownCalculator;
        }

        public int CalculateCost(int startChannel, int endChannel, List<int> blockedChannels, List<int> channelsToView)
        {
            // Sort the blocked channels before storing
            blockedChannels.Sort();

            var totalCost = 0;
            List<int> history = new List<int>();
            history.Add(int.MaxValue); //To handle start condition

            foreach (var targetChannel in channelsToView)
            {
                //Calculating Keying cost
                var keyingCost = targetChannel.ToString().Length;

                var backTraversalCost = -1;
                var updownCost = 0;

                var foundBetterMinimum = false;


                if (keyingCost > 1) //Optimizing condition
                {
                    var historyIndex = history.Count - 1;   //Because the last visited channel is added to the end of the list

                    //Traverse historicals and calculate updownCost for each channel
                    while (backTraversalCost < keyingCost && historyIndex >= 0)
                    {
                        updownCost = upDownCalculator.CalculateUpDownCost(startChannel, endChannel, targetChannel, history[historyIndex], blockedChannels);

                        backTraversalCost++;
                        if (updownCost + backTraversalCost < keyingCost)
                        {
                            foundBetterMinimum = true;
                            break;
                        }

                        historyIndex--;
                    }

                }

                history.Add(targetChannel);
                totalCost += foundBetterMinimum ? (backTraversalCost + updownCost) : keyingCost;
            }

            return totalCost;

        }



       

      
    }
}

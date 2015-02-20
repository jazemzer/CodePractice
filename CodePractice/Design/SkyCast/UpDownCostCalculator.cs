using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.SkyCast
{
    public class UpDownCostCalculator : IUpDownCostCalculator
    {
        private IBinarySearchHelper helper;

        public UpDownCostCalculator():this(new BinarySearchHelper())
        {

        }

        public UpDownCostCalculator(IBinarySearchHelper helper)
        {
            this.helper = helper;
        }

        private int FindNoOfChannelsToSkip(int startChannel, int endChannel, List<int> blockedChannels)
        {
            var lowest = helper.Find_Index_Of_Smallest_Number_Greater_Than_Or_Equal_To_K(blockedChannels, startChannel);

            var channelsToSkip = 0;
            if (lowest != -1)
            {
                var highest = helper.Find_Index_Of_Smallest_Number_Less_Than_Or_Equal_To_K(blockedChannels, endChannel);
                if (highest != -1)
                {
                    channelsToSkip = highest - lowest + 1;
                }

            }
            return channelsToSkip;
        }

        public int CalculateUpDownCost(int startChannel, int endChannel, int toChannel, int fromChannel, List<int> blockedChannels)
        {
            var min = toChannel > fromChannel ? fromChannel : toChannel;
            var max = toChannel < fromChannel ? fromChannel : toChannel;

            var linear = max - min - FindNoOfChannelsToSkip(min, max, blockedChannels);
            var cyclic = int.MaxValue;

            // To handle start condition
            if (fromChannel != int.MaxValue)
            {
                cyclic = (endChannel - max - FindNoOfChannelsToSkip(max, endChannel, blockedChannels))
                    + (min - startChannel - FindNoOfChannelsToSkip(startChannel, min, blockedChannels))
                    + 1; // + 1 for the missing cyclic link between start and end
            }

            return linear > cyclic ? cyclic : linear;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.FlightBooking
{
    class FlightClient
    {

        public static void Implementation()
        {
            var fb = new FlightBuilder();
            var flights = fb.GetFlights();

            var sanityChecker = new SanityChecker();
            var departBeforeCurrentTime = new DepartBeforeCurrentTime();
            var segmentWithArrivalBeforeDeparture = new SegmentWithArrivalBeforeDeparture();
            var moreThan2HoursOnGround = new MoreThan2HoursOnGround();

            sanityChecker.SetSuccessor(departBeforeCurrentTime);
            departBeforeCurrentTime.SetSuccessor(segmentWithArrivalBeforeDeparture);
            segmentWithArrivalBeforeDeparture.SetSuccessor(moreThan2HoursOnGround );

            for(int i = 0 ;i < flights.Count ; i++)
            {
                var result = sanityChecker.ApplyRule(flights[i]);
            }
            var filtered = flights.Where(x => sanityChecker.ApplyRule(x)).ToList();

        }
                
    }
}

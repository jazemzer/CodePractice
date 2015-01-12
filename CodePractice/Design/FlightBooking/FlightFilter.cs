using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.FlightBooking
{
    public abstract class FlightFilter
    {
        protected FlightFilter successor;

        public void SetSuccessor(FlightFilter successor)
        {
            this.successor = successor;
        }

        public abstract bool ApplyRule(Flight flight);
    }

    public class SanityChecker : FlightFilter
    {
        public override bool ApplyRule(Flight flight)
        {
            if(flight == null
                || flight.Segments == null
                || flight.Segments.Count == 0)
            {
                return false;
            }

           if (successor != null)
                return successor.ApplyRule(flight);
            return true;
        }
    }

    public class DepartBeforeCurrentTime : FlightFilter
    {
        public override bool ApplyRule(Flight flight)
        {
            var now = DateTime.Now;
            var invalidSegments = flight.Segments.Any(x => x.DepartureDate < now);

            if (invalidSegments)
                return false;
            else if(successor != null)
                return successor.ApplyRule(flight);

            return true;
        }
    }

    public class SegmentWithArrivalBeforeDeparture : FlightFilter
    {
        public override bool ApplyRule(Flight flight)
        {
            var invalidSegments = flight.Segments.Any(x => x.ArrivalDate < x.DepartureDate);

            if (invalidSegments)
                return false;
            else if(successor != null)
                return successor.ApplyRule(flight);
            return true;
        }
    }

    public class MoreThan2HoursOnGround : FlightFilter
    {
        public override bool ApplyRule(Flight flight)
        {
            
            //var invalidSegments = flight.Segments.Skip(1).Select( (x, index) =>
            //    x.DepartureDate - flight.Segments[index].ArrivalDate).Any(x=> x.Hours > 2);

            var groundHours = flight.Segments.Skip(1).Select((x, index) =>
                    (x.DepartureDate - flight.Segments[index].ArrivalDate).Hours).Sum();

            if (groundHours > 2)
                return false;
            else if (successor != null)
                successor.ApplyRule(flight);
            return true;
        }
    }
}

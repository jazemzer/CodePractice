using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.CSharp
{
    class Timings
    {
        public string Key { get; set; }
        public int Count { get; set; }
        public int Average { get; set; }
    }
    class LeftOuterJoinLinq
    {

        public static void Implementation()
        {
            var current = new List<Timings>();
            var previous = new List<Timings>();

            for (int i = 0; i < 5; i++)
            {
                current.Add(new Timings() { Key = "Name" + i, Count = i, Average = i });
            }

            for (int i = 0; i < 3; i++)
            {
                previous.Add(new Timings() { Key = "Name" + i, Count = i, Average = 45 });
            }

            var comparison = from c in current
                             join p in previous
                             on c.Key equals p.Key
                             into gj
                             from subset in gj.DefaultIfEmpty()
                             select new { c.Key, Current = c.Average, Previous = subset != null ? subset.Average : 0 };

        }
                
    }
}

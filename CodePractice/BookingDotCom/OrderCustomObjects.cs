using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BookingDotCom
{
    class Person
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    class OrderCustomObjects
    {
        public static void Code()
        {
            List<Person> people = new List<Person>()
            {
                new Person(){Name = "John", Score = 5},
                new Person(){Name = "Bob", Score = 1},
                new Person(){Name = "Carlos", Score = 5},
                new Person(){Name = "Alilce", Score = 5},
                new Person(){Name = "Ziglar", Score = 10},
                new Person(){Name = "Donald", Score = 7},
            };

            var result = people.OrderByDescending(x => x.Score).ThenBy(x => x.Name);

            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " , " + item.Score);
            }
        }
    }
}

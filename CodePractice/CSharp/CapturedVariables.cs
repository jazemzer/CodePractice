using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{

    delegate void SomeAction();
    class CapturedVariables
    {
        static SomeAction MakeDelegate()
        {
            int x = 0;
            return delegate
            {
                x++;
                Console.WriteLine(x);
            };
        }


        public static void TestScenarios()
        {
            //Learning - Closures close over variables, not over values.
            var values = new List<int>() {100, 110, 120};
            var funcs = new List<Func<int>>();
            foreach (var v in values)
            {
                funcs.Add(() => v);
            }
            foreach (var f in funcs)
            {
                Console.WriteLine(f());
            }


            SomeAction instance = MakeDelegate();
            SomeAction instance2 = MakeDelegate();
            instance();
            instance2();

            SomeAction[] instances = new SomeAction[10];

            int x = 0;
            for (int i = 0; i < 10; i++)
            {
                int y = 0;
                instances[i] = delegate
                {
                    Console.WriteLine("{0}, {1}", x, y);
                    x++;
                    y++;
                };
            }

            instances[0](); // Prints 0, 0
            instances[0](); // Prints 1, 1
            instances[0](); // Prints 2, 2
            instances[1](); // Prints 3, 0
            instances[0](); // Prints 4, 3
            x = 10;
            instances[2](); // Prints 10, 0

            //Console.Read();
        }

    }
}

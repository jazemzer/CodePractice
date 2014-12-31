using System;
using System.IO;
using System.Threading;

namespace CSharp.Threading
{
    public class UsingThreads
    {
        


        public static void Implementation()
        {
            var t = new Thread(CauseException);
            //t.IsBackground = true;
            t.Start();

            var t1 = new Thread(new ParameterizedThreadStart(DoWorkTakeSomethingReturnNothing));
            t1.Start();

            var t2 = new Thread(() => TakeMoreThanOneInputReturnNothing("Test", 1));
            t2.Start();
            var t3 = new Thread(delegate() { TakeMoreThanOneInputReturnNothing("Trial", 2); });
            t3.Start();

            Console.ReadLine();
        }

        private static void CauseException()
        {
            throw null;
        }

        private static void TakeMoreThanOneInputReturnNothing(string name, int age)
        {
            Console.WriteLine(name + " : " + age);
        }
        private static void DoWorkTakeNothingReturnNothing()
        {
            Thread.Sleep(1000);
        }

        private static void DoWorkTakeSomethingReturnNothing(object input)
        {
            Thread.Sleep(1000);
        }
    }
}
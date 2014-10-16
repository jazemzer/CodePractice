using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Threading
{
    public class UsingTasks
    {
        public static void Implementation()
        {
            try
            {
                var t = Task.Factory.StartNew(() => WaitLong(1));                
                var tt = Task.Factory.StartNew(() => SecondThread(t));

                //var s = t.Result;

                //var t1 = ThreadPool.QueueUserWorkItem(new WaitCallback(ThrowException), 11);

                Func<int, string> method = WaitLong;
                IAsyncResult handle = method.BeginInvoke(12,Done,method);
                var result =  method.EndInvoke(handle);

            }
            catch (AggregateException exception)
            {
                
                Console.WriteLine("catught");
            }
            Console.ReadLine();
        }

        private static void Done(IAsyncResult result)
        {
            var target = (Func<int, string>) result.AsyncState;
            Console.WriteLine(target.EndInvoke(result));

        }

        private static void SecondThread(Task<string> t)
        {
            var charac = t.Result;
            Console.WriteLine(charac);
            
        }

        private static string WaitLong(int i)
        {
            Thread.Sleep(5000);
            return "J";
        }

        private static void ThrowException(object o)
        {
            throw null;
        }

        private static string ThrowException()
        {
            throw null;
        }
    }
}

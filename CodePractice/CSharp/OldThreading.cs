using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp
{
    public class OldThreading
    {
        public static void TestScenarios()
        {
            // 1 - Vanilla style
            //      when you want to name a thread 
            //      control the priority
            //      determine if its background or foreground thread
            //      Exceptions will bring down the whole process if unhandled in the same thread
            //      If you wanna pass data to the thread, use ParameterizedThreadStart delegate that takes object data

           var t = new Thread(new ThreadStart(Go));
            t.IsBackground = true; //Foreground thread makes the whole process wait until they're completed
            t.Start();

            var t1 = new Thread(new ParameterizedThreadStart(GoParameterized));
            t1.Start("Hello");

            //ThreadPool demerits
            //      Runs always as backgroundThread
            //      Cannot alter priorrity
            //      Cannot name them for easy debugging

            // 2 - Using Threadpool - (a) QueueUserWorkItem            
            //      Can pass data but no return values
            //      Exceptions bring down the process
            ThreadPool.QueueUserWorkItem(new WaitCallback(GoParameterized) , "Entering threadpool using queue");
            

            // 3 - Using threadpool - (b) Asynchronous Delegates
            //      Can pass any number of parameters
            //      Can return value 
            //      Exceptions get passed to the thread that calls EndInvoke
            Func<string, string, string> method = ReturnText;
            IAsyncResult handle = method.BeginInvoke("Hello! ","Bob",null, null);

            //.. do something here

            //string result = method.EndInvoke(handle);
            //Console.WriteLine(result);
            

            // 
            Console.WriteLine("*********** Threading Ended **********");
            Console.Read();



        }

        public static string ReturnText(string greeting, string name)
        {
            Console.WriteLine("Using Asynchronous delegates...");
            //throw new NullReferenceException();
                        
            return greeting + name;
        }
     
        public static void GoWithException(object message)
        {
            Console.WriteLine("Inside Exception thread");
            //throw new NullReferenceException(); //This
        }

        public static void Go()
        {
            Console.WriteLine("Inside simple thread");
        }

        public static void GoParameterized(object message) //Only one parameter of type object is allowed when used along with Parameterized thread start
        {
            Console.WriteLine("Inside parameterized...");
            Console.WriteLine(message);
            //throw new NullReferenceException(); 
        }
    }
}


//PaameterizedThreadStart and ThreadStart delegate is used 
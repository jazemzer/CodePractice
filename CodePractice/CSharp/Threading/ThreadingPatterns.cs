using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Threading
{
    /// <summary>
    ///     Patterns - http://www.microsoft.com/en-in/download/details.aspx?id=19222
    ///     http://msdn.microsoft.com/en-us/library/ff963553.aspx
    /// </summary>
    public class ThreadingPatterns
    {

        public static void Implementation()
        {
            Console.WriteLine(Environment.ProcessorCount);
            MyParallelFor(1, 80, i => {
                Random rnd = new Random();
                Thread.Sleep(rnd.Next(1000));
                Console.WriteLine(i);
            });
        }

        public static void MyParallelForWithThreadPool(
int inclusiveLowerBound, int exclusiveUpperBound, Action<int> body)
        {
            // Determine the number of iterations to be processed, the number of
            // cores to use, and the approximate number of iterations to process in
            // each thread.
            int size = exclusiveUpperBound - inclusiveLowerBound;
            int numProcs = Environment.ProcessorCount;
            int range = size / numProcs;
            // Keep track of the number of threads remaining to complete.
            int remaining = numProcs;
            using (ManualResetEvent mre = new ManualResetEvent(false))
            {
                // Create each of the threads.
                for (int p = 0; p < numProcs; p++)
                {
                    int start = p * range + inclusiveLowerBound;
                    int end = (p == numProcs - 1) ?
                    exclusiveUpperBound : start + range;
                    ThreadPool.QueueUserWorkItem(delegate
                    {
                        for (int i = start; i < end; i++) body(i);
                        if (Interlocked.Decrement(ref remaining) == 0) mre.Set();
                    });
                }
                // Wait for all threads to complete.
                mre.WaitOne();
            }
        }

        public static void MyParallelFor( int inclusiveLowerBound, int exclusiveUpperBound, Action<int> body)
        {
            // Determine the number of iterations to be processed, the number of
            // cores to use, and the approximate number of iterations to process 
            // in each thread.
            int size = exclusiveUpperBound - inclusiveLowerBound;
            int numProcs = Environment.ProcessorCount;
            int range = size / numProcs;
            // Use a thread for each partition. Create them all,
            // start them all, wait on them all.
            var threads = new List<Thread>(numProcs);
            for (int p = 0; p < numProcs; p++)
            {
                int start = p * range + inclusiveLowerBound;
                int end = (p == numProcs - 1) ?
                exclusiveUpperBound : start + range;
                threads.Add(new Thread(() =>
                {
                    for (int i = start; i < end; i++) body(i);
                }));
            }
            foreach (var thread in threads) thread.Start();
            foreach (var thread in threads) thread.Join();
        }
                
        public static void TestScenarios()
        {
            try
            {
                Task.Factory.StartNew(GoWithException, null);
                //t.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }    
            Console.Read();

            Console.WriteLine("*********** New Threading Ended **********");
        }


        public static void GoWithException(object message)
        {
            Console.WriteLine("Inside Exception thread");
            //throw new NullReferenceException(); //This will bring down the whole process if unhandled in the same function
        }

        
    }
}



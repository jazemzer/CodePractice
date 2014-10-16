using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp
{
    public class NewThreading
    {
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



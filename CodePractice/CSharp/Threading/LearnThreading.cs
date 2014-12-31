using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Threading
{
    public class LearnThreading
    {
        public static void Implementation()
        {
            try
            {
                //These two lines below will bring down the process
                //var t = new Thread(CauseException);
                //t.Start();

                var t1 = new TaskFactory().StartNew(CauseReferenceException);    // Just this line alone swallows exception and keeps the process alive
                
                t1.Wait();

                var t2 = new TaskFactory().StartNew(() => { return CauseReferenceException(0); });
                var result = t2.Result;

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Caught Null reference");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Generic Exception");
            }
        }

        private static void CauseReferenceException()
        {
            throw new NullReferenceException();
        }

        private static string CauseReferenceException(int a)
        {
            if( a == 0)
            {
                throw new ArgumentNullException();
            }
            return "Success";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodePractice.CSharp.Threading
{
    public class Closures
    {

        public static void Implementation()
        {
            
            //for(int i = 0 ; i < 10; i++)
            //{
            //    new Thread(() =>
            //    {
            //        Console.WriteLine(i);
            //    }).Start();
            //}

            for (int i = 0; i < 10; i++)
            {
                var temp = i;
                new Thread(() =>
                {
                    Console.WriteLine(temp);
                }).Start();
            }

        }
                
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Interfaces
    {
        public static void TestScenarios()
        {

            #region Explicitly implemented interface member and backward comptaibilty example

            var test = new MyImplementation().GetNumber(); //Calls int
            var test2 = ((IB)new MyImplementation()).GetNumber(); //Calls double

            #endregion
        }

    }

    #region Explicitly implemented Interface
    public interface IA
    {
        int GetNumber();
    }

    public interface IB
    {
        double GetNumber();
    }

    public class MyImplementation : IB
    {
        public int GetNumber()
        {
            return 5;
        }
        /* Explicit interface member implementations have different accessibility characteristics than other members. 
         * Because explicit interface member implementations are never accessible through their fully qualified name in a method invocation 
         * or a property access, they are in a sense private. However, since they can be accessed through an interface instance,
         * they are in a sense also public.
         * 
         * ...explicit interface member implementations are not accessible through class or struct instances, 
         * they allow interface implementations to be excluded from the public interface of a class or struct
         */
        double IB.GetNumber()
        {
            return GetNumber();
        }
    }
    #endregion
}

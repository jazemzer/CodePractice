using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Structs
    {
        public static void TestScenarios()
        {
            #region Difference between struct and class
            Point p = new Point(10, 10);
            object box = p;
            p.x = 20;
            Console.Write(((Point)box).x); //Changing Point to a class will yield a different result
            #endregion
        }
    }

    #region Struct vs Class
    struct Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    #endregion


    #region Does Struct support Generics

    public struct StructA<T>
    {
        public T MyProperty { get; set; }
    }
    #endregion

    #region Struct cannot have user-defined inheritance
    //public struct StructA : IA
    //{
    //    public string Trial { get; set; }
    //    public int GetNumber()
    //    {
    //        return 5;
    //    }
    //}

    //public struct StructB : StructA, IB
    //{        
    //    public double GetNumber()
    //    {
    //        return 5.0;
    //    }
    //}
    #endregion
}

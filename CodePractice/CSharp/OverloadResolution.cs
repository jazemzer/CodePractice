using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
   

   
    class A
    {
        public virtual void Show()
        {
            Console.WriteLine("A.Show()");
        }
    }

    class B : A
    {
        public override void Show()
        {
            Console.WriteLine("B.Show()");
        }
    }
    class C : B
    {
        public virtual void Show()
        {
            Console.WriteLine("C.Show()");
        }
    }
    class D : C
    {
        public void Show()
        {
            Console.WriteLine("D.Show()");
        }
    }

    class Employee
    {
        public virtual void CalculateSalary(int month)
        {
            Console.WriteLine("Employee.CalculateSalary(int)");
        }
    }

    class Manager : Employee
    {
        public override void CalculateSalary(int month)
        {
            Console.WriteLine("Manager.CalculateSalary(int)");
        }

        public void CalculateSalary(object month)
        {
            Console.WriteLine("Manager.CalculateSalary(object)");
        }
    }


    class OverloadResolution
    {
        static void Foo(int x, double y)
        {
            Console.WriteLine("Foo(int x, double y)");
        }

        static void Foo(double x, int y)
        {
            Console.WriteLine("Foo(double x, int y)");
        }

        public static void TestScenarios()
        {
            /*
             * Learnings
             * 
             * If there exists generic and non-generic method with same signature, the non generic method would take preference 
             */
            F<int>(5);
            F(10);

            /* When there is an overriden method matching still preference is given to methods in the current class
             */
            Employee mgr = new Manager();
            int month = 10;
            mgr.CalculateSalary(month);

            TestOverloading();
            Console.Read();
        }

        public static void TestOverloading()
        {
            C c = new C();
            A a = new A();
            a = c;
            Console.WriteLine(a.GetType());
            a.Show();
            c.Show();
            
            A aa = new D();
            aa.Show();

            C bb = new D();
            bb.Show();

        }

        static void F()
        {
            Console.WriteLine("F()");
        }
        static void F(object x)
        {
            Console.WriteLine("F(object)");
        }
        static void F(int x)
        {
            Console.WriteLine("F(int)");
        }
        static void F(double x)
        {
            Console.WriteLine("F(double)");
        }
        static void F<T>(T x)
        {
            Console.WriteLine("F<T>(T)");
        }
        static void F(double x, double y)
        {
            Console.WriteLine("F(double, double)");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDemo
{
    class Program
    {
        delegate void DemoDelegate();

        static void Main(string[] args)
        {
            DemoDelegate delegateHello = new DemoDelegate(MethodHello);
            DemoDelegate delegateHi = new DemoDelegate(MethodHi);
            delegateHello();
            delegateHi();
            Console.WriteLine("--------------------");

            DemoDelegate multiDelegate = new DemoDelegate(MethodHello);
            multiDelegate += MethodHi;
            multiDelegate();
            Console.WriteLine("--------------------");

            multiDelegate -= MethodHi;
            multiDelegate();
            Console.WriteLine("--------------------");

            multiDelegate = MethodHi;
            multiDelegate();

            Console.ReadKey();
        }

        static void MethodHello()
        {
            Console.Write("--Hello!\n");
        }
        static void MethodHi()
        {
            Console.Write("--Hi!\n");
        }
    }
}

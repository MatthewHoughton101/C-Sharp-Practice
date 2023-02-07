using Practice;
using System;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld.Hello();
            string inputs = PracticeInputs.InputTest();
            Console.WriteLine(inputs);

        }
    }
    class HelloWorld
    {
        public static void Hello()
        {
            Console.WriteLine("Hello World!");
        }
    }

    class PracticeInputs
    {
        public static string InputTest()
        {
            Console.WriteLine("Marco");
            string polo = Console.ReadLine();
            return polo;
        }
    }
}



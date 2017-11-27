using AttributeDemo.Attributes;
using System;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        [Producer(Topic ="",Group ="")]
        public void Producer()
        {

        }
    }
}

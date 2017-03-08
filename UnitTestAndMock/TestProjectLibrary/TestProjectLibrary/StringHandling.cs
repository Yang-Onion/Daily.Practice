using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProjectLibrary
{
    public class StringHandling
    {
        public string Contact(string name, string surname)
        {
            return $"{name}{surname}";
        }

        public string InitalAndCleanUp()
        {
            return "InitalAndCleanUp";
        }

        public double Divide(double first, double second)
        {
            if (second.Equals(0))
            {
               throw  new DivideByZeroException();
            }
            return first/second;
        }

    }
}

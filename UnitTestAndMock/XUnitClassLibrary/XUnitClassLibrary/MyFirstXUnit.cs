using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitClassLibrary
{


    public class NeedTestObj
    {
        public int Fibonacci(int num)
        {

            if (num ==1 || num==2)
            {
                return 1;
            }
            return Fibonacci(num-1)+Fibonacci(num-2);

        }
    }

    //1:nuget->xunit
    //2:Resharper->Extension Manager->xunit.net for resharper

    public class MyFirstXUnit
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(2,Add(1,1));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(1,Add(1,0));
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(8)]
        [InlineData(9)]
        public void MyFirstTheory(int number)
        {
            Assert.True(IsOdd(number));
        }

        public bool IsOdd(int number)
        {
            return number % 2 == 1;
        }

        [Fact]
        public void FibonacciTest()
        {
            int expected = 55;
            var result = new NeedTestObj().Fibonacci(10);
            Assert.Equal(expected,result);
        }
    }
}

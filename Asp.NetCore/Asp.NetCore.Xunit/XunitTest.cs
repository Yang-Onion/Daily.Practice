﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Asp.NetCore.Xunit
{
    public class XunitTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4,Add(1,3));
        }
        [Fact]
        public void NoPassingTest()
        {
            Assert.Equal(4,Add(2,3));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value%2 == 1;
        }
    }
}

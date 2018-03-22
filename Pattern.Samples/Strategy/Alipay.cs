using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Samples.Strategy
{
    public class Alipay:IPay
    {
        public void Pay(decimal payMoney)
        {
            Console.WriteLine($"Alipay,Money:{payMoney}");
        }
    }
}

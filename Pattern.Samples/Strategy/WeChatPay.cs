using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Samples.Strategy
{
    public class WechatPay : IPay
    {
        public void Pay(decimal payMoney)
        {
            Console.WriteLine($"WechatPay,Money:{payMoney}");
        }
    }
}

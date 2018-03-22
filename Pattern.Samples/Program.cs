using Pattern.Samples.Strategy;
using System;

namespace Pattern.Samples
{
    class Program
    {
        static void Main(string[] args)
        {

            StrategyContext context = new StrategyContext(new WechatPay());
            context.PayMoney(1024);

            Console.Read();
        }
    }
}

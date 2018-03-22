using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Samples.Strategy
{
    public class StrategyContext
    {
        private IPay _iPay;
        public StrategyContext(IPay ipay)
        {
            _iPay = ipay;
        }

        public void PayMoney (decimal money)
        {
            _iPay.Pay(money);
        }
    }
}

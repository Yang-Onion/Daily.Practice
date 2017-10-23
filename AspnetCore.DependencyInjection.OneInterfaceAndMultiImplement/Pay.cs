using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore.DependencyInjection.OneInterfaceAndMultiImplement
{

    public interface IPay
    {
        string Charge(PayBase payBase);
    }
    public abstract class PayBase
    {
        public string Id { get; set; }
        public string Account { get; set; }
    }
    public class AliPay : IAlipay
    {
        public string Charge(PayBase payBase)
        {
            var accont = payBase as AliPayAccount;
            return accont.ToString();
        }
    }
    public class WeChatPay : IWeChatPay
    {
        public string Charge(PayBase payBase)
        {
            var accont = payBase as WeChatAccount;
            return accont.ToString();
        }
    }
    public class AliPayAccount : PayBase
    {
        public decimal AipayMoney { get; set; }

        public override string ToString()
        {
            return $"Aipay:Id-{Id},Account-{Account},WeChatMoney-{AipayMoney}";
        }
    }
    public class WeChatAccount : PayBase
    {
        public decimal WeChatMoney { get; set; }

        public override string ToString()
        {
            return $"WeChat:Id-{Id},Account-{Account},WeChatMoney-{WeChatMoney}";
        }
    }


    public interface IAlipay:IPay
    {
    }

    public interface IWeChatPay : IPay
    {

    }

}

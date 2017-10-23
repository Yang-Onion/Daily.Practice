using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCore.DependencyInjection.OneInterfaceAndMultiImplement.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IPay _pay;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAlipay _alipay;
        private readonly IWeChatPay _weChatpay;
        public ValuesController(IServiceProvider serviceProvider, IAlipay alipay,IWeChatPay weChatPay)
        {
            _serviceProvider = serviceProvider;
            _alipay = alipay;
            _weChatpay = weChatPay;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string info = string.Empty;
            var services  = _serviceProvider.GetServices<IPay>();
            switch (id)
            {
                case 0:
                    var alipay = new AliPayAccount
                    {
                        Id = "100001",
                        Account = "yang@alipay.com",
                        AipayMoney = 100
                    };

                    //_pay = services.First(g=>g.GetType()==typeof(AliPay));
                    //info=_pay.Charge(alipay);
                    info = _alipay.Charge(alipay);
                    break;
                case 1:
                    var weChat = new WeChatAccount
                    {
                        Id = "200002",
                        Account = "yang@wechat.com",
                        WeChatMoney = 200
                    };
                    //_pay = services.First(g => g.GetType() == typeof(WeChatPay));
                    //info=_pay.Charge(weChat);
                    info = _weChatpay.Charge(weChat);
                    break;
                default:
                    break;
            }
            

            return info;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

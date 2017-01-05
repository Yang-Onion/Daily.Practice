using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Costom.Authorize.MiddleWare
{
    public class BaseResponseResult
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}

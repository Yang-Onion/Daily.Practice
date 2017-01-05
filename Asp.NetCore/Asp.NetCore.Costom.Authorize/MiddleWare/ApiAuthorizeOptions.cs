using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Costom.Authorize.MiddleWare
{
    public class ApiAuthorizeOptions
    {
        public string Name { get; set; }

        public string EncryptKey { get; set; }

        public int ExpiredSecond { get; set; }
    }
}

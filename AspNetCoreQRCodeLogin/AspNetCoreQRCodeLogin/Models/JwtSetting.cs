using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreQRCodeLogin.Models
{
    public class JwtSetting
    {
        public string Issure { get; set; }
        public string Audience { get; set; }

        public string SecrectKey { get; set; }
    }
}

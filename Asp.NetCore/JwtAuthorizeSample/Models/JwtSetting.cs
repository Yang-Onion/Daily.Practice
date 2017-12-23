using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthorizeSample
{
    public class JwtSetting
    {
        public string Isuuer { get; set; }
        public string Audience { get; set; }

        public string SecrectKey { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreQRCodeLogin.Models
{
    public enum QRCodeStatus
    {
        NEW,
        SCANED,
        CONFIRMED,
        REFUSED,
        EXPIRED
    }
}

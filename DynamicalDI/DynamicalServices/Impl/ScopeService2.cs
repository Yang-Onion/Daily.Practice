using DynamicalServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicalServices.Impl
{
    public class ScopeService2 : ISco2
    {
        public string GetCurrentTime()
        {
            return $"CurrentTime:{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
        }
    }
}

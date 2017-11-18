using DynamicalServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DynamicalServices.Impl
{
    public class ScopeService : ISco1
    {
        public string GetCurrentThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId.ToString();
        }
    }
}

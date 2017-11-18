using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicalServices.Interface
{
    public interface ISingle1:ISingleton
    {
        string GetCurrentThreadId();
    }
}

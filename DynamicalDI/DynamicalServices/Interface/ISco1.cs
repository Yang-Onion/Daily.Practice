using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicalServices.Interface
{
    public interface ISco1:IScope
    {
        string GetCurrentThreadId();
    }
}

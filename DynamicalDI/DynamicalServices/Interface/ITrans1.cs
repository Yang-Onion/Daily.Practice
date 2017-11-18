using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicalServices.Interface
{
    public interface ITrans1:ITransient
    {
        string GetCurrentThreadId();
    }
}

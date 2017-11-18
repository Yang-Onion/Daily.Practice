using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicalServices.Interface
{
    public interface ITrans2:ITransient
    {
        string GetCurrentTime();
    }
}

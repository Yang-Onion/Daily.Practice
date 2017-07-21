using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreXunitAndMoqDemo.Service
{
    public interface ICustomer
    {
        void AddCall();
        string GetCall();
        string GetCall(string userName);

        string GetAddress(string userName, out string address);
        string GetFamilyCall(ref string phone);

        string Greet(string userName);

        void ShowException(string message);

    }
}

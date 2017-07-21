using AspNetCoreXunitAndMoqDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreXunitAndMoqDemo.Service
{
    public interface IStudentService
    {
        bool Create(Student student);
    }
}

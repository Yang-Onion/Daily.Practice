using AspNetCoreXunitAndMoqDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreXunitAndMoqDemo.Service
{
    public interface IStudentRepository
    {
        void Add(Student student);
    }
}

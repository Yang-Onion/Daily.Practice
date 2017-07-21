using AspNetCoreXunitAndMoqDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreXunitAndMoqDemo.Service
{
    public class StudentService:IStudentService
    {
        IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public bool Create(Student student)
        {
            _studentRepository.Add(student);
            return true;
        }
    }
}

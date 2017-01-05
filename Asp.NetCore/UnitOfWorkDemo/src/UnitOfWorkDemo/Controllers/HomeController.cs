using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Service;
using UnitOfWork.Model;

namespace UnitOfWorkDemo.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnit _uint;

        public HomeController(IUnit unit)
        {
            _uint = unit;
        }

        public IActionResult Index()
        {
            string studentId = Guid.NewGuid().ToString();
            Student student= new Student() {StudentId= studentId ,StudentName="Yang"};
            string courseId = Guid.NewGuid().ToString();
            Course course= new Course() {CourseId=courseId,CourseName="UnitOfWork"};
            StudentCourseMaps studentCourseMaps= new StudentCourseMaps() {StudentId=studentId,CourseId=courseId};

            _uint.AddStudent(student);
            _uint.AddCourse(course);
            _uint.AddStudentCourseMap(studentCourseMaps);



            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

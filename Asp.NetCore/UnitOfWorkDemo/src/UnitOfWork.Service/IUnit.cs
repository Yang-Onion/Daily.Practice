using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkModel;

namespace UnitOfWorkService
{
    public interface IUnit
    {
        int AddStudent(Student student);

        int AddCourse(Course course);

        int AddStudentCourseMap(StudentCourseMaps studentCourseMaps);
    }
}

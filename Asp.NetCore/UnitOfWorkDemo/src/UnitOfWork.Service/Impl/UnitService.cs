using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkInfrastructure.Data;
using UnitOfWorkModel;

namespace UnitOfWorkService.Impl
{
    public class UnitService : IUnit
    {
        private  readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<Student> _studentRepository;
        private readonly DbSet<Course> _courseRepository;
        private readonly DbSet<StudentCourseMaps> _studentCourseMapsesRepository;

        public UnitService(IDemoUnit demoUnit)
        {
            _unitOfWork = demoUnit;
            _studentRepository = _unitOfWork.Set<Student>();
            _courseRepository = _unitOfWork.Set<Course>();
            _studentCourseMapsesRepository = _unitOfWork.Set<StudentCourseMaps>();
        }

        public int AddStudent(Student student)
        {
            _studentRepository.Add(student);
            return _unitOfWork.Commit();
        }

        public int AddCourse(Course course)
        {
            _courseRepository.Add(course);
            return _unitOfWork.Commit();
        }

        public int AddStudentCourseMap(StudentCourseMaps studentCourseMaps)
        {
            _studentCourseMapsesRepository.Add(studentCourseMaps);
            return _unitOfWork.Commit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitOfWorkModel
{
    public class Course
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }
}

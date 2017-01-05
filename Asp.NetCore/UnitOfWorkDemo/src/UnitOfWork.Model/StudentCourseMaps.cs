using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkModel
{
    public class StudentCourseMaps
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("StudentId")]
        public string StudentId { get; set; }

        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
    }
}

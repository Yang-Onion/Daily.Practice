using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Migration.Demo.Model
{
    public class Student
    {
        [Key]
        public int StuId { get; set; }
        public string StuName { get; set; }

        public DateTime BirthDate { get; set; } = DateTime.Now;

        public int? Age { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}

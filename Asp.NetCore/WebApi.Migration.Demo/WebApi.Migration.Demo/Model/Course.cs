using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Migration.Demo.Model
{
    public class Course
    {
        [Key]
        public int CoId { get; set; }
        public string CourseName { get; set; }
    }
}

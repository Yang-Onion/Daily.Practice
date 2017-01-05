using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitOfWorkModel
{
    public class Student
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StudentId { get; set; }
        public string StudentName { get; set; }
    }
}

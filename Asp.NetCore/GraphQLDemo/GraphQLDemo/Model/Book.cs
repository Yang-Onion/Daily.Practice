using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Model
{
    public class Book
    {
        [Key]
        [Column(TypeName ="varchar(20)")]
        public string Isbn { get; set; }

        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }

        public Author Author { get; set; }


    }
}

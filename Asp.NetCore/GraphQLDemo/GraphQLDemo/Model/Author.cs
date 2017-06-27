using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Model
{
    public class Author
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Column(TypeName ="datetime2(0)")]
        public DateTime Birthdate { get; set; }

        [Column("NickName",Order =2,TypeName ="varchar(20)")]
        public string  SecondName { get; set; }
    }
}

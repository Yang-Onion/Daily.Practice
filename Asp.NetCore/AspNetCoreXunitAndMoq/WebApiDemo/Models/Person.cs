using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="LastName必填")]
        public string LastName { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Phone必填")]
        [Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email必填")]
        [EmailAddress(ErrorMessage = "Email格式不正确")]
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Migration.Demo.Model
{
    public class PersonPhoto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public byte[] Photo { get; set; }
        public string Caption { get; set; }
        public Person PhotoOf { get; set; }
    }
}

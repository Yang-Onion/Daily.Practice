using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Migration.Demo.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Lodging> PrimaryContactFor { get; set; }
        public List<Lodging> SecondContactFor { get; set; }

        public PersonPhoto Photo { get; set; }
    }
}

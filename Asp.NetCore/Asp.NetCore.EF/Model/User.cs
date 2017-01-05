using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.EF.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Role> Roles { get; set; }
    }
}

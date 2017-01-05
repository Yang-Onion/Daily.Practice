using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.EF.Model
{
    public class Role
    {
        public int RoleId { get; set; }
        public RoleType RoleTyp { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

    public enum RoleType
    {
        Admin,
        User
    }
}

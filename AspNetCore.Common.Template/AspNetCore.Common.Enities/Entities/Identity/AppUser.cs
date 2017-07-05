using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspNetCore.Common.Enities.Entities.Identity
{
    public class AppUser: IdentityUser
    {
        public override string Id { get; set; }
        public override string Email { get; set; }
        public override string UserName { get; set; }
    }
}

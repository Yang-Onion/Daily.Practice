using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPractice.AuthorizationPolicy
{
    public class MinimumAgeRequirement:IAuthorizationRequirement
    {
        public int MinAge { get; set; }
        public MinimumAgeRequirement(int age) {
            MinAge = age;
        }
    }
}

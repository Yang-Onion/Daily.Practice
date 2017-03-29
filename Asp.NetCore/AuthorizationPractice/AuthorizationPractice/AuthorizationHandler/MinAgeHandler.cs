using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthorizationPractice.AuthorizationPolicy;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPractice.AuthorizationHandler
{
    public class MinAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement) {
            if (!context.User.HasClaim(t=>t.Type== ClaimTypes.DateOfBirth)) {
                return Task.CompletedTask;
            }
            else {
                var birthDate = Convert.ToDateTime( context.User.Claims.Where(g => g.Type == ClaimTypes.DateOfBirth).First().Value);
                var age = DateTime.Now.Year - birthDate.Year;
                if (age>=requirement.MinAge) {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;

        }
    }
}

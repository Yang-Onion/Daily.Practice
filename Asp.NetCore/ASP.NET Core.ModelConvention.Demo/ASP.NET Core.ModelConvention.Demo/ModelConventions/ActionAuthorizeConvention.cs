using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ASP.NETCore.ModelConvention.Demo.ModelConventions
{
    public class ActionAuthorizeConvention : IActionModelConvention
    {

        public void Apply(ActionModel action) {
            if (ShouldApplyConvention(action)) {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                action.Filters.Add(new AuthorizeFilter(policy));
            }
        }

        /// <summary>
        /// action上面没有Authorize和AllowAnonymous 才应用我们全局设置的授权特性
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private bool ShouldApplyConvention(ActionModel action) {
            return !action.Attributes.Any(t => t.GetType().Equals(typeof(AuthorizeAttribute))) 
                   && 
                   !action.Attributes.Any(g => g.GetType().Equals(typeof(AllowAnonymousAttribute)));

        }
    }
}

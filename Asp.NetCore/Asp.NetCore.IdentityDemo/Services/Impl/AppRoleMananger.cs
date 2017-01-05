using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Asp.NetCore.IdentityDemo.Services.Impl
{
    public class AppRoleManager : RoleManager<IdentityRole>
    {
        public AppRoleManager(IRoleStore<IdentityRole> store, IEnumerable<IRoleValidator<IdentityRole>> roleValidators,
               ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<IdentityRole>> logger,
               IHttpContextAccessor contextAccessor): base(store, roleValidators, keyNormalizer, errors, logger, contextAccessor) {
        }

        public override Task<IdentityRole> FindByIdAsync(string roleId) {
            return Roles.Include(x => x.Claims).FirstOrDefaultAsync(r => r.Id.Equals(roleId));
        }

        public List<IdentityRole> FindAllRoles() {
            var list = Roles.ToList();
            return list;
        }

        public List<IdentityRole> FindAllRoleByName(IList<string> names) {
            var list = Roles.Where(t => names.Contains(t.Name));
            return list.ToList();
        }

        //public async Task<IdentityResult> ModifyClaims(IdentityRole role, List<RoleMap> roleMap) {
        //    var oldRoleClaims = new List<string>();
        //    var newRoleClaims = new List<string>();
        //    foreach (var temp in role.Claims) {
        //        oldRoleClaims.Add(temp.ClaimValue);
        //    }
        //    foreach (var temp in roleMap) {
        //        newRoleClaims.Add(temp.MenuId);
        //    }
        //    var delTemp = oldRoleClaims.Except(newRoleClaims);//待删
        //    var addTemp = newRoleClaims.Except(oldRoleClaims);//待增
        //    IdentityResult returns = null;
        //    foreach (var a in delTemp) {
        //        returns = await RemoveClaimAsync(role, new Claim("Menu", a));
        //    }
        //    foreach (var a in addTemp) {
        //        returns = await AddClaimAsync(role, new Claim("Menu", a));
        //    }
        //    return returns;
        //}
    }
}
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Asp.NetCore.IdentityDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Asp.NetCore.IdentityDemo.Services.Impl
{
    public class SignInManager : SignInManager<AppUser>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ISession _session;
        private readonly UserManager<AppUser> _userManager;

        public SignInManager(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<AppUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<AppUser>> logger)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger) {
            _session = contextAccessor.HttpContext.Session;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        //public override async Task SignInAsync(AppUser user, bool isPersistent, string authenticationMethod = null) {
        //    var needAddClaims = AppClaims(user);

        //    //删除现有的Claims ，重新Add
        //    var claims = await _userManager.GetClaimsAsync(user);
        //    await _userManager.RemoveClaimsAsync(user, claims);

        //    await _userManager.AddClaimsAsync(user, needAddClaims);

        //    await base.SignInAsync(user, isPersistent, authenticationMethod);
        //}

        //private IEnumerable<Claim> AppClaims(AppUser user) {
        //    return new List<Claim>() {
        //       new Claim(AppKeys.CLAIM_MODULETYPE, ((int)user.ModuleType).ToString()),
        //       new Claim(ClaimTypes.Email, user.Email),
        //       new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
        //    };
        //}
    }
}
using System.Threading.Tasks;
using Asp.NetCore.IdentityDemo.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCore.IdentityDemo.Controllers
{
    [Authorize]
    public class SysController : Controller
    {

        private readonly AppRoleManager _appRoleManager;

        public SysController(AppRoleManager appRoleManager)
        {
            _appRoleManager = appRoleManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddRole(IdentityRole identityRole)
        {
            var role = identityRole??new IdentityRole();
            var result = await _appRoleManager.CreateAsync(role);
            return new JsonResult(new {Successed = result.Succeeded, Errors = result.Errors});
        }


    }
}
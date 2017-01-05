using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore.EF.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore.EF.Controllers
{
    public class HomeController : Controller
    {

        private readonly EFCoreContext _efCoreContext;
        public HomeController(EFCoreContext efCoreContext)
        {
            _efCoreContext =efCoreContext;
        }

        public IActionResult Index()
        {
            //var roles= new List<Role>();
            //User user = new User() {Location = "Chengdu.Sichuan", Name = "Yang",Roles = roles};
            //var role = new Role() { RoleTyp = RoleType.Admin, User = user };
            //roles.Add(role);
            //var blog = new Blog() {Id = Guid.NewGuid().ToString(), BlogAuthor = user, Content = "博客正文", Title = "博客标题"};

            //_efCoreContext.Users.Add(user);
            //_efCoreContext.Roles.Add(role);
            //_efCoreContext.Blog.Add(blog);
            //_efCoreContext.SaveChanges();

            ViewBag.BlogInfo = _efCoreContext.Blog.Include(g => g.BlogAuthor).FirstOrDefault().BlogAuthor.Name;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ViewComponentDemo.Components
{
    public class MenuViewComponent : ViewComponent
    {

        //下面两个方法都可以
        public IViewComponentResult Invoke() {

            var dic = new Dictionary<int, string>();
            for (int i = 0; i < 10; i++) {
                dic.Add(i, $"链接{i}");
            }
            return View("menu",dic);
        }

        //public async Task<IViewComponentResult> InvokeAsync() {

        //    var dic = new Dictionary<int, string>();
        //    for (int i = 0; i < 10; i++) {
        //        dic.Add(i, $"链接{i}");
        //    }
        //    return View("menu", dic);
        //}
    }
}

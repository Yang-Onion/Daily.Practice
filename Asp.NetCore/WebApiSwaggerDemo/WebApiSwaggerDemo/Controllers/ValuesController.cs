using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiSwaggerDemo.Model;

namespace WebApiSwaggerDemo.Controllers
{
    [Route("api/[controller]")]
    //[Produces("application/json")]
    public class ValuesController : Controller
    {
        private readonly List<string> list = new List<string>();
        private List<User> listUser = new List<User>(); 
       public ValuesController() {
            list.Add("value1");
            list.Add("value2");
            list.Add("value3");
        }
        /// <summary>
        /// 获取所有字符串
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return list;
        }

        /// <summary>
        /// 根据Id获取特定字符串
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (list.Count()< id) {
                return "out of range";
            }
            return list[id];
        }

        /// <summary>
        /// 增加元素
        /// </summary>
        /// <param name="value"></param>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //    list.Add(value);
        //}

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public void Post([FromBody]User user) {
            listUser.Add(user);
        }

        /// <summary>
        /// 修改元素
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            if (list.Count() < id) {
                throw new IndexOutOfRangeException("数据越界");
            }
            list[id] = value;
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (list.Count() < id) {
                throw new IndexOutOfRangeException("数据越界");
            }
            list.RemoveAt(id);
        }
    }
}

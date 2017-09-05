using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace RefitDemo
{
    class Program
    {
        static async  Task Main(string[] args)
        {
            /* 
            var istudent = RestService.For<IStudent>("http://wld.cmswl.com");

            var students =  await istudent.GetStudents();

            students.ForEach(x=>{
                Console.WriteLine($"编号：{x.Id},姓名:{x.Name},出生年月:{x.Birthday}");
            });
*/

            var begin = Convert.ToDateTime(DateTime.Now.AddDays(-3).ToShortDateString());
            var end = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            var temp =end.Subtract(begin);
            Console.WriteLine(temp);
        }
    }

    public interface IStudent{

        [Get("/api/v1/students")]
        Task<List<Student>> GetStudents();
    }    


    public class Student{
        public int Id{get;set;}
        public string Name{get;set;}
        public DateTime Birthday{get;set;}
    }
}

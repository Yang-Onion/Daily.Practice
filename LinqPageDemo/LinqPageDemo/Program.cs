using System;
using System.Collections.Generic;
using System.Linq;
using LinqPageDemo.Page;

namespace LinqPageDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            StudentQueryDto queryDto= new StudentQueryDto();
            queryDto.PageSize = 2;
            //PageIndex从0开始
            queryDto.PageIndex = 1;
            List<Student> user = new List<Student>()
            {
                new Student() {Id="1",Name = "Student1" },
                new Student() {Id="2",Name = "Student2" },
                new Student() {Id="3",Name = "Student3" },
                new Student() {Id="4",Name = "Student4" },
                new Student() {Id="5",Name = "Student5" },
                new Student() {Id="6",Name = "Student6" },
                new Student() {Id="7",Name = "Student7" },
            };
            var result = (
                          from c in user
                          select c
                         ).AsQueryable().ToPagedList(queryDto);

            foreach (var item in result.Items)
            {
                Console.WriteLine($"学生编号{item.Id},学生姓名{item.Name}");
            }
            Console.ReadKey();
        }
    }
}
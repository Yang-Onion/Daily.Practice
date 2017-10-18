using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Controllers;
using WebApiDemo.Models;
using WebApiDemo.Services;
using Xunit;

namespace WebApiDemo.Test
{
    public class PersonControllerUnitTest
    {
        [Fact]
        public void Get_All()
        {
            var controller = new PersonController(new PersonService());

            var result = controller.Get();

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;

            var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Person>>().Subject;

            persons.Count().Should().Be(50);
        }
        [Fact]
        public void Get_One()
        {
            var randomPersonId = new Random().Next(1, 50);
            var controller = new PersonController(new PersonService());

            var result = controller.Get(randomPersonId);

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var randomPerson = okResult.Value.Should().BeAssignableTo<Person>().Subject;

            randomPerson.Id.Should().Be(randomPersonId);
        }

        [Fact]
        public  async Task Person_Add()
        {
            var controller = new PersonController(new PersonService());
            var newPerson = new Person
            {
                FirstName = "yang",
                LastName = "yang",
                Age = 18,
                Title = "Dev",
                Email = "dev@126.com"
            };
            var result =await controller.Post(newPerson);

            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;

            var person = okResult.Value.Should().BeOfType<Person>().Subject;

            person.Id.Should().Be(51);
        }

        [Fact]
        public void Person_Update()
        {
            var service = new PersonService();
            var controller = new PersonController(service);
            var newPerson = new Person
            {
                FirstName = "yang2017",
                LastName = "yang2017",
                Age = 28,
                Title = "manager",
                Email = "manager@126.com"
            };
            var result =  controller.Put(30,newPerson);
            var okResult = result.Should().BeOfType<NoContentResult>().Subject;

            var person = service.Get(30);

            person.FirstName.Should().Be("yang2017");
            person.LastName.Should().Be("yang2017");
            person.Age.Should().Be(28);
            person.Title.Should().Be("manager");
            person.Email.Should().Be("manager@126.com");
        }
        [Fact]
        public void Person_Delete()
        {
            var service = new PersonService();
            var controller = new PersonController(service);
            
            var randomPersonId = new Random().Next(0, new PersonService().GetAll().Count());
            var result = controller.Delete(randomPersonId);
            var okResult = result.Should().BeOfType<NoContentResult>().Subject;

            AssertionExtensions.ShouldThrow<InvalidOperationException>(() => service.Get(randomPersonId));
        }

        [Fact]
        public void Person_GetAll_From_Service_Moq()
        {
            var mockService = new Mock<IPersonService>();
            mockService.Setup(x => x.GetAll()).Returns(() => new List<Person>
            {
                 new Person{Id=1, FirstName="张三", LastName="zhangsan"},
                 new Person{Id=2, FirstName="李四", LastName="lisi"},
                 new Person{Id=3, FirstName="王五", LastName="wangwu"},
            });

            var controller = new PersonController(mockService.Object);

            var result = controller.Get();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var persons = okResult.Value.Should().BeOfType<List<Person>>().Subject;
            persons.Count().Should().Be(3);
        }
    }
}

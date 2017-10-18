using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Models;
using Xunit;

namespace WebApiDemo.Test
{
    public class PersonsControllerIntegrationTests
    {
        private readonly TestServer _testServer;
        private readonly HttpClient _client;

        public PersonsControllerIntegrationTests()
        {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _testServer.CreateClient();
        }

        [Fact]
        public async Task IntegrationTest_Person_GetAll()
        {
            //Act
            var response = await _client.GetAsync("/api/person");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //Assert
            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(responseString);
            persons.Count().Should().Be(50);
        }

        [Fact]
        public async Task IntegrationTest_Person_GetOne()
        {
            //act
            var response = await _client.GetAsync("/api/person/18");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //assert
            var person = JsonConvert.DeserializeObject<Person>(responseString);
            person.Id.Should().Be(18);
        }

        [Fact]
        public async Task IntegrationTest_Person_Add()
        {
            //arrange
            var newPerson = new Person
            {
                FirstName = "yang",
                LastName = "yang",
                Age = 18,
                Title = "Dev",
                Phone="13689001121",
                Email = "dev@126.com"
            };
            var serializedPerson = JsonConvert.SerializeObject(newPerson);
            var  stringSerializedPerson = new StringContent(serializedPerson,Encoding.UTF8,"application/json");

            //act
            var response = await _client.PostAsync("/api/person", stringSerializedPerson);


            //assert
            response.EnsureSuccessStatusCode();
            var responseStr = await response.Content.ReadAsStringAsync();
            var person = JsonConvert.DeserializeObject<Person>(responseStr);
            person.Id.Should().Equals(51);
        }

        [Fact]
        public async Task IntegrationTest_Person_Add_InValidate()
        {
            //arrange
            var newPerson = new Person
            {
                FirstName = "yang",
                Email="xxx.com"
            };
            var serilizePerson = JsonConvert.SerializeObject(newPerson);
            var encodeSerilizePerson = new StringContent(serilizePerson, Encoding.UTF8, "application/json");
            
            //act
            var response = await _client.PostAsync("/api/person", encodeSerilizePerson);

            //assert
            var responseString = await response.Content.ReadAsStringAsync();

            responseString.Should().Contain("LastName必填")
                .And.Contain("Phone必填")
                .And.Contain("Email格式不正确");
        }


        [Fact]
        public async Task IntegrationTest_Person_Update()
        {
            //arrange
            var newPerson = new Person
            {
                Id=15,
                FirstName = "yang",
                LastName = "yang",
                Age = 18,
                Title = "Dev",
                Email = "dev@126.com",
                Phone="13689046565"
            };
            var serializedPerson = JsonConvert.SerializeObject(newPerson);
            var stringSerializedPerson = new StringContent(serializedPerson, Encoding.UTF8, "application/json");

            //act
            var response = await _client.PutAsync("/api/person/15", stringSerializedPerson);

            //assert
            response.EnsureSuccessStatusCode();

            var responseStr = await response.Content.ReadAsStringAsync();

            responseStr.Should().Be(string.Empty);

            //var secResponse = await _client.GetAsync("/api/person/15");
            //secResponse.EnsureSuccessStatusCode();
            //var responseString = await secResponse.Content.ReadAsStringAsync();
            //var person = JsonConvert.DeserializeObject<Person>(responseString);

            //person.FirstName.Should().Be("yang");
            //person.LastName.Should().Be("yang");
            //person.Age.Should().Be(18);
            //person.Title.Should().Be("manager");
            //person.Email.Should().Be("manager@126.com");
        }

        [Fact]
        public async Task IntegrationTest_Person_Delete()
        {

            //act
            var response = await _client.DeleteAsync("/api/person/49");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Be(string.Empty);
        }
    }
}

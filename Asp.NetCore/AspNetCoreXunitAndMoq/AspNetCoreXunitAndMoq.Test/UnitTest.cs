using AspNetCoreXunitAndMoqDemo;
using AspNetCoreXunitAndMoqDemo.Service;
using Moq;
using System;
using Xunit;

namespace AspNetCoreXunitAndMoq.Test
{
    public class UnitTest
    {
        [Fact]
        public void Caculation_Add_Test()
        {
            Caculation cal = new Caculation();
            var result = cal.Add(1, 2);

            Assert.True(result == 3);
        }

        [Theory]
        [InlineData(2,3,5)]
        [InlineData(3, 7, 21)]
        [InlineData(8,4, 12)]
        public void Caculation_Add_InlineData_Test(int i,int j,int sum)
        {
            Caculation cal = new Caculation();
            var result = cal.Add(i,j);
            Assert.True(result == sum);
        }

        [Theory]
        [InlineData(2, 0, 0)]
        public void Caculation_Divid_Exception_Test(int i,int j,int result)
        {
            Caculation cal = new Caculation();
            Assert.Throws<Exception>(()=>{ cal.Divid(i, j); });
        }

        [Fact]
        public void Stub_Test()
        {
            IStudentRepository stub = new StubStudentRepository();

            StudentService service = new StudentService(stub);

            var hasCreated = service.Create(null);
            Assert.True(hasCreated);
        }

        [Fact]
        public void Mock_Test()
        {
            var studentRepository = new Mock<IStudentRepository>();
            StudentService service = new StudentService(studentRepository.Object);
            var hasCreated = service.Create(null);
            Assert.True(hasCreated);
        }
    }
}  

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


        #region Moq Demos

        [Fact]
        public void Moq_Test()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();

            customer.Setup(p => p.AddCall());
            customer.Setup(g => g.GetCall()).Returns("13889046585");
            customer.Setup(g => g.GetCall("Yang")).Returns("17313126773");

            customer.Object.AddCall();
            Assert.Equal("13889046585", customer.Object.GetCall());
            Assert.Equal("17313126773", customer.Object.GetCall("Yang"));
            Assert.NotEqual("13889046585", customer.Object.GetCall("Yang"));

            //out ref
            var address = "China";
            var phone = string.Empty;
            customer.Setup(g => g.GetAddress("userName", out address)).Returns("Chengdu");
            customer.Setup(g => g.GetFamilyCall(ref phone)).Returns("028-65201120");

            Assert.Equal("Chengdu", customer.Object.GetAddress("userName", out address));
            Assert.Null(customer.Object.GetAddress("userName2", out address));
            Assert.Equal("028-65201120", customer.Object.GetFamilyCall(ref phone));

            //has return value
            customer.Setup(g => g.Greet(It.IsAny<string>())).Returns((string username) => "Hello," + username);
            Assert.Equal("Hello,Yang", customer.Object.Greet("Yang"));

            //throw exception
            customer.Setup(g => g.ShowException(string.Empty)).Throws(new ArgumentNullException("参数不能为空"));
            Assert.Throws<ArgumentNullException>(() => customer.Object.ShowException(string.Empty));

            //set value
            var addCount = 0;
            customer.Setup(g => g.AddCall()).Callback(() => addCount++);
            Assert.Equal(0, addCount);

            customer.Object.AddCall();
            Assert.Equal(1, addCount);

            customer.Object.AddCall();
            Assert.Equal(2, addCount);
        }

        #endregion
    }
}  

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestProjectLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        //[TestMethod]
        //public void TestContact()
        //{
        //    //Arange
        //    StringHandling handling= new StringHandling();
        //    //Act
        //    var contactStr = handling.Contact("Hello", "World");
        //    //Assert
        //    Assert.AreEqual("HelloWorld",contactStr);

        //    //第一个值和第二个值之间不超过50就通过，超过了就不通过
        //    //Assert.AreEqual(100,200,delta:50);
        //}

        #region TestCleanUp and TestInitialize

        private StringHandling _obj;
        private string _value;

        [TestCleanup]
        public void CleanUp()
        {
            _obj = null;
            _value = string.Empty;
        }

        [TestInitialize]
        public void InitalAndCleanUp()
        {
            _obj= new StringHandling();
            _value = _obj.InitalAndCleanUp();
        }
        [TestMethod]
        public void InitalAndCleanUpTest1()
        {
            Assert.AreEqual(_value,_obj.InitalAndCleanUp());
        }

        [TestMethod]
        public void InitalAndCleanUpTest2()
        {
            Assert.AreEqual(_value, _obj.InitalAndCleanUp());
        }

        #endregion

        #region CollectionAssert

        [TestMethod]
        public void CollectionAssertTest()
        {
            List<string> first = new List<string>();
            first.Add("a");

            List<string> second = new List<string>();
            second.Add("a");

            CollectionAssert.AreEqual(first,second);

        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideTest()
        {
            var result = _obj.Divide(10, 0);
            Assert.AreEqual(10,result);
        }


        #endregion

        [TestMethod]
        public void MockTest()
        {
            Mock<CheckEmployee> mock = new Mock<CheckEmployee>();
            mock.Setup(x => x.CheckEmp()).Returns(false);
            ProcessEmployee process= new ProcessEmployee();
            Assert.AreEqual(process.InsertEmployee(mock.Object), true);
        }


        [TestMethod]
        public void TestA() {
            C c = new C();
        }
    }

    public class CheckEmployee
    {
        public virtual bool CheckEmp()
        {
            throw  new NotImplementedException();
        }
    }

    public class ProcessEmployee
    {
        public bool InsertEmployee(CheckEmployee checkEmployee)
        {
            checkEmployee.CheckEmp();
            return true;
        }
    }

    
    public class A
    {
        public A() {
            Debug.Write("A");
        }
    }

    public class B
    {
        A a = new A();
        public B() {

        }
    }

    public class C : B
    {
        A a = new A();
        public C() {

        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
           /*
            //singleton

            //strategy
            StrategyContext context= new StrategyContext(new Add());
            Console.WriteLine($"strategy:{context.GetCaculateValue(1, 2)}");

            //SimpleFactory
            var cacl = SimpleFactory.SimpleFactory.Create(OpertaionEnum.Add);
            Console.WriteLine($"simpleFactory:{cacl.Cacl(2, 3)}");

            //FactoryMethod
            LogFactory factory= new FileLogFactory();
            Log log = factory.Create();
            log.WriteLog();

            //AbstractFactory
            */

            //observer

            //SmsObserver sms= new SmsObserver();
            //AccountObserver accountObserver = new AccountObserver(10000);
            //CreditCard creditCard= new CreditCard();
            //creditCard.SpendMoney += sms.Update;
            //creditCard.SpendMoney += accountObserver.Update;
            //creditCard.SpendAmout = 1024;

            Subject subject= new Subject();

            Observer1 observer1= new Observer1();
            Observer2 observer2= new Observer2();
            ;
            subject.Register(observer1);
            subject.Register(observer2);
            subject.Notify("First Subject");
            subject.UnRegister(observer1);
            subject.Notify("Second Subject");


            Console.ReadLine();

        }
    }

    #region
    /*
    《C#高效编程50个行之有效的办法》
    创建某个类型的第一个实例时,所进行的操作顺序为:
    1.静态变量设置为0
    2.执行静态变量初始化器
    3.执行基类的静态构造函数
    4.执行静态构造函数
    5.实例变量设置为0
    6.执行衯变量初始化器
    7.执行基类中合适的实例构造函数
    8.执行实例构造函数

    同样类型的第二个以及以后的实例将从第五步开始执行.

    public class A
    {
        public static readonly int x;
        static A()
        { 
            Console.WriteLine($"B.y={B.y}");
            Console.WriteLine($"A.x={x}");
            x = B.y + 1;
        }
    }

    class B
    {
        public static int y = A.x + 1;

        static void Main(string[] args)
        {
            Console.WriteLine("x:{0},y:{1}。", A.x, y);
            Console.ReadLine();
        }
    }
    */

    #endregion



}

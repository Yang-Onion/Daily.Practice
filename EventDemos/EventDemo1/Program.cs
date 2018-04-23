using System;

namespace EventDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test1
            /*
            WechatSubscriber subscriber = new WechatSubscriber("WeChat");
            TencentGameObserver observer = new TencentGameObserver();

            observer.Subscriber=subscriber;
            observer.Symbol="TencentGame";
            observer.Info="We have a new game published...";

            observer.Update();
            */
            #endregion


            #region Test2
            /*
            TencentGame tencentGameObserver= new TencentGameObserver("TencentGame","Have a new game published.");
            tencentGameObserver.AddObserver(new Subscriber("Jack's wechat "));
            tencentGameObserver.AddObserver(new Subscriber("Tom's wechat"));

            tencentGameObserver.Update();
            */
            #endregion


            #region Test3
            /*
            Tencent tencent = new TencentGame("TencentGame","Have a new game published.");
            Subscriber tom= new Subscriber("Tom");
            Subscriber jack = new Subscriber("Jack");

            tencent.AddObserver(new NotifyEventHandler(tom.ReceiveData));
            tencent.AddObserver(new NotifyEventHandler(jack.ReceiveData));

            tencent.Update();
            Console.WriteLine("--------------------");

            Console.WriteLine("移除订阅者:tom");

            tencent.RemoveObserver(new NotifyEventHandler(tom.ReceiveData));
            tencent.Update();


            */
            #endregion

            #region Meditor
            var meditor = new Mediator();

            var colleagueA = new ConcreteColleagueA(meditor);
            var colleagueB = new ConcreteColleagueB(meditor);

            meditor.ColleagueA=colleagueA;
            meditor.ColleagueB=colleagueB;

            colleagueA.SendMessage("你好B，中午一起饭吧？");
            colleagueB.SendMessage("你好A，好的。");
            #endregion


            Console.ReadKey();
        }
    }
}

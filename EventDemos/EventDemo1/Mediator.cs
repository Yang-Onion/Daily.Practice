using System;

namespace EventDemo1{

    public abstract class AbstractMediator{

        public abstract void SendMessage(string msg,AbstractColleague colleague);
    }

    public class Mediator : AbstractMediator
    {
        public AbstractColleague ColleagueA;
        public AbstractColleague ColleagueB;
        public override void SendMessage(string msg, AbstractColleague colleague)
        {
            if (colleague == ColleagueA){
                ColleagueB.PrintMsg(msg);
            }
            else if(colleague==ColleagueB){
                ColleagueA.PrintMsg(msg);
            }
        }
    }


    public abstract class AbstractColleague{
        public string Name{get;set;}
        protected AbstractMediator Mediator;
        public AbstractColleague(AbstractMediator mediator){
            Mediator=mediator;
        }
        public abstract void PrintMsg(string message);
    }

    public class ConcreteColleagueA : AbstractColleague
    {
        public ConcreteColleagueA(AbstractMediator mediator) : base(mediator)
        {
        }

        public void SendMessage(string msg){
            Mediator.SendMessage(msg,this);
        }
        public override void PrintMsg(string message)
        {
           Console.WriteLine($"ColleagueA receive message:{message}");
        }
    }

    public class ConcreteColleagueB : AbstractColleague
    {
        public ConcreteColleagueB(AbstractMediator mediator) : base(mediator)
        {
        }

        public void SendMessage(string msg){
            Mediator.SendMessage(msg,this);
        }
        public override void PrintMsg(string message)
        {
            Console.WriteLine($"ColleagueB receive message:{message}");
        }
    }


}
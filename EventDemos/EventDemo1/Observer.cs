using System;
using System.Collections.Generic;

namespace EventDemo1
{
    #region  Test1
    /*
    public class TencentGameObserver
    {
        public WechatSubscriber Subscriber;
        public string Symbol{get;set;}
        public string Info{get;set;}

        public void Update(){
            if(Subscriber != null){
                Subscriber.ReceiveData(this);
            }
        }
    }


    public class WechatSubscriber
    {
        public string Name{get;set;}
        public WechatSubscriber(string name){
          this.Name=name;
        }

        public void ReceiveData(TencentGameObserver tencentGameObserver){
            Console.WriteLine($"Notified {Name} of {tencentGameObserver.Symbol}'s Info is:{tencentGameObserver.Info}.");
        }
    }

    */
    #endregion

    #region Test2
    /*
    public abstract class TencentGame
    {
       private List<IObserver> _list = new List<IObserver>();
       public string Symbol{get;set;}
       public string Info{get;set;}
       public TencentGame(string symbol,string info){
           this.Symbol=symbol;
           this.Info=info;
       }

        public void AddObserver(IObserver observer){
            if(!_list.Contains(observer)){
                _list.Add(observer);
            }      
        }

        public void RemoveObserver(IObserver observer){
            if (_list.Contains(observer)){
                _list.Remove(observer);
            }
        }

        public void Update(){
            if(_list.Count>0){
                foreach (IObserver observer in _list){
                    if (observer != null){
                        observer.ReceiveData(this);
                    }
                }
            }
        }

    }

    public class TencentGameObserver:TencentGame
    {
        public TencentGameObserver(string symbol,string info):base(symbol,info){

        }
    }

    public interface  IObserver{
        void ReceiveData(TencentGame observer);
    }


    public class Subscriber : IObserver
    {
        public string Name{get;set;}
        public Subscriber(string name){
            this.Name=name;
        }

        public void ReceiveData(TencentGame observer)
        {
            Console.WriteLine($"Notified {Name} of {observer.Symbol}'s Info is:{observer.Info}.");
        }
    }
      */
    #endregion
  
    #region Test3

    public delegate void NotifyEventHandler(object sender);

    public class Tencent{
        public NotifyEventHandler NotifyEvent;

        public string Symbol{get;set;}
        public string Info{get;set;}

        public Tencent(string symbol,string info){
            this.Symbol=symbol;
            this.Info=info;
        }

        public void AddObserver(NotifyEventHandler o){
            NotifyEvent +=o;
        }

        public void RemoveObserver(NotifyEventHandler o){
            NotifyEvent -=o;
        }

        public void Update(){
            if (NotifyEvent != null){
                NotifyEvent(this);
            }
        }
    }

    public class TencentGame:Tencent{
        public TencentGame(string symbol,string info):base(symbol,info){

        }
    }


    public class Subscriber{
        public string Name{get;set;}
        public Subscriber(string name){
            this.Name=name;
        }

        public void ReceiveData(object obj){
            Tencent tencent = obj as Tencent;
            if(tencent != null){
                Console.WriteLine($"Notified {Name} of {tencent.Symbol}'s Info is:{tencent.Info}.");
            }
        }
    }
    #endregion

}
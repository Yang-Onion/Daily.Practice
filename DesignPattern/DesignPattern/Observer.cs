using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    #region
    
    public class CreditCard : EventArgs
    {
        private float _spendAmount;

        public event EventHandler<CreditCard> SpendMoney;

        public float SpendAmout
        {
            get
            {
                return _spendAmount;
            }
            set
            {
                _spendAmount = value;
                Notify();
            }
        }

        private void Notify()
        {
            SpendMoney?.Invoke(this, this);
        }
    }

    public interface IObserver<T>
    {
        void Update(Object sender, T t);
    }

    public class SmsObserver : IObserver<CreditCard>
    {
        public void Update(object sender, CreditCard t)
        {
            Console.WriteLine($"Sms notify.Spend {t.SpendAmout}");
        }
    }

    public class AccountObserver : IObserver<CreditCard>
    {
        private float _accountAmount;
        public AccountObserver(float accountAmount)
        {
            _accountAmount = accountAmount;
        }

        public void Update(object sender, CreditCard t)
        {
            _accountAmount -= t.SpendAmout;
            Console.WriteLine($"Account amount is {_accountAmount}");
        }
    }

    #endregion

    public class Subject
    {
        private readonly List<IObserver> _observerList;

        public Subject()
        {
            _observerList = new List<IObserver>();
        }
        public void Register(IObserver observer)
        {
            if (!_observerList.Contains(observer))
            {
                _observerList.Add(observer);
            }
        }

        public void UnRegister(IObserver observer)
        {
            if (_observerList.Contains(observer))
            {
                _observerList.Remove(observer);
            }
        }

        public void Notify(string msg)
        {
            foreach (var observer in _observerList)
            {
                observer?.Update(msg);
            }
        }
         
    }

    public interface IObserver
    {
        void Update(string msg);
    }

    public class Observer1 : IObserver
    {
        public void Update(string msg)
        {
            Console.WriteLine($"Observer1........{msg}");
        }
    }

    public class Observer2 : IObserver
    {
        public void Update(string msg)
        {
            Console.WriteLine($"Observer2......{msg}");
        }
    }
}

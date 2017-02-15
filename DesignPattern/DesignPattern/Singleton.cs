using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public sealed class SimpleSingleton
    {
        private static SimpleSingleton _instance ;
        SimpleSingleton() { }

        public SimpleSingleton Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new SimpleSingleton();
                }
                return _instance;
            }
        }
    }

    public sealed class LockSingleton
    {
        static LockSingleton _instance;
        static  readonly  object obj = new object();

        LockSingleton()
        {
        }

        public LockSingleton Instance
        {
            get
            {
                lock (obj)
                {
                    if (_instance == null)
                    {
                        _instance = new LockSingleton();
                    }
                }
                return _instance;
            }

        }

        public LockSingleton DoubleLockInstance
        {
            get
            {
                if (_instance==null)
                {
                    lock (obj)
                    {
                        if (_instance==null)
                        {
                            _instance=new LockSingleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    public sealed class StaticSingleton
    {
        private static readonly StaticSingleton _instance;
        static StaticSingleton()
        {
            _instance = new StaticSingleton();
        }

        public StaticSingleton()
        {

        }

        public StaticSingleton Instance
        {
            get { return _instance; }
        }
    }

}

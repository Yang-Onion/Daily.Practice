using System;
using System.Threading;
using System.Threading.Tasks;

namespace AnyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"主线程Id:{Thread.CurrentThread.ManagedThreadId}");

            //try
            //{

            //    ThreadPool.QueueUserWorkItem(GetName);
            //    new Thread(Go).Start();
            //    Task.Factory.StartNew(Go);
            //    Task.Run(new Action(Go));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception");
            //}

            //Console.ReadLine();



        }


        public static void Go()
        {
            Console.WriteLine($"我是另一个线程Go:{Thread.CurrentThread.ManagedThreadId}");
        }

        public static void  GetName(object data)
        {
            Console.WriteLine($"我是另一个线程GetName:{Thread.CurrentThread.ManagedThreadId}");
        }



        public  async Task TestExceptionAsync()
        {
            await OutterTask();
        }

        public async Task OutterTask()
        {
            try
            {
                await InnerTask();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task InnerTask()
        {

            try
            {
                throw new Exception("AAAA");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}

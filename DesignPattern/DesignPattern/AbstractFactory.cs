using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public abstract class Log
    {
        public abstract void WriteLog();
    }

    public class FileLog:Log
    {
        public override void WriteLog()
        {
           Console.WriteLine("FileLog~~~~~");
        }
    }

    public class DbLog:Log
    {
       public override void WriteLog()
        {
            Console.WriteLine("DbLog~~~~~");
        } 
    }
    
    public abstract class LogFactory
    {
        public abstract Log Create();
    }

    public class FileLogFactory : LogFactory
    {
        public  override Log Create()
        {
            return new FileLog();
        }
    }

    public class DbLogFactory : LogFactory
    {
        public override Log Create()
        {
            return new DbLog();
        }
    }

}

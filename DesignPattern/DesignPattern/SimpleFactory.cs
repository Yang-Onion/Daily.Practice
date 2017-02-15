using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SimpleFactory
{
    public class SimpleFactory
    {
        public static Caculate Create(OpertaionEnum operation)
        {
            switch (operation)
            {
                case OpertaionEnum.Add:
                    return  new Add();
                case OpertaionEnum.Minus:
                    return new Minus();
                default:
                    return new Add();
            }
        }
    }

    //抽象类Caculate改成ICaculate接口类型也可以
    public abstract class Caculate
    {
        public abstract decimal Cacl(decimal x, decimal y);
    }

    public class Add : Caculate
    {
        public override decimal Cacl(decimal x, decimal y)
        {
            return x + y;
        }
    }

    public class Minus : Caculate
    {
        public override decimal Cacl(decimal x, decimal y)
        {
            return x - y;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    /*
     该模式涉及到三个角色：

     环境角色（Context）：持有一个Strategy类的引用
     抽象策略角色（Strategy）：这是一个抽象角色，通常由一个接口或抽象类来实现。此角色给出所有具体策略类所需实现的接口。
     具体策略角色（ConcreteStrategy）：包装了相关算法或行为。
     */

    public class StrategyContext
    {
        protected ICaculate ICalculate;

        public StrategyContext(ICaculate caculate)
        {
            ICalculate = caculate;
        }

        public decimal GetCaculateValue(decimal x,decimal y)
        {
            return ICalculate.Caculate(x, y);
        }
    }

    public interface ICaculate
    {
        decimal Caculate(decimal x, decimal y);
    }

    public class Add : ICaculate
    {
        public decimal Caculate(decimal x, decimal y)
        {
            return x + y;
        }
    }

    public class Minus : ICaculate
    {
        public decimal Caculate(decimal x, decimal y)
        {
            return x - y;
        }
    }

    public class Mulitply : ICaculate
    {
        public decimal Caculate(decimal x, decimal y)
        {
            return x * y;
        }
    }

    public class Divide : ICaculate
    {
        public decimal Caculate(decimal x, decimal y)
        {
            if (y==0)
            {
                throw  new DivideByZeroException("被除数y不能为0");
            }
            return x / y;
        }
    }

    
}

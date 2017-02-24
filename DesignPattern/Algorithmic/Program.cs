using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 5, 1, 6, 2, 6, 7, 3, 0, 3, 4 };

            BubbleSort.Bubble(list);

            foreach (var i in list)
            {
                Console.Write($"{i} ");
            }
            Console.ReadKey();
        }
    }
}

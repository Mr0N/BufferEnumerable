using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace Ext
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int count = 0;
            var result = Enumerable.Range(0, 10).Select(a=>a+=2).ToBuffer();
            foreach (var item in result)
            {
                Console.WriteLine(item);
                if (item == 5) break;
            }
            Console.WriteLine(new string('-', 5));
            foreach (var item in result)
            {
                count++;
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 5));
            foreach (var item in result)
            {
                count++;
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}

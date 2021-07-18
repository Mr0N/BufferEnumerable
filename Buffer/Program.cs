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
            var result = Enumerable.Range(0, 5).Select(a => count++).ToBuffer();
            foreach (var item in result)
            {
                count++;
                Console.WriteLine(item);
            }
            foreach (var item in result)
                Console.WriteLine(item);
            Console.ReadKey();
        }
    }
}

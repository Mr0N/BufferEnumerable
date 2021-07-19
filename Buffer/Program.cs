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
            var enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
                Console.WriteLine(enumerator.Current);
            }
            enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.ReadKey();
        }
    }
}

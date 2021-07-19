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
            int index = 0;
            int count = 0;
            var result = Enumerable.Range(0, 10).Select(a=>a+=2+ index).ToBuffer();
            var enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
                enumerator.MoveNext();
            }
            enumerator.Dispose();
            Console.WriteLine(new string('-', 10));
            enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
                index = 10;
            }
            Console.WriteLine(new string('-', 10));
            enumerator.Dispose();
            enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
                index = 100;
            }
            enumerator.Dispose();
            Console.ReadKey();
        }
    }
}

using System;
using System.Linq;
using System.Threading;

namespace Ext
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Buffer");
            var result = Enumerable.Range(0, 1)
                .Select(a =>
               {
                   Thread.Sleep(10);
                   return DateTime.Now.Millisecond;
               }).ToBuffer();
            for (int i = 0; i < 10; i++)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("Not Buffer");
            var resultX = Enumerable.Range(0, 1)
               .Select(a =>
               {
                   Thread.Sleep(10);
                   return DateTime.Now.Millisecond;
               });
            for (int i = 0; i < 10; i++)
            {
                foreach (var item in resultX)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();
        }
    }
}

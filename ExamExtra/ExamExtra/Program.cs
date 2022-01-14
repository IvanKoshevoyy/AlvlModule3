using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamExtra
{
    delegate Task<List<T>> del<T>(List<T> list);
    class Program
    {
        static event del<string> MetodHandler;
        static void Main(string[] args)
        {
            Foo();
            Console.ReadLine();
        }

        async static void Foo()
        {

            

            List<string> vs = new List<string>() { "a", "b", "c", "d", "a" };
            MetodHandler += FstMetod;
            MetodHandler += SndMetod;
            MetodHandler += TrdMetod;


            List<string>[] vs1 = await Task.WhenAll(new[] { MetodHandler.Invoke(vs)});

            foreach (var v in vs1)
            {
                foreach (var s in v)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }

            /* List<string> vs = FstMetod<string>(new List<string>() { "a", "b"}).Result;
             foreach (var v in vs)
             {
                 Console.WriteLine(v);
             }
             vs = SndMetod<string>(new List<string>() { "a", "b", "c", "d" }).Result;
             foreach (var v in vs)
             {
                 Console.WriteLine(v);
             }
             vs = TrdMetod<string>(new List<string>() { "c", "b", "c", "d" }).Result;
             foreach (var v in vs)
             {
                 Console.WriteLine(v);
             }*/

        }
        
        async static Task<List<T>> FstMetod<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
                return null;
            return await Task.Run(() => 
            {
                Thread.Sleep(1000);
                return list.Distinct().ToList();
            });
        }

        async static Task<List<T>> SndMetod<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
                return null;
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                return list.Take(3).ToList();
            });
        }
        async static Task<List<T>> TrdMetod<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
                return null;
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                return list.OrderBy((x) => x).ToList();
            });
        }

    }
}


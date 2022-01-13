using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Contatenation().Result);
            Console.ReadLine();
        }
        static async Task<string> HelloReading()
        {
            string result;
            using (StreamReader reader = new StreamReader("Hello.txt"))
            {
                result = await Task.Run(() => reader.ReadToEndAsync());  // асинхронное чтение из файла               
            }
            return result;
        }
        static async Task<string> WorldReading()
        {
            string result;
            using (StreamReader reader = new StreamReader("World.txt"))
            {
                result = await Task.Run(() => reader.ReadToEndAsync());  // асинхронное чтение из файла               
            }
            return result;
        }

        static async Task<string> Contatenation()
        {
            Task<string> t1 = Task.Run(() => HelloReading());
            Task<string> t2 = Task.Run(() => WorldReading());
            await Task.WhenAll(new[] { t1, t2 });
            return t1.Result + " " + t2.Result;
        }

    }
}

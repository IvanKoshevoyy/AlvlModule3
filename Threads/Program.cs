using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int Num = 0;
            bool check1 = false;
            bool check2 = false;
            bool check3 = false;

            Console.Write("Введите число(40-140): ");
            if (Int32.TryParse(Console.ReadLine(), out Num) == false || Num < 40 || Num > 140)
            {
                Console.WriteLine("Неправильно введенное число");
                Num = random.Next(40, 140);
                Console.WriteLine("Сгенерированое число: " + Num);
            }


            Busket busket = new Busket(Num);
            FstPlayer fstPlayer = new FstPlayer();
            SndPlayer sndPlayer = new SndPlayer();
            TrdPlayer trdPlayer = new TrdPlayer();
            Thread thread1 = new Thread(() => { fstPlayer.SearchingNum(busket.Num, ref busket.Counter, ref check1); });
            Thread thread2 = new Thread(() => { sndPlayer.SearchingNum(busket.Num, ref busket.Counter, ref check2); });
            Thread thread3 = new Thread(() => { trdPlayer.SearchingNum(busket.Num, ref busket.Counter, ref check3); });
            thread1.Start();


            thread2.Start();

            thread3.Start();


            while (true)
            {
                if (thread1.IsAlive != true || thread2.IsAlive != true || thread3.IsAlive != true)
                {
                    break;
                }          
            }

            if (check1 == true)
            {
                Console.WriteLine("Первый игрок нашел число");
            }
            else if (check2 == true)
            {
                Console.WriteLine("Второй игрок нашел число");
            }
            else if (check3 == true)
            {
                Console.WriteLine("Третий игрок нашел число");
            }
            else
            {
                Console.WriteLine("Никто не нашел число");
            }

            Console.ReadLine();
        }

    }
}

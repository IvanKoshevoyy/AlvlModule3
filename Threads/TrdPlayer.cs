using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TrdPlayer : IPlayer
    {
        public void SearchingNum(int SearchNum, ref int Counter, ref bool check)
        {
            Random random = new Random();
            int RandNum = 0;
            List<int> Numbers = new List<int>();

            while (Counter != 100)
            {
                do
                {
                    RandNum = random.Next(40, 140);
                    if (Numbers.Contains(RandNum) == false)
                        break;
                } while (true);
                Numbers.Add(RandNum);
                if (SearchNum == RandNum)
                {
                    check = true;
                    return;
                }
                Counter++;
            }
            check = false;
            return;
        }
    }
}

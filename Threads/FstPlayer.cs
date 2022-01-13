using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class FstPlayer : IPlayer
    {
        public void SearchingNum(int SearchNum, ref int Counter, ref bool Check)
        {
            Random random = new Random();

            while(Counter != 100)
            {
                if (SearchNum == random.Next(40, 140))
                {
                    Check = true;
                    return;
                }
                Counter++;
            }
            Check = false;
            return;
        }
    }
}

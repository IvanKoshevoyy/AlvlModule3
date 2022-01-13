using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SndPlayer : IPlayer
    {
        public void SearchingNum(int SearchNum, ref int Counter, ref bool check)
        {
            int CurrentNum = 40;
            while (Counter != 100)
            {
                if (SearchNum == CurrentNum)
                {
                    check = true;
                    return;
                }
                CurrentNum++;
                Counter++;
            }
            check = false;
            return;
        }
    }
}

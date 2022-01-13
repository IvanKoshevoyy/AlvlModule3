using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Busket
    {
        public int Num { get; set; }
        public int Counter;

        public Busket(int Num)
        {
            this.Num = Num;
            Counter = 0;
        }
    }
}

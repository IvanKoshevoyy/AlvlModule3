using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Class2
    {
        private int result;
        bool Result(int x)
        {
            if (result / x == 0)
                return true;
            else
                return false;
        }
        Func<int, bool> Calc(Func<int, int, int> func, int x, int y)
        {
            result = func(x, y);
            return Result;
        }
        
    }
}

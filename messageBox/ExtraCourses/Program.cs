using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraCourses
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBox messageBox = new MessageBox();
            messageBox.closedWindow += (State state) => 
            {
                if (state == 0)
                    Console.WriteLine("operation was succeeded");
                else
                {
                    Console.WriteLine("operation was cancelled");
                }

            };
            messageBox.Open();
            Console.ReadLine();
        }


    }
}

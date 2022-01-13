using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraCourses
{
    delegate void EventHandler(State state);
    class MessageBox
    {
        public EventHandler closedWindow;
        public async void Open()
        {  
            Console.WriteLine("window was opened");
            await Task.Run(() => Thread.Sleep(3000));
            Console.WriteLine("window was closed by user");
            Random random = new Random();
            State state = (State)random.Next(Enum.GetNames(typeof(State)).Length);
            closedWindow?.Invoke(state);
        }
    }
}

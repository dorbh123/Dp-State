using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_State
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(new StandingState());
            player.PressB();
            player.PressDown();
            player.PressDown();
            player.PressDownAndHold();
            Console.ReadLine();
        }
    }
}

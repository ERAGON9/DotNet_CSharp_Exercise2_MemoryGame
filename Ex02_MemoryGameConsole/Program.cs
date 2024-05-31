using Ex02_MemoryGameConsole.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();
            User player1 = new User(playerName);
            Console.WriteLine("The game is against player or computer? " +
                "(enter: player/computer)");
            string opponent = Console.ReadLine();
            if (opponent == "player")
            {

            }
            else
            {

            }
        }
    }
}

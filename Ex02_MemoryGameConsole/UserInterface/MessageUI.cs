using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.UserInterface
{
    internal class MessageUI
    {

        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the memory game!");
        }

        public void PrintNewGameMessage()
        {
            Console.WriteLine("Starting a new game");
        }

        public void PrintQuitMessage()
        {
            Console.WriteLine("You choose to QUIT during the game.");
        }

        public void PrintGoodbyeMessage()
        {
            Console.WriteLine("Game closing, bye bye.");
        }

    }
}

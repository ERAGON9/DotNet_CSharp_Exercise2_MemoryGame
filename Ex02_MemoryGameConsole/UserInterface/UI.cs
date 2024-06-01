using Ex02_MemoryGameConsole.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.UserInterface
{
    internal class UI
    {

        public void manageProgram()
        {
            string Player1Name = RecivePlayerName();
            // recieve second player 
            // Recieve board size.

            GameData gameData = new GameData(Player1Name,);



            while (true)
            {
                //draw board

                //get 1 square
                // UI - check valid input
                // logic - check  if!(in board and not taken)
                //             UI - print error message
            }

        }

        public string RecivePlayerName()
        {
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();

            return playerName;
        }

        public string ReciveSecoundPlayer()
        {
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

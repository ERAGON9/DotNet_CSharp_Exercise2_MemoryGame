using Ex02_MemoryGameConsole.GameLogic;
using Ex02_MemoryGameConsole.UserInterface;
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
            //UI userInterface = new UI();

            //userInterface.manageProgram();

            GameData gameData = new GameData("Lior", "Noa", 6 , 6);
            Console.ReadLine();
        }
    }
}

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
            ProgramUI userInterface = new ProgramUI();

            userInterface.RunProgram();

            //GameData gameData = new GameData("Lior", "Noa", false);

            Console.ReadLine();
        }
    }
}

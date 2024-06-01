using Ex02.ConsoleUtils;
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
            string Player1Name = recivePlayerName();
      
            // recieve second player 
            // Recieve board size.

            GameData gameData = new GameData(Player1Name,);



            while (!isGameOver())
            {
                //print board

                /*choose square*/
                //get 1 square   (if press Q - break)
                // UI - check valid input
                // logic - check  if!(in board and not taken)
                //             UI - print error message

                Screen.Clear();
                //print board

                /*choose square again*/   //(if press Q)
                //need to return the square content

                //logic - check if the 2 cards the same
                //if the same:
                //   givePoint()    

                // else: (if not the same:)
                //      UI-show 2 sec, logic - flip back.
                //      switch current player

            }

            // print the ponits of each player- with player win.
            // if want another game or not.

        }

        private string recivePlayerName()
        {
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();

            return playerName;
        }

        private string chooseSecoundPlayer() //אולי שהמחרוזת תהיה בתור משתנה out
        {
            string name, opponent;

            Console.WriteLine("The game is against player or computer? " +
                                "(enter: player/computer)");
            opponent = Console.ReadLine();
            if (opponent == "player")
            {
                name = recivePlayerName();
            }
            else
            {
                name = "Computer"; //? לא בטוחה איך מתמודד עם זה בפונקציה
            }

            return name;
        }

        private bool isGameOver(GameData i_Game)
        {
            bool gameOver;
            bool isLeftCardsToChoose = i_Game.isThereUnflippedCards();
            
            gameOver = !isLeftCardsToChoose;

            return gameOver;
        }
    }
}

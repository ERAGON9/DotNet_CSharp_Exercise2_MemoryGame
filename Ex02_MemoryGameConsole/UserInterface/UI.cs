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
            GameData game;
            string Player1Name, Player2Name;
            int boardWidth, boardHeight;

            receiveGamePropertiesFromUser(out Player1Name, out Player2Name, out boardWidth, out boardHeight);
            game = new GameData(Player1Name, Player2Name, boardHeight, boardWidth);



            while (!isGameOver(gameData))
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


        private void receiveGamePropertiesFromUser(out string Player1Name, out string Player2Name, out int boardWidth, out int boardHeight)
        {
            Player1Name = receivePlayerName();
            Player2Name = chooseAndReceiveSecoundPlayer();
            boardWidth = receiveBoardWidth();
            boardHeight = receiveBoardHeight();

            //check if even number of squares
        }

        private string receivePlayerName()
        {
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();

            return playerName;
        }

        private string chooseAndReceiveSecoundPlayer() //אולי שהמחרוזת תהיה בתור משתנה out
        {
            string name, opponent;

            Console.WriteLine("The game is against player or computer? " +
                                "(enter: player/computer)");
            opponent = Console.ReadLine();
            if (opponent == "player")
            {
                name = receivePlayerName();
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

        private int receiveBoardWidth()
        {
            int boardWidth;
   
            Console.WriteLine("Enter board width: ");
            boardWidth = receiveMeasure();

            return boardWidth;
        }
        private int receiveBoardHeight()
        {
            int boardHeight;

            Console.WriteLine("Enter board height: ");
            boardHeight = receiveMeasure();

            return boardHeight;
        }

        private int receiveMeasure()
        {
            bool isValidInput = false, isPositive, isInteger;
            int? measure = null;
            string inputStr;

            while (!isValidInput)
            {
                inputStr = (Console.ReadLine());
                isInteger = int.TryParse(inputStr, out int tmpMeasure);
                if (!isInteger)
                {
                    Console.WriteLine("Input must be an integer. Try again\n");
                    continue;
                }

                isPositive = tmpMeasure > 0;
                if (!isPositive)
                {
                    Console.WriteLine("Input must be an positive. Try again\n");
                    continue;
                }

                isValidInput = true;
                measure = tmpMeasure;
            }

            return measure.Value; //Always get value 
        }
        //private bool checkIfValidMeasureInput(string i_MeasureStr)
        //{
        //    bool isInteger, isPositive;
            
        //}
    }
}

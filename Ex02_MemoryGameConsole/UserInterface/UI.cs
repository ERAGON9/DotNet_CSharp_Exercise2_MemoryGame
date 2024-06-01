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
        private GameData m_GameEngine;

        public void runGame()
        {

            try 
            {
                SetGameProperties();
                SetBoardGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


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

        private void SetGameProperties()
        {
            string player1Name, player2Name;
            bool gameAgainstComputer;

            player1Name = receivePlayerName();
            player2Name = chooseAndReceiveSecoundPlayer(out gameAgainstComputer);
            try
            {
                m_GameEngine = new GameData(player1Name, player2Name, gameAgainstComputer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SetGameProperties();
            }
        }

        private void SetBoardGame()
        {
            int boardWidth, boardHeight;

            boardWidth = receiveBoardWidth();
            boardHeight = receiveBoardHeight();
            try
            {
                m_GameEngine.InitialCardsMatrix(boardWidth, boardHeight);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                SetBoardGame();
            }
        }

        private string receivePlayerName()
        {
            string playerName;

            Console.WriteLine("Please enter player name:");
            playerName = Console.ReadLine();

            return playerName;
        }

        private string chooseAndReceiveSecoundPlayer(out bool o_AgainstComputer)
        {
            string secoundPlayerName, opponent;

            Console.WriteLine("The game is against player or computer? " +
                                "(enter: player/computer)");
            opponent = Console.ReadLine();
            if (opponent == "player")
            {
                secoundPlayerName = receivePlayerName();
                o_AgainstComputer = false;
            }
            else if (opponent == "computer")
            {
                secoundPlayerName = "Computer";
                o_AgainstComputer = true;
            }
            else
            {
                throw new Exception("Exception: Incorrect option, choose between player " +
                    " or computer only.");
            }

            return secoundPlayerName;
        }

        private bool isGameOver()
        {
            bool gameOver;
            bool isLeftCardsToChoose = m_GameEngine.IsThereUnflippedCards();
            
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
                inputStr = Console.ReadLine();
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

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
        private bool m_StillPlaying = true;
        //private bool m_PlayerQuit = false;

        public void runGame()
        {


            setGameProperties();
            setBoardGame();

            while (m_StillPlaying)
            {
                Screen.Clear();

                printBoard();

                /*choose square*/
                // get 1 square   (if press Q - break)
                pickSquare();
                if (!m_StillPlaying)
                {
                    break;
                }

                Screen.Clear();
                printBoard();

                /*choose square again*/   //(if press Q)
                                          //need to return the square content
                pickSquare();
                if (!m_StillPlaying)
                {
                    break;
                }

                //logic - check if the 2 cards the same
                //if the same:
                //   givePoint()    

                // else: (if not the same:)
                //      UI-show 2 sec, logic - flip back.
                //      switch current player

                m_StillPlaying = !isGameOver();
            }

            if (isGameOver()) 
            {
                printStatistics();
            }
            else
            {
                Console.WriteLine("Player choose to Quit during the game.");
                Console.WriteLine("Game closing, bye bye.");
            }


            // print the ponits of each player- with player win.
            // if want another game or not.
        }

        private void pickSquare()
        {
            bool isValidSquare = false;
            string square, errorMessage;

            while (!isValidSquare) //logically
            {
                square = getSquare();
                if (!m_StillPlaying)
                {
                    return;
                }

                // logic - check  if not in board and not taken.
                isValidSquare = m_GameEngine.IsValidSquare(square, out errorMessage); // Logic
                if (!isValidSquare)
                {
                    Console.WriteLine(errorMessage);
                }
            }

            m_GameEngine.FlipCard(square);
            m_GameEngine.flipCard1();
            m_GameEngine.flipCard2();
        }

        private string getSquare()
        {
            string playerInput = string.Empty; //Always get value because, always first
                                               //iteration of while loop happens.
            bool isValidSquare = false;

            while (!isValidSquare)
            {
                Console.WriteLine("Please enter square to uncover " +
                    "letter for column and number for row (like: B2) or Q for Quit");
                playerInput = Console.ReadLine();
                if (isUserQuit(playerInput))
                {
                    m_StillPlaying = false;
                    break;
                }

                isValidSquare = squareValidation(playerInput);
            }

            return playerInput;
        }

        private bool isUserQuit(string i_UserInput)
        {
            bool isUserQuit = i_UserInput == "Q";
            
            return isUserQuit;
        }

        private bool squareValidation(string i_Square)
        {
            bool isValid = true;

            if (i_Square.Length != 2 || !char.IsLetter(i_Square[0])
                || !char.IsDigit(i_Square[1]))
            {
                Console.WriteLine("Input is not 1 letter and 1 digit. (at the form of: B2)");
                isValid = false;
            }

            return isValid;
        }
        private void setGameProperties()
        {
            string player1Name, player2Name;
            bool gameAgainstComputer;

            player1Name = receivePlayerName();
            player2Name = chooseAndReceiveSecoundPlayer(out gameAgainstComputer);

            m_GameEngine = new GameData(player1Name, player2Name, gameAgainstComputer);
        }

        private void setBoardGame()
        {
            int boardWidth, boardHeight;
            bool initialSucceeded = false;
            string errorMessage;

            while (!initialSucceeded)
            {
                boardWidth = receiveBoardWidth();
                boardHeight = receiveBoardHeight();

                initialSucceeded = m_GameEngine.InitialCardsMatrix(boardHeight, boardWidth, out errorMessage);
                if (!initialSucceeded)
                {
                    Console.WriteLine(errorMessage + " try again.");
                }
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
   
            Console.WriteLine("Enter board width: (columns)");
            boardWidth = receiveMeasure();

            return boardWidth;
        }

        private int receiveBoardHeight()
        {
            int boardHeight;

            Console.WriteLine("Enter board height: (rows)");
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

            return measure.Value; //Always get value because always first iteration happens
        }

        //private bool checkIfValidMeasureInput(string i_MeasureStr)
        //{
        //    bool isInteger, isPositive;
        //}

        private void printBoard()
        {
            int rows = m_GameEngine.CardsMatrix.GetLength(0);
            int cols = m_GameEngine.CardsMatrix.GetLength(1);

            printBoardFirstRow(cols);
            printBoardEqualsRow(cols);
            printBoardCardsRow(rows, cols);
        }

        private void printBoardFirstRow(int i_Cols)
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append("    ");
            char colCharacter = 'A';
            for (int j = 0; j < i_Cols; j++)
            {
                stringToPrint.Append(colCharacter + "   ");
                colCharacter++;
            }

            stringToPrint.Append("  ");
            Console.WriteLine(stringToPrint);
        }

        private void printBoardEqualsRow(int i_Cols)
        {
            StringBuilder stringToPrint = new StringBuilder();
            
            stringToPrint.Append("  ");
            stringToPrint.Append("==");
            for (int j = 0; j < i_Cols - 1; j++)
            {
                stringToPrint.Append("====");
            }

            stringToPrint.Append("===");
            Console.WriteLine(stringToPrint);
        }

        private void printBoardCardsRow(int i_Rows, int i_Cols )
        {
            StringBuilder stringToPrint = new StringBuilder();

            for (int i = 0; i < i_Rows; i++)
            {
                stringToPrint.Append((i+1) + " ");
                for (int j = 0; j < i_Cols; j++)
                {
                    stringToPrint.Append("| ");
                    if (m_GameEngine.CardsMatrix[i,j].IsFlipped == false)
                    {
                        stringToPrint.Append(' ');
                    }
                    else
                    {
                        stringToPrint.Append(m_GameEngine.CardsMatrix[i, j].Content);
                    }

                    stringToPrint.Append(' ');
                }

                stringToPrint.Append('|');
                Console.WriteLine(stringToPrint);
                printBoardEqualsRow(i_Cols);
                stringToPrint.Clear();
            }
        }


    }
}

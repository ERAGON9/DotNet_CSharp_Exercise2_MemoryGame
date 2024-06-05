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
        private MessageUI m_Messages = new MessageUI();
        private BoardUI m_Board = new BoardUI();
        private bool m_ProgramStillRunning = true;

        public void RunProgram()
        {
            m_Messages.PrintWelcomeMessage();
            while (m_ProgramStillRunning)
            {
                newGame();
            }
            m_Messages.PrintGoodbyeMessage();
        }

        private void newGame()
        {
            m_Messages.PrintNewGameMessage();
            setGameProperties();
            m_Board.SetBoardGame(m_GameEngine);
            runGame();
        }

        private void runGame()
        {
            bool gameOver = false;

            while (!gameOver)
            {
                Screen.Clear();
                m_Board.PrintBoard(m_GameEngine.Board);
                Console.WriteLine(m_GameEngine.GetPlayerNameOfCurrentTurn() + " turn," +
                                  " first square:");
                string chosenSquare1 = getValidSquareFromPlayer();
                if (isPlayerQuit(chosenSquare1))
                {
                    quitGame();
                    break;
                }

                m_GameEngine.FlipCard1InCurrentTurn(chosenSquare1);
                Screen.Clear();
                m_Board.PrintBoard(m_GameEngine.Board);
                Console.WriteLine(m_GameEngine.GetPlayerNameOfCurrentTurn() + " turn," +
                                  " secound square:");
                string chosenSquare2 = getValidSquareFromPlayer();
                if (isPlayerQuit(chosenSquare2))
                {
                    quitGame();
                    break;
                }

                m_GameEngine.FlipCard2InCurrentTurn(chosenSquare2);
                Screen.Clear();
                m_Board.PrintBoard(m_GameEngine.Board);
                bool isAPair = m_GameEngine.IsCardsTheSame();
                m_GameEngine.OperatesByChosenCards();
                if (!isAPair)
                {
                    System.Threading.Thread.Sleep(2000);
                }

                gameOver = isGameOver();
            }

            if (gameOver) 
            {
                printStatistics();
                if (!wantsToPlayAgain())
                {
                    quitGame();
                }
            }
        }

        private bool wantsToPlayAgain()
        {
            string input;
            bool playAgain;

            Console.WriteLine("Play again?");
            Console.WriteLine("Press 1 if you want to play again or 0 to exit");
            input = Console.ReadLine();
            playAgain = input == "1"; //maybe change it to enum or somethig

            return playAgain;
        }

        private void quitGame()
        {
            m_Messages.PrintQuitMessage();
            m_ProgramStillRunning = false;
        }

        private string getValidSquareFromPlayer()
        {
            bool isValidSquare = false;
            string square = string.Empty , errorMessage;

            while (!isValidSquare)
            {
                square = getSquare();
                if (isPlayerQuit(square))
                {
                    break;
                }

                isValidSquare = m_GameEngine.IsValidSquareInput(square, out errorMessage);
                if (!isValidSquare)
                {
                    Console.WriteLine(errorMessage);
                }
            }

            return square;
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
                if (isPlayerQuit(playerInput))
                {
                    break;
                }

                isValidSquare = squareUIValidation(playerInput);
            }

            return playerInput;
        }

        private bool isPlayerQuit(string i_PlayerInput)
        {
            const string quitString = "Q";
            bool isPlayerQuit = i_PlayerInput == quitString;
            
            return isPlayerQuit;
        }

        private bool squareUIValidation(string i_Square)
        {
            bool isValid = true;

            if (i_Square.Length != 2 || !char.IsLetter(i_Square[0])
                || !char.IsDigit(i_Square[1]))
            {
                Console.WriteLine("Input is not 1 letter and 1 digit. (form of: B2)");
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

        private string receivePlayerName()
        {
            string playerName;

            Console.WriteLine("Please enter player name:");
            playerName = Console.ReadLine();

            return playerName;
        }

        private string chooseAndReceiveSecoundPlayer(out bool o_AgainstComputer)
        {
            string secoundPlayerName = string.Empty, opponent;
            bool validInput = false;
            o_AgainstComputer = false; // will be set to true if necessary inside
                                       // the while loop.
            while (!validInput)
            {
                Console.WriteLine("The game is against player or computer? " +
                                  "(enter: player/computer)");
                opponent = Console.ReadLine();
                if (opponent == "player")
                {
                    secoundPlayerName = receivePlayerName();
                    validInput = true;
                }
                else if (opponent == "computer")
                {
                    secoundPlayerName = "Computer";
                    o_AgainstComputer = true;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Incorrect option, choose between player " +
                                      "or computer only, try again.");
                }
            }

            return secoundPlayerName;
        }

        private bool isGameOver()
        {
            bool gameOver;
            bool isLeftCardsToChoose = m_GameEngine.IsThereUnflippedCardsOnBoard();
            
            gameOver = !isLeftCardsToChoose;

            return gameOver;
        }

        private void printStatistics()
        {
            m_GameEngine.GetPlayersScore(out int scorePlayer1, out int scorePlayer2);
            Console.WriteLine("--------GAME OVER--------");
            Console.WriteLine("Player 1 score: " + scorePlayer1 + " points.");
            Console.WriteLine("Player 2 score: " + scorePlayer2 + " points.");
        }
    }
}

using Ex02.ConsoleUtils;
using Ex02_MemoryGameConsole.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.UserInterface
{
    internal class ProgramUI
    {
        private GameData m_GameEngine;
        private MessageUI m_Messages = new MessageUI();
        private BoardUI m_Board = new BoardUI();
        private bool m_ProgramStillRunning = true;
        private const string k_QuitString = "Q";
        private const int k_NumOfPlayers = 2;

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
                updateScreenState();
                firstPartOfTurn();
                if (!m_ProgramStillRunning)
                {
                    break;
                }

                secondPartOfTurn();
                if (!m_ProgramStillRunning)
                {
                    break;
                }

                operatesByChosenCards();
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

        private void firstPartOfTurn()
        {
            Console.WriteLine("{0} turn, first square:", m_GameEngine.GetPlayerNameOfCurrentTurn());
            string chosenSquare1 = chooseSquare();

            if (isPlayerQuit(chosenSquare1))
            {
                quitGame();
                return;
            }

            m_GameEngine.FlipCard1InCurrentTurn(chosenSquare1);
            updateScreenState();
        }

        private void secondPartOfTurn()
        {
            Console.WriteLine("{0} turn, secound square:", m_GameEngine.GetPlayerNameOfCurrentTurn());
            string chosenSquare2 = chooseSquare();

            if (isPlayerQuit(chosenSquare2))
            {
                quitGame();
                return;
            }

            m_GameEngine.FlipCard2InCurrentTurn(chosenSquare2);
            updateScreenState();
        }

        private void updateScreenState()
        {
            Screen.Clear();
            m_Board.PrintBoard(m_GameEngine.Board);
        }

        private void operatesByChosenCards()
        {
            bool isAPair = m_GameEngine.IsCardsTheSame();

            if (isAPair)
            {
                m_GameEngine.AddPointToCurrentPlayer();
            }
            else
            {  
                m_GameEngine.UnflippedCardsForCurrentTurn();
                m_GameEngine.SwitchToNextPlayer();
            }

            System.Threading.Thread.Sleep(2000);
        }

        private string chooseSquare()
        {
            string chosenSquare;
            string currentPlayerType = m_GameEngine.GetCurrenPlayerType();
                
            if (currentPlayerType == "Computer")
            {
                chosenSquare = m_GameEngine.ComputerChoosingSquare();
            }
            else
            {
                chosenSquare = getValidSquareFromPlayer();
            }

            return chosenSquare;
        }

        private bool wantsToPlayAgain()
        {
            const string k_PlayAgainOption = "yes";

            Console.WriteLine("Want another round?");
            Console.WriteLine("For play again choose 'yes' else 'no'.");
            string playAgainOption = getPlayAgainOption();
            bool playAgain = playAgainOption == k_PlayAgainOption;

            return playAgain;
        }

        private string getPlayAgainOption()
        {
            bool isValidInput = false;
            const string k_PlayAgainOption = "yes";
            const string k_QuitOption = "no";
            string input = null;

            while (!isValidInput)
            {
                input = Console.ReadLine();
                if (input == k_PlayAgainOption || input == k_QuitOption)
                {
                    break;
                }

                Console.WriteLine("Invalid option, try again");
            }

            return input;
        }

        private void quitGame()
        {
            m_Messages.PrintQuitMessage();
            m_ProgramStillRunning = false;
        }

        private string getValidSquareFromPlayer()
        {
            bool isValidSquare = false;
            string square = null;
            string errorMessage;

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
            bool isValidSquare = false;
            string playerInput = null; //Always get value because, always first
                                       //iteration of while loop happens.

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
            bool isPlayerQuit = i_PlayerInput == k_QuitString;

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
            string[] playersNames = new string[k_NumOfPlayers];
            string[] playersTypes = new string[k_NumOfPlayers];

            playersNames[0] = receivePlayerName();
            playersTypes[0] = "Player";
            playersNames[1] = chooseAndReceiveSecondPlayer(out playersTypes[1]);
            m_GameEngine = new GameData(k_NumOfPlayers, playersNames, playersTypes);
        }

        private string receivePlayerName()
        {
            Console.WriteLine("Please enter player name:");
            string playerName = Console.ReadLine();

            return playerName;
        }

        private string chooseAndReceiveSecondPlayer(out string o_SecondPlayerType)
        {
            string opponent;
            string secoundPlayerName = null;
            bool validInput = false;
            o_SecondPlayerType = null;

            while (!validInput)
            {
                Console.WriteLine("The game is against player or computer? " +
                                  "(enter: player/computer)");
                opponent = Console.ReadLine();
                if (opponent == "player")
                {
                    o_SecondPlayerType = "Player";
                    secoundPlayerName = receivePlayerName();
                    validInput = true;
                }
                else if (opponent == "computer")
                {
                    o_SecondPlayerType = "Computer";
                    secoundPlayerName = "Computer";
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
            bool isLeftCardsToChoose = m_GameEngine.IsThereUnflippedCardsOnBoard();
            bool gameOver = !isLeftCardsToChoose;

            return gameOver;
        }

        private void printStatistics()
        {
            int[] playersScores = m_GameEngine.GetPlayersScore();
            string[] playersNames = m_GameEngine.GetPlayersNames();

            Console.WriteLine("--------GAME OVER--------");
            Console.WriteLine("{0} score: {1} points.", playersNames[0], playersScores[0]);
            Console.WriteLine("{0} score: {1} points.", playersNames[1], playersScores[1]);
        }
    }
}

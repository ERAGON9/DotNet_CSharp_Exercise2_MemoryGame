using Ex02_MemoryGameConsole.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.UserInterface
{
    internal class BoardUI
    {
        private const int k_MinRowsColsSize = 4;
        private const int k_MaxRowsColsSize = 6;

        public void SetBoardGame(GameData i_GameEngine)
        {
            int boardWidth, boardHeight;
            bool initialSucceeded = false;
            string errorMessage;

            while (!initialSucceeded)
            {
                boardWidth = receiveBoardWidth();
                boardHeight = receiveBoardHeight();
                initialSucceeded = i_GameEngine.TryInitialBoard(boardHeight,
                                                boardWidth, out errorMessage);
                if (!initialSucceeded)
                {
                    Console.WriteLine("{0} try again.", errorMessage);
                }
            }
        }

        private int receiveBoardWidth()
        {
            int boardWidth;

            Console.WriteLine("Enter board width: (number of columns)");
            boardWidth = receiveMeasure();

            return boardWidth;
        }

        private int receiveBoardHeight()
        {
            int boardHeight;

            Console.WriteLine("Enter board height: (number of rows)");
            boardHeight = receiveMeasure();

            return boardHeight;
        }

        private int receiveMeasure()
        {
            bool isValidInput = false;
            int ?measure = null;  //Always get value, because always first iteration
                                  //of while loop happens.
            string inputStr;

            while (!isValidInput)
            {
                inputStr = Console.ReadLine();
                isValidInput = isInteger(inputStr, out int tmpMeasure) &&
                               isSizeInRange(tmpMeasure);
                if (isValidInput)
                {
                    measure = tmpMeasure;
                }
            }

            return measure.Value;
        }

        private bool isInteger(string i_IntAsString, out int o_TmpMeasure)
        {
            bool isValid = int.TryParse(i_IntAsString, out o_TmpMeasure);

            if (!isValid)
            {
                Console.WriteLine("Input must be an integer, try again");
            }

            return isValid;
        }

        private bool isSizeInRange(int i_Number)
        {
            bool isValid = true;

            if (i_Number < k_MinRowsColsSize || i_Number > k_MaxRowsColsSize)
            {
                Console.WriteLine("not at range 4-6 (include), try again.");
                isValid = false;
            }

            return isValid;
        }

        public void PrintBoard(GameBoard i_GameBoard)
        {
            GameBoard board = i_GameBoard;
            int rows = board.Height;
            int cols = board.Width;

            printBoardFirstRow(cols);
            printBoardEqualsRow(cols);
            printBoardCardsRow(rows, cols, board);
        }

        private void printBoardFirstRow(int i_Cols)
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append(' ', 4);
            char colCharacter = 'A';
            for (int j = 0; j < i_Cols; j++)
            {
                stringToPrint.Append(colCharacter);
                stringToPrint.Append(' ', 3);
                colCharacter++;
            }

            stringToPrint.Append(' ', 2);
            Console.WriteLine(stringToPrint);
        }

        private void printBoardEqualsRow(int i_Cols)
        {
            StringBuilder stringToPrint = new StringBuilder();

            stringToPrint.Append(' ', 2);
            stringToPrint.Append('=', 2);
            for (int j = 0; j < i_Cols - 1; j++)
            {
                stringToPrint.Append('=', 4);
            }

            stringToPrint.Append('=', 3);
            Console.WriteLine(stringToPrint);
        }

        private void printBoardCardsRow(int i_Rows, int i_Cols, GameBoard i_Board)
        {
            StringBuilder stringToPrint = new StringBuilder();

            for (int i = 0; i < i_Rows; i++)
            {
                stringToPrint.Append((i + 1) + " ");
                for (int j = 0; j < i_Cols; j++)
                {
                    stringToPrint.Append("| ");
                    if (i_Board.CardsMatrix[i, j].IsFlipped == false)
                    {
                        stringToPrint.Append(' ');
                    }
                    else
                    {
                        stringToPrint.Append(mappingCardContent(i_Board.CardsMatrix[i, j].Content));
                    }

                    stringToPrint.Append(' ');
                }

                stringToPrint.Append('|');
                Console.WriteLine(stringToPrint);
                printBoardEqualsRow(i_Cols);
                stringToPrint.Clear();
            }
        }

        private char mappingCardContent(uint i_CardContent)
        {
            char squareContentUI = (char)('A' + i_CardContent);

            return squareContentUI;
        }
    }
}

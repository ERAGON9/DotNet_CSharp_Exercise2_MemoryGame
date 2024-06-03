using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class GameBoard
    {
        private Card[,] m_CardsMatrix;
        private int m_Width;
        private int m_Height; //not readonly, it can change if choose to play again.
        private int m_NumberOfUnflippedPairs;
        private const int k_MinRowsColsSize = 4;
        private const int k_MaxRowsColsSize = 6;

        //private const bool k_TrueInitialize = true;
        //private const bool k_FalseInitialize = false;

        public int Width
        {
            get
            {
                return m_Width;
            }
        }

        public int Height
        {
            get
            {
                return m_Height;
            }
        }

        public Card[,] CardsMatrix
        {
            get
            {
                return m_CardsMatrix;
            }
        }

        public bool TryInitialGameBoard(int i_Rows, int i_Cols, out string o_ErrorMesage)
        {
            bool isValid = isBoardSizeValid(i_Rows, i_Cols, out o_ErrorMesage);
            
            if (isValid)
            {
                m_Width = i_Cols;
                m_Height = i_Rows;
                m_CardsMatrix = new Card[i_Rows, i_Cols];
                fillCardsMatrix();
            }

            return isValid;
        }

        private bool isBoardSizeValid(int i_Rows, int i_Cols, out string o_ErrorMesage)
        {
            bool isValid = false;

            if (i_Rows < k_MinRowsColsSize || i_Rows > k_MaxRowsColsSize)
            {
                o_ErrorMesage = "Rows not at range 4-6 (include).";
            }
            else if (i_Cols < k_MinRowsColsSize || i_Cols > k_MaxRowsColsSize)
            {
                o_ErrorMesage = "Cols not at range 4-6 (include).";
            }
            else if (i_Rows * i_Cols % 2 != 0)
            {
                o_ErrorMesage = "Board must have an even number of cells.";
            }
            else
            {
                isValid = true;
                o_ErrorMesage = "All valid.";
            }

            return isValid;
        }

        private void fillCardsMatrix()
        {
            int rows = m_Height;
            int cols = m_Width;
            int totalCells = rows * cols;
            char currentCharacter = 'A';
            char[] characters = new char[totalCells];

            for (int i = 0; i < totalCells; i += 2)
            {
                characters[i] = currentCharacter;
                characters[i + 1] = currentCharacter;
                currentCharacter++;
            }

            Random randomNumber = new Random();
            characters = characters.OrderBy(x => randomNumber.Next()).ToArray();
            int charactersArrayIndex = 0;

            //foreach (Card card in m_CardsMatrix)

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    m_CardsMatrix[i, j] = new Card(characters[charactersArrayIndex]);
                    charactersArrayIndex++;
                }
            }
        }

        public bool IsThereUnflippedCards()
        {
            bool isThereUnflippedCards = false;

            foreach (Card card in m_CardsMatrix)
            {
                isThereUnflippedCards = card.IsFlipped == false;
                if (isThereUnflippedCards)
                {
                    break;
                }
            }

            return isThereUnflippedCards;
        }

        public Card GetCard(string i_Square)
        {
            Card card;

            extractRowAndColFromSquareString(i_Square, out int row, out int col);
            card = m_CardsMatrix[row-1, col-1];

            return card;
        }

        public bool IsValidSquare(string i_Square, out string o_ErrorMessage)
        {
            bool isValid, isOnBoard;
            o_ErrorMessage = String.Empty; //If there is no error, the Player not gonna use the error message so it can be empty

            isOnBoard = checkIfSquareOnBoard(i_Square, ref o_ErrorMessage);
            isValid = isOnBoard && checkIfUnflippedCard(i_Square, ref o_ErrorMessage);

            return isValid;
        }

        private bool checkIfSquareOnBoard(string i_Square, ref string io_ErrorMessage)
        {
            bool isValidSquare = false, isValidRow, isValidCol;

            extractRowAndColFromSquareString(i_Square, out int row, out int col);
            isValidRow = row >= 1 && row <= m_Height;
            isValidCol = col >=1 && col <= m_Width;
            if (!isValidRow)
            {
                io_ErrorMessage = "Wrong row number. Row must be between 1 and " + m_Height;

            }
            else if (!isValidCol)
            {
                char endColChar = (char)('A' + m_Width - 1);
                io_ErrorMessage = "Wrong column number. Column must be between A and " + endColChar;
            }
            else
            {
                isValidSquare = true;
            }

            //isValidSquare = isValidRow && isValidCol;
            return isValidSquare;
        }

        private bool checkIfUnflippedCard(string i_Square, ref string io_ErrorMessage)
        {
            Card card = GetCard(i_Square);
            bool isUnflippedCard = !card.IsFlipped;

            if(!isUnflippedCard)
            {
                io_ErrorMessage = "The card has already been discovered, choose another one.";
            }

            return isUnflippedCard;
        }

        private void extractRowAndColFromSquareString(string i_Square, out int o_Row, out int o_Col)
        {
            char colChar = i_Square[0];
            char rowChar = i_Square[1];
            o_Col = (colChar - 'A') + 1;
            o_Row = rowChar - '0';
        }


    }
}

//public void PrintMatrix(Card[,] i_CardsMatrix)
//{
//    int rows = i_CardsMatrix.GetLength(0);
//    int cols = i_CardsMatrix.GetLength(1);

//    for (int i = 0; i < rows; i++)
//    {
//        for (int j = 0; j < cols; j++)
//        {
//            Console.Write(i_CardsMatrix[i, j].Content + " ");
//        }
//        Console.WriteLine();
//    }
//}

//private void checkMatrixCellsAmountEven()
//{
//    int rows = CardsMatrix.GetLength(0);
//    int cols = CardsMatrix.GetLength(1);
//    int totalCells = rows * cols;

//    if (totalCells % 2 != 0)
//    {
//        throw new Exception("Matrix must have an even number of cells.");
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class GameBoard
    {
        private Card[,] m_CardsMatrix;
        private int m_MatrixWidth;
        private int m_MatrixHeight; //not readonly, it can change if choose to play again.
        private int m_NumberOfUnflippedPairs;

        private const int k_MinRowsColsSize = 4;
        private const int k_MaxRowsColsSize = 6;

        public bool TryInitialGameBoard(int i_Rows, int i_Cols, out string o_ErrorMesage)
        {
            bool isValid = IsBoardSizeValid(i_Rows, i_Cols, out o_ErrorMesage);
            
            if (isValid)
            {
                m_MatrixWidth = i_Cols;
                m_MatrixHeight = i_Rows;
                m_CardsMatrix = new Card[i_Rows, i_Cols];
                fillCardsMatrix();
            }

            return isValid;
        }

        private bool IsBoardSizeValid(int i_Rows, int i_Cols, out string o_ErrorMesage)
        {
            bool isValid = true;

            if (i_Rows < k_MinRowsColsSize || i_Rows > k_MaxRowsColsSize)
            {
                isValid = false;
                o_ErrorMesage = "Rows not at range 4-6 (include).";
            }
            else if (i_Cols < k_MinRowsColsSize || i_Cols > k_MaxRowsColsSize)
            {
                isValid = false;
                o_ErrorMesage = "Cols not at range 4-6 (include).");
            }
            else if (i_Rows * i_Cols % 2 != 0)
            {
                isValid = false;
                o_ErrorMesage = "Board must have an even number of cells.";
            }
            else
            {
                o_ErrorMesage = "All valid.";
            }

            return isValid;
        }

        private void fillCardsMatrix()
        {
            int rows = m_MatrixWidth;
            int cols = m_MatrixHeight;
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
            colChar = i_Square[0];
            rowChar = i_Square[1];
            col = colChar - 'A';
            row = rowChar - '1';


        }

        public bool IsValidSquare(string i_Square, out string o_Message)
        {
            bool isValid, isOnBoard, isUnflippedCard;

            checkIfSquareOnBoard(i_Square);

            //checkIfUnflippedCard


            if (isValid)
                o_Message = String.Empty; //user not gonna use the message

            return isValid;
        }

        private bool checkIfSquareOnBoard(string i_Square, out string o_ErrorMessage)
        {
            char rowChar, colChar;
            int row, col, numberOfRows, numberOfCols;
            bool isValidSquare, isValidRow, isValidCol;
            
            colChar = i_Square[0];
            rowChar = i_Square[1];
            col = colChar - 'A';
            row = rowChar - '1';
            isValidRow = row >= 1 && row <= m_MatrixHeight;

            isValidCol = col >=1 && col <= m_MatrixWidth;


            //isValidRow = row < numberOfRows;
            o_ErrorMessage = " ";
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

    }
}

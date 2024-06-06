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
        private int m_Width;  //Not readonly, it can change if choose to play again.
        private int m_Height; //Not readonly, it can change if choose to play again.
        private int m_NumberOfUnflippedPairs;

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
            bool isValid = isEvenSquaresAmount(i_Rows, i_Cols, out o_ErrorMesage);
            if (isValid)
            {
                m_Width = i_Cols;
                m_Height = i_Rows;
                m_CardsMatrix = new Card[i_Rows, i_Cols];
                fillCardsMatrix();
            }

            return isValid;
        }

        private bool isEvenSquaresAmount(int i_Rows, int i_Cols, out string o_ErrorMesage)
        {
            bool countOfSquaresIsEven = i_Rows * i_Cols % 2 == 0;

            if (!countOfSquaresIsEven)
            {
                o_ErrorMesage = "Board must have an even number of cells.";
            }
            else
            {
                o_ErrorMesage = null;
            }

            return countOfSquaresIsEven;
        }

        private void fillCardsMatrix()
        {
            int rows = m_Height;
            int cols = m_Width;
            int totalCells = rows * cols;
            uint currentValue = 0;
            uint[] numbersToShuffle = new uint[totalCells];

            for (int i = 0; i < totalCells; i += 2)
            {
                numbersToShuffle[i] = currentValue;
                numbersToShuffle[i + 1] = currentValue;
                currentValue++;
            }

            Random randomNumber = new Random();
            for (int i = 0; i < numbersToShuffle.Length - 1; i++)
            {
                int j = randomNumber.Next(i, numbersToShuffle.Length);
                uint temp = numbersToShuffle[i];
                numbersToShuffle[i] = numbersToShuffle[j];
                numbersToShuffle[j] = temp;
            }

            int arrayIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    m_CardsMatrix[i, j] = new Card(numbersToShuffle[arrayIndex]);
                    arrayIndex++;
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
            o_ErrorMessage = null;

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

            if (!isUnflippedCard)
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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class GameData
    {
        private User m_Player1;
        private User m_Player2;
        private eCurrentPlayer m_CurrentPlayer;
        private readonly bool m_AgainstComputer;
        private Card[,] m_CardsMatrix;

        private const int k_MinRowsColsSize = 4;
        private const int k_MaxRowsColsSize = 6;

        public Card[,] CardsMatrix
        {
            get 
            {
                return m_CardsMatrix;
            }
        } 

        public GameData(string i_NamePlayer1, string i_NamePlayer2, bool i_AgainstComputer)
        {
            m_Player1 = new User(i_NamePlayer1);
            m_Player2 = new User(i_NamePlayer2);
            m_CurrentPlayer = eCurrentPlayer.Player1;
            m_AgainstComputer = i_AgainstComputer;
        }

        //public GameData(string i_Name1, string i_Name2, int i_Rows, int i_Cols)
        //{
        //    m_Player1 = new User(i_Name1);
        //    m_Player2 = new User(i_Name2);
        //    m_CurrentPlayer = eCurrentPlayer.Player1;
        //    m_CardsMatrix = new Card[i_Rows, i_Cols];
        //    fillCardsMatrix(m_CardsMatrix);
        //}

        public void InitialCardsMatrix(int i_Rows, int i_Cols)
        {
            validateMatrixSize(i_Rows, i_Cols);
            m_CardsMatrix = new Card[i_Rows, i_Cols];
            fillCardsMatrix(m_CardsMatrix);
        }

        private void validateMatrixSize(int i_Rows, int i_Cols)
        {
            if (i_Rows < k_MinRowsColsSize || i_Rows > k_MaxRowsColsSize)
            {
                throw new Exception("Exception: Rows not at range 4-6 include.");
            }
            else if (i_Cols < k_MinRowsColsSize || i_Cols > k_MaxRowsColsSize)
            {
                throw new Exception("Exception: Cols not at range 4-6 include.");
            }
            else if (i_Rows * i_Cols % 2 != 0)
            {
                throw new Exception("Exception: Matrix must have an even numberof cells");
            }
        }

        private void fillCardsMatrix(Card[,] io_CardsMatrix)
        {
            int rows = io_CardsMatrix.GetLength(0);
            int cols = io_CardsMatrix.GetLength(1);
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
                    io_CardsMatrix[i, j] = new Card(characters[charactersArrayIndex]);
                    charactersArrayIndex++;
                }
            }
        }

        public bool IsThereUnflippedCards()
        {
            bool isThereUnflippedCards = false;

            foreach (Card card in CardsMatrix)
            {
                isThereUnflippedCards = card.IsFlipped == false;
                if (isThereUnflippedCards)
                {
                    break;
                }
            }

            return isThereUnflippedCards;
        }



        public void PrintMatrix(Card[,] i_CardsMatrix)
        {
            int rows = i_CardsMatrix.GetLength(0);
            int cols = i_CardsMatrix.GetLength(1);
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(i_CardsMatrix[i, j].Content + " ");
                }
                Console.WriteLine();
            }
        }

        private void checkMatrixCellsAmountEven()
        {
            int rows = CardsMatrix.GetLength(0);
            int cols = CardsMatrix.GetLength(1);
            int totalCells = rows * cols;

            if (totalCells % 2 != 0)
            {
                throw new Exception("Matrix must have an even number of cells.");
            }
        }
    }
}

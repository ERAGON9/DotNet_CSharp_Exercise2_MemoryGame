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
        private User m_player1;
        private User m_player2;
        int currentPlayer; // change to enum.
        Card[,] cardsMatrix;

        public GameData(string i_Name1, string i_Name2, int i_Rows, int i_Cols)
        {
            m_player1 = new User(i_Name1);
            m_player2 = new User(i_Name2);
            currentPlayer = 1;
            cardsMatrix = new Card[i_Rows, i_Cols];
            fillCardsMatrix(cardsMatrix);
        }

        private void fillCardsMatrix(Card[,] io_CardsMatrix)
        {
            int rows = io_CardsMatrix.GetLength(0);
            int cols = io_CardsMatrix.GetLength(1);
            int totalCells = rows * cols;
            char currentCharacter = 'A';
            char[] characters = new char[totalCells];

            // Ensure the matrix size is even
            if (totalCells % 2 != 0)
            {
                throw new InvalidOperationException("Matrix must have an even number " +
                    " of cells.");
            }

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
    }
}

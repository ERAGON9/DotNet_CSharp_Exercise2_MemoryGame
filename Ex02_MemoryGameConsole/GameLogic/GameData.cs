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
        private readonly bool m_AgainstComputer;
        private GameBoard m_Board;
        private Turn m_CurrentTurn;

        public GameData(string i_NamePlayer1, string i_NamePlayer2, bool i_AgainstComputer)
        {
            m_Player1 = new User(i_NamePlayer1);
            m_Player2 = new User(i_NamePlayer2);
            m_CurrentTurn.CurrentPlayer = eCurrentPlayer.Player1; // change in turn;
            m_AgainstComputer = i_AgainstComputer;
        }

        public GameBoard Board
        {
            get 
            {
                return m_Board;
            }
        } 
        public Turn CurrentTurn
        {
            get
            {
                return m_CurrentTurn;
            }
        }

        public void FlipCard1InCurrentTurn(string i_Square)
        {

            CurrentTurn.Card1 = Board.GetCard(i_Square);
            CurrentTurn.FlipCard1();
        }

        public void FlipCard2InCurrentTurn()
        {
            CurrentTurn.FlipCard2();
        }

        public void UnflippeCardsInCurrentTurn()
        {
            CurrentTurn.UnflippedCards();
        }

        public void InitialBoard(int i_Rows, int i_Cols)
        {
            Board.InitialCardsMatrix(i_Rows, i_Cols);
        }

        public bool IsValidSquareInput(string i_Square, out string o_Message)
        {
            return Board.IsValidSquare( i_Square, out o_Message);
        }

    }
}

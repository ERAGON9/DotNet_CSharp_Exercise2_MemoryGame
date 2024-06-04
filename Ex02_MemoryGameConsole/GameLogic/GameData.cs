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
        private Player m_Player1;
        private Player m_Player2;
        private readonly bool m_AgainstComputer;
        private GameBoard m_Board;
        private Turn m_CurrentTurn;

        public GameData(string i_NamePlayer1, string i_NamePlayer2, bool i_AgainstComputer)
        {
            m_Player1 = new Player(i_NamePlayer1);
            m_Player2 = new Player(i_NamePlayer2);
            m_AgainstComputer = i_AgainstComputer; //צריך?
            m_Board = new GameBoard();
            m_CurrentTurn = new Turn();
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

        public string GetCurrenPlayerType()
        {
            return CurrentTurn.CurrentPlayerType;
        }

        public void FlipCard1InCurrentTurn(string i_Square)
        {
            CurrentTurn.Card1 = Board.GetCard(i_Square);
            CurrentTurn.FlipCard1();
        }

        public void FlipCard2InCurrentTurn(string i_Square)
        {
            CurrentTurn.Card2 = Board.GetCard(i_Square);
            CurrentTurn.FlipCard2();
        }

        public void UnflippeCardsInCurrentTurn()
        {
            CurrentTurn.UnflippedCards();
        }

        public bool TryInitialBoard(int i_Rows, int i_Cols, out string o_ErrorMessage)
        {
            return Board.TryInitialGameBoard(i_Rows, i_Cols, out o_ErrorMessage);
        }

        public bool IsValidSquareInput(string i_Square, out string o_Message)
        {
            return Board.IsValidSquare( i_Square, out o_Message);
        }

        public string GetPlayerNameOfCurrentTurn()
        {
            string playerName = GetPlayerOfCurrentTurn().Name;

            return playerName;
        }

        public bool IsThereUnflippedCardsOnBoard()
        {
            return m_Board.IsThereUnflippedCards();
        }

        public bool IsCardsTheSame()
        {
            bool isAPair = m_CurrentTurn.Card1.Content == m_CurrentTurn.Card2.Content;
            
            return isAPair;
        }

        public void OperatesByChosenCards()
        {
            if (IsCardsTheSame())
            {
                Player currentPlayer = GetPlayerOfCurrentTurn();
                currentPlayer.AddPointToPlayer();
            }
            else
            {
                m_CurrentTurn.UnflippedCards();
                m_CurrentTurn.SwitchPlayerTurn();
            }

            m_CurrentTurn.ResetCard1();
            m_CurrentTurn.ResetCard2();
        }

        private Player GetPlayerOfCurrentTurn()
        {
            Player player;
            
            if (CurrentTurn.CurrentPlayer == eCurrentPlayer.Player1)
            {
                player = m_Player1;
            }
            else
            {
                player = m_Player2;
            }

            return player;
        }

        public void GetPlayersScore(out int o_ScorePlayer1, out int o_ScorePlayer2)
        {
            o_ScorePlayer1 = m_Player1.Points;
            o_ScorePlayer2 = m_Player2.Points;
        }
    }
}

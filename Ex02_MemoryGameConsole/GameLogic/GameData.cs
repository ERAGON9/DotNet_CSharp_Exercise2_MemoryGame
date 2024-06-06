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
        private List<Player> m_Players; //List because if in the future we want to change
                                        //the number of players during the game.
        private GameBoard m_Board;
        private Turn m_CurrentTurn;

        public GameData(int i_NumOfPlayers, string[] i_PlayersNames,
                        string[] i_PlayersTypes)
        {
            m_Players = new List<Player>(i_NumOfPlayers);
            for (int i = 0; i < i_NumOfPlayers; i++)
            {
                m_Players.Add(new Player(i_PlayersNames[i], i_PlayersTypes[i]));
            }

            m_Board = new GameBoard();
            m_CurrentTurn = new Turn(m_Players[0]);
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

        public string ComputerChoosingSquare() // Need to create this method!!!!
        {
            return null;
        }

        public string GetCurrenPlayerType()
        {
            return getPlayerTypeFromEnum(CurrentTurn.CurrentPlayer.Type);
        }

        private string getPlayerTypeFromEnum(ePlayerType i_PlayerTypeEnum)
        {
            string value;

            if (i_PlayerTypeEnum == ePlayerType.Player)
            {
                value = "Player";
            }
            else
            {
                value = "Computer";
            }

            return value;
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
            string playerName = getPlayerOfCurrentTurn().Name;

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

        public void AddPointToCurrentPlayer()
        {
            m_CurrentTurn.CurrentPlayer.AddPointToPlayer();
        }

        public void UnflippedCardsForCurrentTurn()
        {
            m_CurrentTurn.UnflippedCards();
        }

        public void SwitchToNextPlayer()
        {
            Player currentPlayer = m_CurrentTurn.CurrentPlayer;

            for (int i = 0; i < m_Players.Count; i++)
            {
                if (m_Players[i] == currentPlayer)
                {
                    int nextPlayerIndex = (i + 1) % m_Players.Count;
                    m_CurrentTurn.SwitchPlayerTurn(m_Players[nextPlayerIndex]);
                    break;
                }
            }
        }

        private Player getPlayerOfCurrentTurn()
        {
            return m_CurrentTurn.CurrentPlayer;
        }

        public void GetPlayersScore(out int[] o_PlayersScores)
        {
            o_PlayersScores = new int[m_Players.Count];

            for (int i = 0; i < m_Players.Count; i++)
            {
                o_PlayersScores[i] = m_Players[i].Points;
            }
        }
    }
}

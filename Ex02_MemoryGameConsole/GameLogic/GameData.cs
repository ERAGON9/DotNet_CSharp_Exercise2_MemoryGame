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

        public string ComputerChoosingSquare()
        {
            Random random = new Random();
            List<string> availableSquares = new List<string>();

            for (int i = 1; i <= m_Board.Height; i++)
            {
                for (int j = 1; j <= m_Board.Width; j++)
                {
                    char colChar = (char)('A' + j - 1);
                    string square = $"{colChar}{i}";

                    if (m_Board.IsValidSquare(i, j, out string errorMessage))
                    {
                        availableSquares.Add(square);
                    }
                }
            }

            int randomIndex = random.Next(availableSquares.Count);

            return availableSquares[randomIndex];
        }

        public string GetCurrenPlayerType()
        {
            return getPlayerTypeFromEnum(m_CurrentTurn.CurrentPlayer.Type);
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
            int row, col;

            extractRowAndColFromSquareString(i_Square, out row, out col);
            m_CurrentTurn.Card1 = m_Board.GetCard(row, col);
            m_CurrentTurn.FlipCard1();
        }

        public void FlipCard2InCurrentTurn(string i_Square)
        {
            int row, col;

            extractRowAndColFromSquareString(i_Square, out row, out col);
            m_CurrentTurn.Card2 = m_Board.GetCard(row, col);
            m_CurrentTurn.FlipCard2();
        }

        public bool TryInitialBoard(int i_Rows, int i_Cols, out string o_ErrorMessage)
        {
            bool isInitialized = m_Board.TryInitialGameBoard(i_Rows, i_Cols, out o_ErrorMessage);

            return isInitialized;
        }

        public bool IsValidSquareInput(string i_Square, out string o_Message)
        {
            int row, col;
            bool isValid;

            extractRowAndColFromSquareString(i_Square, out row, out col);
            isValid = m_Board.IsValidSquare(row, col, out o_Message);

            return isValid;
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

        public int[] GetPlayersScore()
        {
            int[] playersScores = new int[m_Players.Count];

            for (int i = 0; i < m_Players.Count; i++)
            {
                playersScores[i] = m_Players[i].Points;
            }

            return playersScores;
        }
        
        public string[] GetPlayersNames()
        {
            string[] playersNames = new string[m_Players.Count];

            for (int i = 0; i < m_Players.Count; i++)
            {
                playersNames[i] = m_Players[i].Name;
            }

            return playersNames;
        }

        private void extractRowAndColFromSquareString(string i_Square, out int o_Row,
                                                      out int o_Col)
        {
            char colChar = i_Square[0];
            char rowChar = i_Square[1];

            o_Col = (colChar - 'A') + 1;
            o_Row = rowChar - '0';
        }
    }
}

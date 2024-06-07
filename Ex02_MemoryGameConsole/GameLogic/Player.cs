using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class Player
    {
        private readonly string m_Name;
        private int m_Points;
        private readonly ePlayerType m_type;

        public Player(string i_PlayerName, string i_PlayerType)
        {
            m_Name = i_PlayerName;
            m_Points = 0;
            m_type = extractPlayerTypeFromString(i_PlayerType);
        }

        public string Name 
        {
            get
            {
                return m_Name;
            } 
        }

        public int Points
        {
            get
            {
                return m_Points;
            }
        }

        public ePlayerType Type
        {
            get
            {
                return m_type;
            }
        }

        public void AddPointToPlayer()
        {
            m_Points++;
        }

        private ePlayerType extractPlayerTypeFromString(string i_PlayerTypeString)
        {
            ePlayerType value;

            if (i_PlayerTypeString == "Player")
            {
                value = ePlayerType.Player;
            }
            else
            {
                value = ePlayerType.Computer;
            }

            return value;
        }
    }
}

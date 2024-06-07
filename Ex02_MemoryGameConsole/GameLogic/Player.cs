using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class Player
    {
        private readonly string r_Name;
        private int m_Points;
        private readonly ePlayerType r_type;

        public Player(string i_PlayerName, string i_PlayerType)
        {
            r_Name = i_PlayerName;
            m_Points = 0;
            r_type = extractPlayerTypeFromString(i_PlayerType);
        }

        public string Name 
        {
            get
            {
                return r_Name;
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
                return r_type;
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

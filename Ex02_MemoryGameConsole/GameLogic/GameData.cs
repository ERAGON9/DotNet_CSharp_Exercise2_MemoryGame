using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class GameData
    {
        private User m_player1;
        private User m_player2;

        public GameData(string name1, string name2)
        {
            m_player1 = new User(name1);
            m_player2 = new User(name2);
        }


    }
}

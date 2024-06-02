using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class Turn
    {
        private Card m_Card1;
        private Card m_Card2;
        private eCurrentCard m_CurrentCard;
        private eCurrentPlayer m_CurrentPlayer;

        public void FlipCard1()
        {
            m_Card1.FlipCard();
        }

        public void flipCard2()
        {
            m_Card2.FlipCard();
        }

    }
}

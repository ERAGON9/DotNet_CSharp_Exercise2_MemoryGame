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

        public enum eCurrentCard
        {
            Card1,
            Card2
        }

        public eCurrentPlayer CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
            //set
            //{
            //    m_CurrentPlayer = value;
            //}
        }


        public void FlipCard1()
        {
            m_Card1.FlipCard();
            m_CurrentCard = eCurrentCard.Card2; //maybe add on Ctor for update card1 first, then no need to do it in FlipCard2
        }

        public void FlipCard2()
        {
            m_Card2.FlipCard();
        }


        public void UnflippedCards()
        {
            m_Card1.UnFlipCard();
            m_Card2.UnFlipCard();
        }
    }
}
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
        //private eCurrentCard m_CurrentCard = eCurrentCard.Card1;
        private eCurrentPlayer m_CurrentPlayer;

        public Turn()
        {
            m_CurrentPlayer = eCurrentPlayer.Player1;
        }

        public eCurrentPlayer CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
        }

        public void SwitchPlayerTurn()
        {
            if (m_CurrentPlayer == eCurrentPlayer.Player1)
            {
                m_CurrentPlayer = eCurrentPlayer.Player2;
            }
            else
            {
                m_CurrentPlayer = eCurrentPlayer.Player1;
            }
        }

        public Card Card1
        {
            get
            {
                return m_Card1;
            }
            set 
            {
                m_Card1 = value;
            }
        }
        public void ResetCard1()
        {
            m_Card1 = null;
        }
        public Card Card2
        {
            get
            {
                return m_Card2;
            }
            set
            {
                m_Card2 = value;
            }
        }
        public void ResetCard2()
        {
            m_Card2 = null;
        }

        public void FlipCard1()
        {
            m_Card1.FlipCard();
            //m_CurrentCard = eCurrentCard.Card2; //added Ctor for update card1 first, then no need to do it in FlipCard2
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
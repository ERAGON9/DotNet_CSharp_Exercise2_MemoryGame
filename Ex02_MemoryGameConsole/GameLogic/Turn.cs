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
        private Player m_CurrentPlayer; //אולי שווה להחליף פשוט במערך של שחקנים ובטיפוס השחקן

        //אם מוסיפים את השחקן ממש כאן, אז צריך להוריד את הבנאי פה 
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

        public void SwitchPlayerTurn() //צריך לשנות לדעתי ופשוט שהשינוי יהיה באינדקס של המערך
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

        public string CurrentPlayerType
        {
            get
            {
                return m_CurrentPlayerType;
            }
        }

        public void FlipCard1()
        {
            m_Card1.FlipCard();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{

    internal class Turn
    {
        private Card m_Card1;
        private Card m_Card2;
        private Player m_CurrentPlayer;
        
        public Turn(Player i_FirstPlayer)
        {
            m_CurrentPlayer = i_FirstPlayer;
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

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
        }

        public void SwitchPlayerTurn(Player i_NextPlayer)
        {
            m_CurrentPlayer = i_NextPlayer;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class Card
    {
        private bool m_IsFlipped;

        private uint m_Content;

        public bool IsFlipped
        {
            get 
            {
                return m_IsFlipped;
            }
            set 
            {
                m_IsFlipped = value;
            }
        }

        public uint Content
        {
            get 
            {
                return m_Content;
            }
            set 
            {
                m_Content = value;
            }
        }

        public Card(uint i_Data) 
        {
            m_IsFlipped = false;
            m_Content = i_Data;
        }

        public void FlipCard()
        {
            m_IsFlipped = true;
        }

        public void UnFlipCard()
        {
            m_IsFlipped = false;
        }
    }
}

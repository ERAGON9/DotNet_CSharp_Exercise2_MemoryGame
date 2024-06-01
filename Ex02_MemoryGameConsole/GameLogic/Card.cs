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

        private char? m_Content; //think later about the char or type thing.

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

        public char? Content
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

        public Card(char i_Data) 
        {
            m_IsFlipped = false;
            m_Content = i_Data;
        }
    }
}

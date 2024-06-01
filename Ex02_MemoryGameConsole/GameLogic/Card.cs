using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class Card
    {
        private bool isFlipped;
        public bool IsFlipped
        {
            get 
            {
                return isFlipped;
            }
            set 
            {
                isFlipped = value;
            }
        }

        private char? content; //think later about the char or type thing.
        public char? Content
        {
            get 
            {
                return content;
            }
            set 
            {
                content = value;
            }
        }

        public Card(char i_Data) 
        {
            isFlipped = false;
            content = i_Data;
        }
    }
}

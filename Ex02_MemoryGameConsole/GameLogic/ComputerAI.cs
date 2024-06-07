using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class ComputerAI
    {
        private uint?[,] m_AIMatrix;

        public ComputerAI(int i_Rows, int i_Cols)
        {
            m_AIMatrix = new uint?[i_Rows, i_Cols];
        }

        public void RememberCard(uint i_CardContent, int i_Row, int i_Col)
        {
            m_AIMatrix[i_Row, i_Col] = i_CardContent;
        }

    }
}

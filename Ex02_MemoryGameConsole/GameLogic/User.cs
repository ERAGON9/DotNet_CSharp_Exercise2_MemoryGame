using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class User
    {
        private readonly string m_Name;
        private int m_Points;

        public User(string i_UserName)
        {
            m_Name = i_UserName;
            m_Points = 0;
        }

        public string Name 
        {
            get
            {
                return m_Name;
            } 
        }

        public int Points
        {
            get
            {
                return m_Points;
            }
        }

        public void AddPointToPlayer()
        {
            m_Points++;
        }
    }
}

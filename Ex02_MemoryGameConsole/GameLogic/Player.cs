﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_MemoryGameConsole.GameLogic
{
    internal class Player
    {
        private readonly string m_Name;
        private int m_Points;
        private string m_type; //maybe enum?

        public Player(string i_PlayerName)
        {
            m_Name = i_PlayerName;
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

        public string Type
        {
            get
            {
                return m_type;
            }

            set
            {
                m_type = value;
            }
        }

        public void AddPointToPlayer()
        {
            m_Points++;
        }
    }
}

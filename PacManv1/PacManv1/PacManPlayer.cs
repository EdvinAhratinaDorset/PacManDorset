using System;
using System.Collections.Generic;
using System.Text;

namespace PacManv1
{
    class PacManPlayer
    {
        int posX; //row
        int posY; //Column
        int score;
        bool mode;
        bool alive;
        bool hasWon;
        public PacManPlayer(int _posX,int _posY, int _score, bool _mode, bool alive_)
        {
            posX = _posX;
            posY = _posY;
            score = _score;
            mode = _mode;
            alive = alive_;
            hasWon = false;
        }
        public int GetPosX
        {
            get { return posX; }
            set { posX = value; }
        }
        public int GetPosY
        {
            get { return posY; }
            set { posY = value; }
        }
        public int GetScore
        {
            get { return score; }
            set { score = value; }
        }
        public bool GetMode
        {
            get { return mode; }
            set { mode = value; }
        }
        public bool GetAlive
        {
            get { return alive; }
            set { alive = value; }
        }
        public bool GetHasWon
        {
            get { return hasWon; }
            set { hasWon = value; }
        }
    }
}

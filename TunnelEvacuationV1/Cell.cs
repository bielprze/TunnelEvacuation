﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunnelEvacuationV1
{
    class Cell
    {
        public int panic; //0-100
        public double speed; //1-1.5
        public int state; // 0 - pusta, 1 - pieszy, 2 - przeszkoda 3 - wyjście
        public int reaction;

        public double nearest_exit;
        public double attractiveness;





        public Cell(int p, double sp, int st)
        {
            panic = p;
            speed = sp;
            state = st;
        }

        public Cell(int st)
        {
            state = st;
        }

        public int getState()
        {
            return this.state;
        }
        public void setState(int st)
        {
            this.state = st;
        }
    }
}

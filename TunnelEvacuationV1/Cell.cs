using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunnelEvacuationV1
{
    class Cell
    {
        int panic;
        double speed;
        int state; // 0 - pusta, 1 - pieszy, 2 - przeszkoda
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

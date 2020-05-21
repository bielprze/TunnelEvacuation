using System;
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

        public bool moved;

        public Cell(int p, double sp, int st)
        {
            panic = p;
            speed = sp;
            state = st;
            moved = false;
            reaction = 0;
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

        public void copy_cell(Cell new_one)
        {
            new_one.panic = this.panic;
            new_one.speed = this.speed;
            new_one.state = this.state;
            new_one.reaction = this.reaction;
            new_one.moved = true;
            this.panic = 0;
            this.speed = 0;
            this.state = 0;
            this.reaction = 0;
        }
    }
}

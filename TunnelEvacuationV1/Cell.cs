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
        public int speed; // 2 - 4; 0.8 - 1.6 m/s
        public int state; // 0 - pusta, 1 - pieszy, 2 - przeszkoda 3 - wyjście
        public int reaction; //czas reakcji, chwilowo w turach automatu

        public double nearest_exit; //najbliższe wyjście od danej komórki
        public double attractiveness; //atrakcyjnośc danej komórki. Jeśli jest odpowiednio duża to może zostać wybrana zamiast komórki o niższej odległości od wyjścia

        public bool moved; //czy komórka poruszyła się w danej turze

        public double smoke_level; //0 lub 1

        public Cell(int p, int sp, int st)
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

        public void copy_cell(Cell new_one) // przesunięcie pieszego (i wszystkich jego statystyk) na nowe miejsce
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

        public void zero_cell() // zerowanie komórki gdy pieszy ucieknie z tunelu
        {
            state = 0;
            this.panic = 0;
            this.speed = 0;
            this.state = 0;
            this.reaction = 0;
        }
    }
}

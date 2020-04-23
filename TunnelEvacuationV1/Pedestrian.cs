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
        int state; 
        public Cell(int p, double sp, int st)
        {
            panic = p;
            speed = sp;
            state = st;
        }

    }
}

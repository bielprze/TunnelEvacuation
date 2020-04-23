using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunnelEvacuationV1
{
    public enum vehicle_types
    {
        Truck = 0,
        Car = 1,
        Bike = 2
    }
    class Vehicle
    {
        vehicle_types vehicle_type;
        public int x;
        public int y;
        int passenger;
        int passengers_reaction_time;

        public Vehicle(int en, int a, int b)
        {
            vehicle_type = (vehicle_types)en;
            fill_passangers();
            reaction_time();
            location(a, b);
        }
        void fill_passangers()
        {
            var rand = new Random();
            int i = (int)vehicle_type;

            switch (i)
            {
                case 0:
                    if (rand.NextDouble() < 0.7)
                        passenger = 1;
                    else
                        passenger = 2;
                    break;
                case 1:
                    if (rand.NextDouble() < 0.26)
                        passenger = 1;
                    else if(rand.NextDouble() < 0.51)
                        passenger = 2;
                    else if (rand.NextDouble() < 0.76)
                        passenger = 3;
                    else if (rand.NextDouble() < 0.91)
                        passenger = 4;
                    else 
                        passenger = 5;
                    break;
                case 2:
                    if (rand.NextDouble() < 0.9)
                        passenger = 1;
                    else
                        passenger = 2;
                    break;
            }
        }

        void reaction_time()
        {
            var rand = new Random();
            passengers_reaction_time = rand.Next(30, 120);
        }

        void location(int a, int b)
        {
            this.x = a;
            this.y = b;
        }
    }
}

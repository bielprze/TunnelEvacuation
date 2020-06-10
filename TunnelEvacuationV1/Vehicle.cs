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
        Bike = 2,
        Bus = 3
    }
    class Vehicle
    {
        vehicle_types vehicle_type;
        public int x;
        public int y;
        public int passenger;
        public int passengers_reaction_time;
        public int ID;

        public Vehicle(int en, int a, int b, Random rand)
        {
            vehicle_type = (vehicle_types)en;
            ID = DataBase.id_list + 1;
            fill_passangers(rand);
            reaction_time();
            location(a, b);
        }
        void fill_passangers(Random rand)
        {
            int i = (int)vehicle_type;
            int tmp = rand.Next(0, 101);
            Console.WriteLine("vehilce type: " + i + " tmp: " + tmp);

            switch (i)
            {
                case 0:
                    if (tmp < 70)
                        passenger = 1;  
                    else
                        passenger = 2;
                    break;
                case 1:
                    if (tmp < 26)
                        passenger = 1;
                    else if(tmp < 51)
                        passenger = 2;
                    else if (tmp < 76)
                        passenger = 3;
                    else if (tmp < 91)
                        passenger = 4;
                    else 
                        passenger = 5;
                    break;
                case 2:
                    if (tmp < 80)
                        passenger = 1;
                    else
                        passenger = 2;
                    break;
                case 3:
                    passenger = 29;
                    break;
            }
        }

        void reaction_time()
        {
            switch ((int)vehicle_type)
            {
                case 3:
                    passengers_reaction_time = 110;
                    break;
                default:
                var rand = new Random();
                passengers_reaction_time = rand.Next(75, 120);
                    break;
            }
        }

        void location(int a, int b)
        {
            this.x = a;
            this.y = b;
        }
    }
}

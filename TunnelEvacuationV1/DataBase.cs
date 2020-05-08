using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunnelEvacuationV1
{
    public static class DataBase
    {
        public static int chosen_mode; //0 - własny, 1 - scenariusz 1

        public static int evac_time = 420;
        public static int vehicle_num = 50;
        public static int interval = 300;

        public static int tir;
        public static int car;
        public static int bike;

        public static double tir_percent = 0.5;
        public static double car_percent = 0.4;
        public static double bike_percent = 0.1;

        public static int id_list = 0;

        public static void evaluate_vehicles()
        {

            Console.WriteLine("Inside Database");
            Console.WriteLine(vehicle_num.ToString());

            tir = (int)(tir_percent * vehicle_num);
            car = (int)(car_percent * vehicle_num);
            bike = (int)(bike_percent * vehicle_num);
            Console.WriteLine(tir.ToString());
            Console.WriteLine(car.ToString());
            Console.WriteLine(bike.ToString());
        }
    }
}

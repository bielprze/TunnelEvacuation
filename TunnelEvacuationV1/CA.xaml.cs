using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TunnelEvacuationV1
{
    /// <summary>
    /// Interaction logic for CA.xaml
    /// </summary>
    public partial class CA : Window
    {

        Vehicle[] tirs = new Vehicle[DataBase.tir];
        Vehicle[] cars = new Vehicle[DataBase.car];
        Vehicle[] bikes = new Vehicle[DataBase.bike];
        public CA()
        {
            InitializeComponent();

            Console.WriteLine("Start-----------------------------------------------");

            Console.WriteLine("Tirt:-----------------------------------------------");
            Console.WriteLine(DataBase.tir.ToString());

            Console.WriteLine("Auta:-----------------------------------------------");
            Console.WriteLine(DataBase.car.ToString());


            Console.WriteLine("Motory:-----------------------------------------------");
            Console.WriteLine(DataBase.bike.ToString());


            int[] line1 = new int[625];
            int[] line2 = new int[625];

            Random random = new Random();
            int temp;
            int line_no;
            bool ready = false;
            bool flag = true;

            Console.WriteLine("Tiry -----------------------------------------------");
            for (int i = 0; i < DataBase.tir; i++)
            {
                line_no = random.Next(0, 2);
                while (true)
                {
                    temp = random.Next(0, 625);

                    for (int j = 0; j > 6; j++)
                    {
                        switch(line_no)
                        {
                            case 0:
                                if(line1[temp+j] == 1)
                                {
                                    flag = false;
                                }
                                break;
                            case 1:
                                if (line2[temp + j] == 1)
                                {
                                    flag = false;
                                }
                                break;
                        }
                    }

                    if(flag)
                    {
                        switch (line_no)
                        {
                            case 0:
                                for (int j = 0; j > 6; j++)
                                {
                                    line1[temp + j] = 1;
                                }
                                break;
                            case 1:
                                for (int j = 0; j > 6; j++)
                                {
                                    line2[temp + j] = 1;
                                }
                                break;
                        }
                        break;
                    }

                }

                tirs[i] = new Vehicle(0, temp*8, 5+(line_no*10)+ random.Next(1, 4) ); // odległość (w komórkach) od ściany + przesunięcie o pas + odległość od krawędzi pasa


            }

            Console.WriteLine("Tiry Out-----------------------------------------------");
            Console.WriteLine(tirs.Length.ToString());
            for (int k = 0; k < tirs.Length; k++)
            {
                //Console.WriteLine("wsp: "+ tirs[k].x.ToString() +", "+ tirs[k].y.ToString());
            }

            for (int i = 0; i < DataBase.car; i++)
            {
                line_no = random.Next(0, 2);
                while (true)
                {
                    temp = random.Next(0, 625);

                    for (int j = 0; j > 2; j++)
                    {
                        switch (line_no)
                        {
                            case 0:
                                if (line1[temp + j] == 1)
                                {
                                    flag = false;
                                }
                                break;
                            case 1:
                                if (line2[temp + j] == 1)
                                {
                                    flag = false;
                                }
                                break;
                        }
                    }

                    if (flag)
                    {
                        switch (line_no)
                        {
                            case 0:
                                for (int j = 0; j > 2; j++)
                                {
                                    line1[temp + j] = 1;
                                }
                                break;
                            case 1:
                                for (int j = 0; j > 2; j++)
                                {
                                    line2[temp + j] = 1;
                                }
                                break;
                        }
                        break;
                    }

                }

                cars[i] = new Vehicle(1, temp * 8, 5 + (line_no * 10) + random.Next(1, 4)); // odległość (w komórkach) od ściany + przesunięcie o pas + odległość od krawędzi pasa
            }

            for (int i = 0; i < DataBase.bike; i++)
            {
                line_no = random.Next(0, 2);
                while (true)
                {
                    temp = random.Next(0, 625);

                        switch (line_no)
                        {
                            case 0:
                                if (line1[temp] == 1)
                                {
                                    flag = false;
                                }
                                break;
                            case 1:
                                if (line2[temp] == 1)
                                {
                                    flag = false;
                                }
                                break;
                        }
                    

                    if (flag)
                    {
                        switch (line_no)
                        {
                            case 0:
                                    line1[temp] = 1;
                                    break;
                            case 1:
                                    line2[temp] = +1;
                                break;
                        }
                        break;
                    }

                }

                bikes[i] = new Vehicle(1, temp * 8, 5 + (line_no * 10) + random.Next(1, 4)); // odległość (w komórkach) od ściany + przesunięcie o pas + odległość od krawędzi pasa

            }

            Draw_Net();
            Start_sim();
        }

        public void Draw_Net()
        {
            Line line_top, line_bottom;

            line_top = new Line();
            line_top.Stroke = System.Windows.Media.Brushes.Black;
            line_top.X1 = 10;
            line_top.X2 = 5010;
            line_top.Y1 = 200;
            line_top.Y2 = 200;

            line_bottom = new Line();
            line_bottom.Stroke = System.Windows.Media.Brushes.Black;
            line_bottom.X1 = 10;
            line_bottom.X2 = 5010;
            line_bottom.Y1 = 225;
            line_bottom.Y2 = 225;

            line_top.StrokeThickness = 1;
            line_bottom.StrokeThickness = 1;
            stack.Children.Add(line_top);
            stack.Children.Add(line_bottom);

            Grid CAgrid = new Grid();

            ColumnDefinition[] cols = new ColumnDefinition[5000];
            RowDefinition[] rows = new RowDefinition[30];

            for(int i=0; i<5000; i++)
            {

            }

            for (int i = 0; i < tirs.Length; i++)
            {

                //System.Windows.Point Point1 = new System.Windows.Point(tirs[i].x, tirs[i].y);
                //System.Windows.Point Point2 = new System.Windows.Point(tirs[i].x + 40, tirs[i].y);
                //System.Windows.Point Point3 = new System.Windows.Point(tirs[i].x + 40, tirs[i].y+6);
                //System.Windows.Point Point4 = new System.Windows.Point(tirs[i].x, tirs[i].y + 6);

                //PointCollection myPointCollection = new PointCollection();

                //myPointCollection.Add(Point1);
                //myPointCollection.Add(Point2);
                //myPointCollection.Add(Point3);
                //myPointCollection.Add(Point4);

                //veh.Points = myPointCollection;
                //stack.Children.Add(veh);


                


                Console.WriteLine("wsp: " + tirs[i].x.ToString() + ", " + tirs[i].y.ToString());
            }


            for (int i = 0; i < cars.Length; i++)
            {

            }
            for (int i=0; i< bikes.Length; i++)
            {

            }

        }

        void Start_sim()
        {

        }

    }
}

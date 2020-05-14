using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        Cell[,] automat = new Cell[30, 5000];
        List<Pair> Exits = new List<Pair>();

        Bitmap B = new Bitmap(5096 * 2, 512);

        public CA()
        {
            InitializeComponent();

            Start.Click += Start_Click;

            for(int i=0; i<30; i++)
                for(int j=0; j<5000; j++)
                {
                    automat[i, j] = new Cell(0);
                }

            for (int j = 0; j < 5000; j++)
                automat[0, j].setState(2);

            for (int j = 0; j < 5000; j++)
                automat[29, j].setState(2);


            Random random = new Random();
            int temp;
            int line_no;
            bool ready = false;
            bool flag = true;

            int a, b;
            int while_counter = 0;

            for (int i = 0; i < DataBase.tir; i++)
            {
                flag = true;
                while_counter = 0;
                while (true)
                {

                    a = 4 + (random.Next(0, 2) * 10) + random.Next(0, 3);
                    b = random.Next(10, 4950);
                    for (int j = 0; j < 44; j++)
                        for (int k = 0; k < 6; k++)
                            if (automat[a + k, b + j].getState() != 0)
                            {
                                flag = false;
                            }
                    if(flag)
                    {
                        for (int j = 0; j < 42; j++)
                            for (int k = 0; k < 6; k++)
                                automat[a + k, b + j].setState(2);
                        tirs[i] = new Vehicle(0, a, b, random);

                        double speed;
                        int panic;
                        switch(tirs[i].passenger)
                        {
                            case 1:
                                automat[a - 1, b + 5].setState(1);
                                automat[a - 1, b + 5].panic = random.Next(0, 30);
                                automat[a - 1, b + 5].reaction = tirs[i].passengers_reaction_time;
                                automat[a - 1, b + 5].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);
                                break;
                            case 2:
                                automat[a - 1, b + 5].setState(1);
                                automat[a - 1, b + 5].panic = random.Next(0, 30);
                                automat[a - 1, b + 5].reaction = tirs[i].passengers_reaction_time;
                                automat[a - 1, b + 5].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a + 6, b + 5].setState(1);
                                automat[a + 6, b + 5].panic = random.Next(0, 30);
                                automat[a + 6, b + 5].reaction = tirs[i].passengers_reaction_time;
                                automat[a + 6, b + 5].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);
                                break;
                        }

                        break;
                    }
                    while_counter+=1;
                    flag = true;
                    if (while_counter > 50)
                        break;

                }

            }
             
            for (int i = 0; i < DataBase.car; i++)
            {
                flag = true;
                while_counter = 0;
                while (true)
                {
                    a = 4 + (random.Next(0, 2) * 10) + random.Next(0, 3);
                    b = random.Next(10, 4950);
                    for (int j = 0; j < 13; j++)
                        for (int k = 0; k < 4; k++)
                            if (automat[a + k, b + j].getState() != 0)
                            {
                                flag = false;
                            }
                    if (flag)
                    {
                        for (int j = 0; j < 11; j++)
                            for (int k = 0; k < 4; k++)
                                automat[a + k, b + j].setState(2);
                        cars[i] = new Vehicle(0, a, b, random);

                        switch (cars[i].passenger)
                        {
                            case 1:
                                automat[a - 1, b + 3].setState(1);
                                automat[a - 1, b + 3].panic = random.Next(0, 30);
                                automat[a - 1, b + 3].reaction = cars[i].passengers_reaction_time;
                                automat[a - 1, b + 3].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);
                                break;

                            case 2:
                                automat[a - 1, b + 3].setState(1);
                                automat[a - 1, b + 3].panic = random.Next(0, 30);
                                automat[a - 1, b + 3].reaction = cars[i].passengers_reaction_time;
                                automat[a - 1, b + 3].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a + 4, b + 3].setState(1);
                                automat[a + 4, b + 3].panic = random.Next(0, 30);
                                automat[a + 4, b + 3].reaction = cars[i].passengers_reaction_time;
                                automat[a + 4, b + 3].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);
                                break;

                            case 3:
                                automat[a - 1, b + 3].setState(1);
                                automat[a - 1, b + 3].panic = random.Next(0, 30);
                                automat[a - 1, b + 3].reaction = cars[i].passengers_reaction_time;
                                automat[a - 1, b + 3].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a + 4, b + 3].setState(1);
                                automat[a + 4, b + 3].panic = random.Next(0, 30);
                                automat[a + 4, b + 3].reaction = cars[i].passengers_reaction_time;
                                automat[a + 4, b + 3].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a - 1, b + 7].setState(1);
                                automat[a - 1, b + 7].panic = random.Next(0, 30);
                                automat[a - 1, b + 7].reaction = cars[i].passengers_reaction_time;
                                automat[a - 1, b + 7].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);
                                break;

                            case 4:
                                automat[a - 1, b + 3].setState(1);
                                automat[a - 1, b + 3].panic = random.Next(0, 30);
                                automat[a - 1, b + 3].reaction = cars[i].passengers_reaction_time;
                                automat[a - 1, b + 3].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a + 4, b + 3].setState(1);
                                automat[a + 4, b + 3].panic = random.Next(0, 30);
                                automat[a + 4, b + 3].reaction = cars[i].passengers_reaction_time;
                                automat[a + 4, b + 3].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a - 1, b + 7].setState(1);
                                automat[a - 1, b + 7].panic = random.Next(0, 30);
                                automat[a - 1, b + 7].reaction = cars[i].passengers_reaction_time;
                                automat[a - 1, b + 7].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a + 4, b + 7].setState(1);
                                automat[a + 4, b + 7].panic = random.Next(0, 30);
                                automat[a + 4, b + 7].reaction = cars[i].passengers_reaction_time;
                                automat[a + 4, b + 7].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);
                                break;

                            case 5:
                                automat[a - 1, b + 3].setState(1);
                                automat[a - 1, b + 3].panic = random.Next(0, 30);
                                automat[a - 1, b + 3].reaction = cars[i].passengers_reaction_time;
                                automat[a - 1, b + 3].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a + 4, b + 3].setState(1);
                                automat[a + 4, b + 3].panic = random.Next(0, 30);
                                automat[a + 4, b + 3].reaction = cars[i].passengers_reaction_time;
                                automat[a + 4, b + 3].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a - 1, b + 7].setState(1);
                                automat[a - 1, b + 7].panic = random.Next(0, 30);
                                automat[a - 1, b + 7].reaction = cars[i].passengers_reaction_time;
                                automat[a - 1, b + 7].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a + 4, b + 7].setState(1);
                                automat[a + 4, b + 7].panic = random.Next(0, 30);
                                automat[a + 4, b + 7].reaction = cars[i].passengers_reaction_time;
                                automat[a + 4, b + 7].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a + 4, b + 9].setState(1);
                                automat[a + 4, b + 9].panic = random.Next(0, 30);
                                automat[a + 4, b + 9].reaction = cars[i].passengers_reaction_time;
                                automat[a + 4, b + 9].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);
                                break;


                        }


                        break;
                    }
                    while_counter += 1;
                    flag = true;
                    if (while_counter > 50)
                        break;
                }

            }


            for (int i = 0; i < DataBase.bike; i++)
            {
                flag = true;
                while_counter = 0;
                while (true)
                {
                    a = 4 + (random.Next(0, 2) * 10) + random.Next(0, 3);
                    b = random.Next(10, 4950);
                    for (int j = 0; j < 7; j++)
                        for (int k = 0; k < 2; k++)
                            if (automat[a + k, b + j].getState() != 0)
                            {
                                flag = false;
                            }
                    if (flag)
                    {
                        for (int j = 0; j < 5; j++)
                            for (int k = 0; k < 2; k++)
                                automat[a + k, b + j].setState(2);
                        bikes[i] = new Vehicle(0, a, b, random);

                        switch (bikes[i].passenger)
                        {
                            case 1:
                                automat[a - 1, b].setState(1);
                                automat[a - 1, b].panic = random.Next(0, 30);
                                automat[a - 1, b].reaction = bikes[i].passengers_reaction_time;
                                automat[a - 1, b].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);
                                break;
                            case 2:
                                automat[a - 1, b].setState(1);
                                automat[a - 1, b].panic = random.Next(0, 30);
                                automat[a - 1, b].reaction = bikes[i].passengers_reaction_time;
                                automat[a - 1, b].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);

                                automat[a + 2, b].setState(1);
                                automat[a + 2, b].panic = random.Next(0, 30);
                                automat[a + 2, b].reaction = bikes[i].passengers_reaction_time;
                                automat[a + 2, b].speed = (random.NextDouble() * (1.5 - 1.1) + 1.1);
                                break;
                        }
                        break;
                    }
                    while_counter += 1;
                    flag = true;
                    if (while_counter > 50)
                        break;
                }

            }

            int cnt = 4999 - (int)(DataBase.interval / 0.4);
            while(cnt>1)
            {
                automat[0, cnt].setState(3);
                automat[0, cnt-1].setState(3);
                automat[0, cnt-2].setState(3);
                Exits.Add(new Pair(cnt, 0));
                Exits.Add(new Pair(cnt-1, 0));
                Exits.Add(new Pair(cnt-2, 0));

                cnt = cnt - (int)(DataBase.interval / 0.4);
            }

            for (int i=0; i<30; i++)
            {
                automat[i, 4999].setState(3);
                Exits.Add(new Pair(4999, i));
            }

            switch(DataBase.chosen_mode)
            {
                case 0:
                    Draw_Net();
                    break;
                case 1:
                    Draw_Emilia();
                    break;
            }

            Evaluate_exit_distance();

            // Start_sim();
        }

        private void Evaluate_exit_distance()
        {
            for(int i=0; i<30; ++i)
                for(int j=0; j<5000; ++j)
                {
                    double min=10000;
                    double temp;
                    foreach (var exit in Exits)
                    {
                        temp = Math.Sqrt(Math.Pow(exit.x - j, 2.0) + Math.Pow(exit.y - i, 2.0));
                        if (temp < min)
                            min = temp;
                    }
                    automat[i, j].nearest_exit = min;
                }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start_sim();
        }

        public void Draw_Emilia()
        {

        }
        public void Draw_Net()
        {
            int column = 5096*2;
            int row = 512;
            for (int i = 0; i <= column-1; i++)
                for (int j = 0; j <= row-1; j++) 
                    B.SetPixel(i, j, System.Drawing.Color.White);


            int x = 1;
            int y = 1;
            for (int i = 1; i < 31; i++)
            {
                for (int j = 1; j < 5001; j++)
                {
                    if (automat[i - 1, j - 1].getState() == 2)
                    {
                        x = j * 2;
                        y = i * 2;

                        B.SetPixel(x + 10, y + 110, System.Drawing.Color.Black); //(x,y)
                        B.SetPixel(x + 11, y + 110, System.Drawing.Color.Black); //(x,y)
                        B.SetPixel(x + 10, y + 111, System.Drawing.Color.Black); //(x,y)
                        B.SetPixel(x + 11, y + 111, System.Drawing.Color.Black); //(x,y)
                    }
                    else if (automat[i - 1, j - 1].getState() == 1)
                    {
                        x = j * 2;
                        y = i * 2;
                        B.SetPixel(x + 10, y + 110, System.Drawing.Color.Red); //(x,y)
                        B.SetPixel(x + 11, y + 110, System.Drawing.Color.Red); //(x,y)
                        B.SetPixel(x + 10, y + 111, System.Drawing.Color.Red); //(x,y)
                        B.SetPixel(x + 11, y + 111, System.Drawing.Color.Red); //(x,y)
                    }
                    else if ((automat[i - 1, j - 1].getState() == 3))
                    {
                        x = j * 2;
                        y = i * 2;
                        B.SetPixel(x + 10, y + 110, System.Drawing.Color.GreenYellow); //(x,y)
                        B.SetPixel(x + 11, y + 110, System.Drawing.Color.GreenYellow); //(x,y)
                        B.SetPixel(x + 10, y + 111, System.Drawing.Color.GreenYellow); //(x,y)
                        B.SetPixel(x + 11, y + 111, System.Drawing.Color.GreenYellow); //(x,y)
                    }
                }
            }



            stack.Source = BitmapToImageSource(B);

        }

        void Start_sim()
        {
            var watch = new System.Diagnostics.Stopwatch();
            //DataBase.evac_time
            for (int i=0; i< DataBase.evac_time*2; i++)
            {
                watch.Start();
                //Automat Start





                //Automat Stop
                watch.Stop();
                Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

                if (watch.ElapsedMilliseconds<500)
                {
                    Thread.Sleep(500 - (int)watch.ElapsedMilliseconds);
                }


                stack.Source = BitmapToImageSource(B);
            }

        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

    }
}

/*
             Console.WriteLine("Tiry -----------------------------------------------");
            for (int i = 0; i < DataBase.tir; i++)
            {
                line_no = random.Next(0, 2);
                while (true)
                {
                    temp = random.Next(0, 625);

                    for (int j = 0; j < 6; j++)
                    {
                        switch(line_no)
                        {
                            case 0:
                                if(temp+j < 625 && line1[temp+j] == 1)
                                {
                                    flag = false;
                                }
                                break;
                            case 1:
                                if (temp + j < 625 && line2[temp + j] == 1)
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
                                for (int j = 0; j < 6; j++)
                                {
                                    line1[temp + j] = 1;
                                }
                                break;
                            case 1:
                                for (int j = 0; j < 6; j++)
                                {
                                    line2[temp + j] = 1;
                                }
                                break;
                        }
                        break;
                    }

                }

                tirs[i] = new Vehicle(0, temp*8, 5+(line_no*10)+ random.Next(1, 3) ); // odległość (w komórkach) od ściany + przesunięcie o pas + odległość od krawędzi pasa


            }

            flag = true;
            for (int i = 0; i < DataBase.car; i++)
            {
                line_no = random.Next(0, 2);
                while (true)
                {
                    temp = random.Next(0, 625);

                    for (int j = 0; j < 2; j++)
                    {
                        switch (line_no)
                        {
                            case 0:
                                if (temp + j < 625 && line1[temp + j] == 1)
                                {
                                    flag = false;
                                }
                                break;
                            case 1:
                                if (temp + j < 625 && line2[temp + j] == 1)
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
                                for (int j = 0; j < 2; j++)
                                {
                                    line1[temp + j] = 1;
                                }
                                break;
                            case 1:
                                for (int j = 0; j < 2; j++)
                                {
                                    line2[temp + j] = 1;
                                }
                                break;
                        }
                        break;
                    }

                }

                cars[i] = new Vehicle(1, temp * 8, 5 + (line_no * 10) + random.Next(1, 3)); // odległość (w komórkach) od ściany + przesunięcie o pas + odległość od krawędzi pasa
            }
            flag = true;
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
                                    line2[temp] = 1;
                                break;
                        }
                        break;
                    }

                }

                bikes[i] = new Vehicle(1, temp * 8, 5 + (line_no * 10) + random.Next(1, 4)); // odległość (w komórkach) od ściany + przesunięcie o pas + odległość od krawędzi pasa

            } 
  */

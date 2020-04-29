using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        Cell[,] automat = new Cell[30, 5000];

        
        public CA()
        {
            InitializeComponent();

            for(int i=0; i<30; i++)
                for(int j=0; j<5000; j++)
                {
                    automat[i, j] = new Cell(0);
                }


            Random random = new Random();
            int temp;
            int line_no;
            bool ready = false;
            bool flag = true;

            int a, b;

            for (int i = 0; i < DataBase.tir; i++)
            {
                flag = true;
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
                        tirs[i] = new Vehicle(0, a, b);
                        break;
                    }
                    flag = true;
                }

            }

            for (int i = 0; i < DataBase.car; i++)
            {
                flag = true;
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
                        cars[i] = new Vehicle(0, a, b);
                        break;
                    }
                    flag = true;
                }

            }


            for (int i = 0; i < DataBase.bike; i++)
            {
                flag = true;
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
                        bikes[i] = new Vehicle(0, a, b);
                        break;
                    }
                    flag = true;
                }

            }

            Draw_Net();
            Start_sim();
        }

        public void Draw_Net()
        {
            int column = 5096;
            int row = 128;
            Bitmap B = new Bitmap(5096, 128);
            for (int i = 0; i <= column-1; i++)
                for (int j = 0; j <= row-1; j++)
                    B.SetPixel(i, j, System.Drawing.Color.White);


            for (int i = 1; i <= column - 1; i++)
            {
                B.SetPixel(i, 10, System.Drawing.Color.Black);
                B.SetPixel(i, 41, System.Drawing.Color.Black);
            }

            for (int i = 1; i < 30; i++)
            {
                for (int j = 1; j < 5000; j++)
                {
                    if (automat[i-1, j-1].getState() == 2)
                        B.SetPixel(j+10,i+10, System.Drawing.Color.Black); //(x,y)
                }
            }

            stack.Source = BitmapToImageSource(B);

        }

        void Start_sim()
        {

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

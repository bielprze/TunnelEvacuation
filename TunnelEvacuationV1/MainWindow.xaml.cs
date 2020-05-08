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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TunnelEvacuationV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            evac_ok.Click += Evac_ok_Click;
            exit_ok.Click += Exit_ok_Click;
            veh_ok.Click += Veh_ok_Click;
            Next_stage.Click += Next_stage_Click;
            scenario_emilia.Click += Scenario_emilia_Click;

            vehicle_group_ok.Click += Vehicle_group_ok_Click;
        }


        private void Vehicle_group_ok_Click(object sender, RoutedEventArgs e)
        {
            double tir_local = tir_no.Value;
            double car_local = car_no.Value;
            double bike_local = bike_no.Value;
            double sum = tir_local + car_local + bike_local;

            tir_no.Value = (tir_local / sum) * 100;
            car_no.Value = (car_local / sum) * 100;
            bike_no.Value = (bike_local / sum) * 100;

            DataBase.tir_percent = tir_no.Value;
            DataBase.car_percent = car_no.Value;
            DataBase.bike_percent = bike_no.Value;
        }

        private void Evac_ok_Click(object sender, RoutedEventArgs e) //evac_time_text
        {
            if (evac_time_text.Text.Equals(""))
            {
                DataBase.evac_time = 420;
            }
            else
            {
                try
                {
                    DataBase.evac_time = Int32.Parse(evac_time_text.Text);
                }
                catch (FormatException ex1)
                {
                    DataBase.evac_time = 420;
                }
            }
        }
        private void Exit_ok_Click(object sender, RoutedEventArgs e)
        {
            if (exit_text.Text.Equals(""))
            {
                DataBase.interval = 300;
            }
            else
            {
                try
                {
                    DataBase.interval = Int32.Parse(exit_text.Text);
                }
                catch (FormatException ex1)
                {
                    DataBase.interval = 300;
                }
            }
        }
        private void Veh_ok_Click(object sender, RoutedEventArgs e)
        {
            if(vehicle_num_text.Text.Equals(""))
            {
                DataBase.vehicle_num = 50;
            }
            else
            {
                try
                {
                    DataBase.vehicle_num = Int32.Parse(vehicle_num_text.Text);
                    if (DataBase.vehicle_num > 200)
                        DataBase.vehicle_num = 200;
                }
                catch(FormatException ex1)
                {
                    DataBase.vehicle_num = 50;
                }
            }
        }
        private void Next_stage_Click(object sender, RoutedEventArgs e)
        {
            DataBase.chosen_mode = 0;
            Console.WriteLine(DataBase.vehicle_num.ToString());
            DataBase.evaluate_vehicles();
            var newForm = new CA(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }

        private void Scenario_emilia_Click(object sender, RoutedEventArgs e)
        {
            DataBase.chosen_mode = 0;
            Console.WriteLine(DataBase.vehicle_num.ToString());
            DataBase.evaluate_vehicles();
            var newForm = new CA(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }

    }
}

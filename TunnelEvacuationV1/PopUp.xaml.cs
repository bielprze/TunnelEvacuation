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
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : Window
    {
        public PopUp(int time, int left_pedestrians, int max_pedestrians, bool succes)
        {
            InitializeComponent();

            OK_button.Click += OK_button_Click;
            if(succes)
                SumUp.Text = "Evacuation time: " + time + ", " + left_pedestrians + " left of " + max_pedestrians + ". Evacutaion was succesfull";
            else
                SumUp.Text = "Evacuation time: " + time + ", " + left_pedestrians + " left of " + max_pedestrians+". Evacutaion was failed";

        }

        private void OK_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

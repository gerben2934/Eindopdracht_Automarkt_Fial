using SharedData;
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
using Clienta;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Client client;
        private List<Car> cars;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void GetCars()
        {
            Server.
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                Cars.Items.Add(cars.ElementAt(i));
            }
        }
    }
}

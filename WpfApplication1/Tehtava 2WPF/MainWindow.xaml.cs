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

namespace Tehtava_2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BLReadXML reader = new BLReadXML();
        bool ifEdit = true;
        public MainWindow()
        {
            InitializeComponent();
            if (!reader.ERROR)
            {
                dgCountries.ItemsSource = reader.countries.Countries;
                update();
            }
            else
            {
                btnAREA.IsEnabled = false;
                btnPOP.IsEnabled = false;
                txtNameSort.IsEnabled = false;
                MessageBox.Show("Please check if App.config contains the correct filename and location of your file and restart the application", "ERROR FILE NOT FOUND");
            }
        }

        private void txtNameSort_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ifEdit)
            {
                dgCountries.ItemsSource = null;
                dgCountries.ItemsSource = reader.getLikeName(txtNameSort.Text);
                update();
            }
        }

        private void btnPOP_Click(object sender, RoutedEventArgs e)
        {
            ifEdit = false;
            txtNameSort.Text = "";
            ifEdit = true;
            dgCountries.ItemsSource = null;
            dgCountries.ItemsSource = reader.getTop10POP();
            update();
        }

        private void btnAREA_Click(object sender, RoutedEventArgs e)
        {
            ifEdit = false;
            txtNameSort.Text = "";
            ifEdit = true;
            dgCountries.ItemsSource = null;
            dgCountries.ItemsSource = reader.getTop10AREA();
            update();
        }

        public void update()
        {
            long pop = 0;
            int number = 0;
            foreach ( Country c in dgCountries.Items)
            {
                number++;
                pop +=Int32.Parse( c.Population);
            }
            txtNumbOfC.Text =""+ number;
            txtTotalPop.Text =""+ pop;
        }
    }
}

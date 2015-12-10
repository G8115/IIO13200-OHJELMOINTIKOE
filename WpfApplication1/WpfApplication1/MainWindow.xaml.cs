using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtOutput.Text = "";
            Dictionary<char, int> characters = new Dictionary<char, int>();
            string temp = Regex.Replace(txtInput.Text, "[^0-9a-zA-Z]+", "");
            foreach (char c in temp)
            {
                if (!characters.ContainsKey(c))
                    characters.Add(c, 1);
                else
                    characters[c]++;
            }
            List<char> tempList = characters.Keys.ToList();
            tempList.Sort();
            txtOutput.Text += "Number of characters: "+txtInput.Text.Count()+"\n";
            txtOutput.Text += "Number of unique characters: " + tempList.Count() + "\n";
            foreach (char c in tempList)
            {
                txtOutput.Text += c+" "+characters[c]+"\n";
            }
        }
    }
}

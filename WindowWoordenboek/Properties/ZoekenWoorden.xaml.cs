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

namespace WindowWoordenboek.Properties
{
    /// <summary>
    /// Interaction logic for ZoekenWoorden.xaml
    /// </summary>
    public partial class ZoekenWoorden : Window
    {
        Random random = new Random();
        int woordNumr;
        public ZoekenWoorden()
        {
            InitializeComponent();
            
        }

        private void ZoekenButton_Click(object sender, RoutedEventArgs e)
        {
            woordNumr = random.Next(0, Wachtwoorden.Engels.Count);

            for (int i = 0; i < Wachtwoorden.Engels.Count; i++)
            {
                RamdomEngelsWoordTextBox.Text = Wachtwoorden.Engels[woordNumr];  
            }

        }

        private void cotroleButton_Click(object sender, RoutedEventArgs e)
        {
            string ingevoerdeNederlansTerm = NederlansWoordTexbox.Text;
            string correctNederlansWoord = Wachtwoorden.Nederlands[woordNumr];

            if (ingevoerdeNederlansTerm.Equals(correctNederlansWoord, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("U kent de vertaling correct!", "Correct", MessageBoxButton.OK, MessageBoxImage.Information);
                NederlansWoordTexbox.Clear();
                RamdomEngelsWoordTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Vertaling niet correct!", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

           

        }
    }
}

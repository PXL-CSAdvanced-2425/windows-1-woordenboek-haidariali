using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowWoordenboek.Properties;

namespace WindowWoordenboek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string bestandPad = "C:\\Hogeschoolpxl\\2024-2025\\semester_2\\c#-advanced\\oefeningen\\windows-1-woordenboek-haidariali\\WindowWoordenboek\\Properties\\ICTWoordenboek.txt";

        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void ToevogegenButton_Click(object sender, RoutedEventArgs e)
        {
            string NederlansWoord = NederlandsTermWoordTextBox.Text;
            string EngelsWoord = EngelsTermWoordTextBox.Text;
            Wachtwoorden.VoegNederaldsWoordToe(NederlansWoord);
            Wachtwoorden.VoegEngelsTermenToe(EngelsWoord);

            NederlandsTermWoordTextBox.Clear(); 
            EngelsTermWoordTextBox.Clear();

            WoordenTonen();


            
            using (StreamWriter writer = new StreamWriter(bestandPad, true))
            {
                writer.WriteLine($"{EngelsWoord} - {NederlansWoord}");
            }

        }

       public void WoordenTonen()
       {
            WoordenListBox.Items.Clear();
            for (int i = 0; i < Wachtwoorden.Engels.Count; i++)
            {
                WoordenListBox.Items.Add($"{Wachtwoorden.Engels[i]} - {Wachtwoorden.Nederlands[i]}");
            }
       }

        private void verwijderenButton_Click(object sender, RoutedEventArgs e)
        {
            /* if (WoordenListBox.SelectedItems != null)
             {
                 WoordenListBox.Items.Remove(WoordenListBox.SelectedItem);
             }
             else
             {
                 MessageBox.Show("er is geen woord geselecteerd om te verwijderen");
             }*/


            if (WoordenListBox.SelectedItem != null) // deze deel door AI gemaakt
            {
                // Verkrijg de geselecteerde term
                string geselecteerdWoord = WoordenListBox.SelectedItem.ToString();

                // Verwijder het woord uit de ListBox
                WoordenListBox.Items.Remove(WoordenListBox.SelectedItem);

                // Zoek de Engelse en Nederlandse termen die bij het geselecteerde item horen
                string[] termen = geselecteerdWoord.Split('-');
                string engelsWoord = termen[0].Trim();
                string nederlandsWoord = termen[1].Trim();

                // Verwijder het woord uit de List<> (Engels en Nederlands)
                Wachtwoorden.Engels.Remove(engelsWoord);
                Wachtwoorden.Nederlands.Remove(nederlandsWoord);

                // Werk het bestand bij door alle resterende woorden opnieuw te schrijven
                using (StreamWriter writer = new StreamWriter(bestandPad, false))
                {
                    for (int i = 0; i < Wachtwoorden.Engels.Count; i++)
                    {
                        writer.WriteLine($"{Wachtwoorden.Engels[i]} - {Wachtwoorden.Nederlands[i]}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Er is geen woord geselecteerd om te verwijderen.");
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ZoekenWoorden zoekenWindow = new ZoekenWoorden();
            zoekenWindow.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            info.Show();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // deze deel door AI geschreven  !!
            if (File.Exists(bestandPad))
            {
                var lijnen = File.ReadAllLines(bestandPad);
                foreach (var lijn in lijnen)
                {
                    // Voeg woorden toe aan de lijst uit het bestand
                    var termen = lijn.Split('-');
                    if (termen.Length == 2)
                    {
                        Wachtwoorden.Engels.Add(termen[0].Trim());
                        Wachtwoorden.Nederlands.Add(termen[1].Trim());
                    }
                }
            }

            WoordenTonen();

        }
    }
}

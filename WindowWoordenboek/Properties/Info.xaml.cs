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
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
            Tesktonen();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        public void Tesktonen()
        {
            tekstTonenTextBloxk.Text = $"Productname: CS_Oefening_05\r\nVersion: 1.0.0.0\r\n\r\nCopyright: Copyright Koen Bloemen 2024\r\nCompanyname: PXL Digital\r\nDescription: In de toepassing worden specifieke\r\nEngelstalige ICT termen - Nederlandstalige termen\r\ntoegevoegd en verwijderd.";
        }
    }
}

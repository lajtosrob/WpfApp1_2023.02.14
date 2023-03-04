using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1_2023._02._14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Diak> diakok = new ObservableCollection<Diak>();
        public MainWindow()
        {
            InitializeComponent();
            Diak geza, eva;
            geza = new Diak("Gipsz Jakab", true, 176);
            eva = new Diak("Nagy Éva", false);

            diakok.Add(geza);
            diakok.Add(eva);

            dgDiakok.ItemsSource = diakok;

        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            Diak ujDiak;
            bool neme;
            neme = rdoFerfi.IsChecked == true;
            ujDiak = new Diak(txtNev.Text, neme, int.Parse(txtMagassag.Text));
            diakok.Add(ujDiak);
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (dgDiakok.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs egyetlen diák sem kiválasztva!");
            }
            else
                diakok.RemoveAt(dgDiakok.SelectedIndex);
        }

        private void btnTeljesTorles_Click(object sender, RoutedEventArgs e)
        {
            diakok.Clear();
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {

            StreamWriter fajlIro = new StreamWriter("diak.csv");
            foreach (var aktDiak in diakok)
            {
                fajlIro.WriteLine($"{aktDiak.Neve};{(aktDiak.Neme == "Férfi" ? 1 : 0)};{aktDiak.Magassag}");
            }
            fajlIro.Close();

        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("diak.csv", encoding: Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] tagok = sr.ReadLine().Split(";");

                Diak ujDiak = new Diak(tagok[0], tagok[1] == "1" ? true : false, int.Parse(tagok[2]));
                diakok.Add(ujDiak);
            }
            sr.Close();

        }
    }
}

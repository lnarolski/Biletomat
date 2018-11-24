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
using definicje_zmiennych;

namespace Biletomat
{
    /// <summary>
    /// Interaction logic for PodsumowanieWindow.xaml
    /// </summary>
    public partial class PodsumowanieWindow : Window
    {
        public double zaplacona_kwota;
        public bool zaplacono;
        public bool platnosc_karta;

        public PodsumowanieWindow(double suma, rodzaj_biletu typ_biletow)
        {
            InitializeComponent();
            zaplacona_kwota = 0.0;
            Suma_text.Text = "Razem: " + suma.ToString("F2") + " zł";
        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pomocGlosowa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SymulatorButton_Click(object sender, RoutedEventArgs e)
        {
            SymulatoPlatnosciWindow okno = new SymulatoPlatnosciWindow();
            okno.zaplacona_kwota += value => zaplacona_kwota = value;
            okno.zaplacono += value => zaplacono = value;
            okno.zaplacono_karta += value => platnosc_karta = value;
            okno.Closed += new EventHandler(Zamkniecie_okna_platnosci);
            okno.ShowDialog();
        }

        private void Zamkniecie_okna_platnosci(object sender, EventArgs e)
        {
            Suma_text.Text = "gdhdghd";
        }
    }
}

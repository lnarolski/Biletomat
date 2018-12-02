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
    /// Interaction logic for WyborPrzewoznikaWindow.xaml
    /// </summary>
    public partial class WyborPrzewoznikaWindow : Window
    {
        public WyborPrzewoznikaWindow()
        {
            InitializeComponent();
        }

        private void PrzedluzButton_Click(object sender, RoutedEventArgs e)
        {
            PodsumowanieWindow okno = new PodsumowanieWindow(bilet_okresowy.cena_bilet(), rodzaj_biletu.BILET_OKRESOWY);
            okno.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
            okno.Show();
        }

        private void Zamkniecie_okna_podsumowania(object sender, EventArgs e)
        {
            if (status_biletomatu.status_zakupu == status.WYDRUKOWANO_BILETY)
                this.Close();
        }

        private void MZKGButton_Click(object sender, RoutedEventArgs e)
        {
            MZKGBiletOkresowyWindow okno = new MZKGBiletOkresowyWindow();
            okno.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
            okno.Show();
        }

        private void ZKMButton_Click(object sender, RoutedEventArgs e)
        {
            ZKMBiletOkresowyWindow okno = new ZKMBiletOkresowyWindow();
            okno.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
            okno.Show();
        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.czysc_bilet();
            this.Close();
        }
    }
}

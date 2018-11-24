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
    /// Interaction logic for BiletJednorazowyWindow.xaml
    /// </summary>
    public partial class BiletJednorazowyWindow : Window
    {
        private bilety_jednorazowe lista_biletow;

        public BiletJednorazowyWindow()
        {
            InitializeComponent();
            lista_biletow = new bilety_jednorazowe();
        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pomocGlosowa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bilet1_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (lista_biletow.bilet1_normalny < 1)
                return;
            --lista_biletow.bilet1_normalny;
            Bilet1_liczba.Text = lista_biletow.bilet1_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet1_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (lista_biletow.bilet1_normalny > 99)
                return;
            ++lista_biletow.bilet1_normalny;
            Bilet1_liczba.Text = lista_biletow.bilet1_normalny.ToString();
            sumuj_ceny();
        }

        private void sumuj_ceny()
        {
            const double bilet1_normalny_cena = 3.20;
            const double bilet1_ulgowy_cena = 1.60;
            const double bilet2_normalny_cena = 3.80;
            const double bilet2_ulgowy_cena = 1.90;
            const double bilet3_normalny_cena = 4.20;
            const double bilet3_ulgowy_cena = 2.10;
            const double bilet4_normalny_cena = 13.0;
            const double bilet4_ulgowy_cena = 6.5;

            double suma = bilet1_normalny_cena * lista_biletow.bilet1_normalny + bilet1_ulgowy_cena * lista_biletow.bilet1_ulgowy + bilet2_normalny_cena * lista_biletow.bilet2_normalny + bilet2_ulgowy_cena * lista_biletow.bilet2_ulgowy + bilet3_normalny_cena * lista_biletow.bilet3_normalny + bilet3_ulgowy_cena * lista_biletow.bilet3_ulgowy + bilet4_normalny_cena * lista_biletow.bilet4_normalny + bilet4_ulgowy_cena * lista_biletow.bilet4_ulgowy;
            Suma_text.Text = "Razem: " + suma.ToString("F2") + " zł";
            if (suma > 0.0)
                KupButton.IsEnabled = true;
            else
                KupButton.IsEnabled = false;
        }
    }
}

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
        double suma;

        public BiletJednorazowyWindow()
        {
            InitializeComponent();
            bilety_jednorazowe.czysc_ilosc();

            suma = 0.0;
        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            status_biletomatu.wyczysc();
            this.Close();
        }

        private void pomocGlosowa_Click(object sender, RoutedEventArgs e)
        {

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
            const double bilet5_normalny_cena = 4.2;
            const double bilet5_ulgowy_cena = 2.1;

            suma = bilet1_normalny_cena * bilety_jednorazowe.bilet1_normalny + bilet1_ulgowy_cena * bilety_jednorazowe.bilet1_ulgowy + bilet2_normalny_cena * bilety_jednorazowe.bilet2_normalny + bilet2_ulgowy_cena * bilety_jednorazowe.bilet2_ulgowy + bilet3_normalny_cena * bilety_jednorazowe.bilet3_normalny + bilet3_ulgowy_cena * bilety_jednorazowe.bilet3_ulgowy + bilet4_normalny_cena * bilety_jednorazowe.bilet4_normalny + bilet4_ulgowy_cena * bilety_jednorazowe.bilet4_ulgowy + bilet5_normalny_cena * bilety_jednorazowe.bilet5_normalny + bilet5_ulgowy_cena * bilety_jednorazowe.bilet5_ulgowy;
            Suma_text.Text = "Razem: " + suma.ToString("F2") + " zł";
            if (suma > 0.0)
                KupButton.IsEnabled = true;
            else
                KupButton.IsEnabled = false;
        }

        private void Bilet1_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet1_normalny < 1)
                return;
            --bilety_jednorazowe.bilet1_normalny;
            Bilet1_normalny_liczba.Text = bilety_jednorazowe.bilet1_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet1_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet1_normalny > 99)
                return;
            ++bilety_jednorazowe.bilet1_normalny;
            Bilet1_normalny_liczba.Text = bilety_jednorazowe.bilet1_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet1_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet1_ulgowy < 1)
                return;
            --bilety_jednorazowe.bilet1_ulgowy;
            Bilet1_ulgowy_liczba.Text = bilety_jednorazowe.bilet1_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet1_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet1_ulgowy > 99)
                return;
            ++bilety_jednorazowe.bilet1_ulgowy;
            Bilet1_ulgowy_liczba.Text = bilety_jednorazowe.bilet1_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet2_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet2_normalny < 1)
                return;
            --bilety_jednorazowe.bilet2_normalny;
            Bilet2_normalny_liczba.Text = bilety_jednorazowe.bilet2_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet2_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet2_normalny > 99)
                return;
            ++bilety_jednorazowe.bilet2_normalny;
            Bilet2_normalny_liczba.Text = bilety_jednorazowe.bilet2_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet2_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet2_ulgowy < 1)
                return;
            --bilety_jednorazowe.bilet2_ulgowy;
            Bilet2_ulgowy_liczba.Text = bilety_jednorazowe.bilet2_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet2_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet2_ulgowy > 99)
                return;
            ++bilety_jednorazowe.bilet2_ulgowy;
            Bilet2_ulgowy_liczba.Text = bilety_jednorazowe.bilet2_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet3_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet3_normalny < 1)
                return;
            --bilety_jednorazowe.bilet3_normalny;
            Bilet3_normalny_liczba.Text = bilety_jednorazowe.bilet3_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet3_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet3_normalny > 99)
                return;
            ++bilety_jednorazowe.bilet3_normalny;
            Bilet3_normalny_liczba.Text = bilety_jednorazowe.bilet3_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet3_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet3_ulgowy < 1)
                return;
            --bilety_jednorazowe.bilet3_ulgowy;
            Bilet3_ulgowy_liczba.Text = bilety_jednorazowe.bilet3_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet3_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet3_ulgowy > 99)
                return;
            ++bilety_jednorazowe.bilet3_ulgowy;
            Bilet3_ulgowy_liczba.Text = bilety_jednorazowe.bilet3_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet4_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet4_normalny < 1)
                return;
            --bilety_jednorazowe.bilet4_normalny;
            Bilet4_normalny_liczba.Text = bilety_jednorazowe.bilet4_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet4_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet4_normalny > 99)
                return;
            ++bilety_jednorazowe.bilet4_normalny;
            Bilet4_normalny_liczba.Text = bilety_jednorazowe.bilet4_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet4_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet4_ulgowy < 1)
                return;
            --bilety_jednorazowe.bilet4_ulgowy;
            Bilet4_ulgowy_liczba.Text = bilety_jednorazowe.bilet4_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet4_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet4_ulgowy > 99)
                return;
            ++bilety_jednorazowe.bilet4_ulgowy;
            Bilet4_ulgowy_liczba.Text = bilety_jednorazowe.bilet4_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet5_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet5_normalny < 1)
                return;
            --bilety_jednorazowe.bilet5_normalny;
            Bilet5_normalny_liczba.Text = bilety_jednorazowe.bilet5_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet5_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet5_normalny > 99)
                return;
            ++bilety_jednorazowe.bilet5_normalny;
            Bilet5_normalny_liczba.Text = bilety_jednorazowe.bilet5_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet5_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet5_ulgowy < 1)
                return;
            --bilety_jednorazowe.bilet5_ulgowy;
            Bilet5_ulgowy_liczba.Text = bilety_jednorazowe.bilet5_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet5_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe.bilet5_ulgowy > 99)
                return;
            ++bilety_jednorazowe.bilet5_ulgowy;
            Bilet5_ulgowy_liczba.Text = bilety_jednorazowe.bilet5_ulgowy.ToString();
            sumuj_ceny();
        }

        private void KupButton_Click(object sender, RoutedEventArgs e)
        {
            PodsumowanieWindow okno = new PodsumowanieWindow(suma, rodzaj_biletu.BILET_JEDNORAZOWY);
            okno.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
            okno.Show();
        }

        private void Zamkniecie_okna_podsumowania(object sender, EventArgs e)
        {
            if (status_biletomatu.status_zakupu == status.WYDRUKOWANO_BILETY)
                this.Close();
        }

        private void ScrollViewer_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }
    }
}

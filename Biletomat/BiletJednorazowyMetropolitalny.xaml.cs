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
    /// Interaction logic for BiletJednorazowyMetropolitalny.xaml
    /// </summary>
    public partial class BiletJednorazowyMetropolitalny : Window
    {
        double suma;
        public bool aktualizacja_sumy
        {
            set
            {
                sumuj_ceny();
            }
        }
        public BiletJednorazowyMetropolitalny()
        {
            InitializeComponent();

            bilety_jednorazowe_metropolitarne.czysc_ilosc();

            suma = 0.0;
        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pomocGlosowa_Click(object sender, RoutedEventArgs e)
        {

        }
        public void sumuj_ceny()
        {
            const double bilet1_normalny_cena = 3.40;
            const double bilet1_ulgowy_cena = 1.70;
            const double bilet2_normalny_cena = 4.40;
            const double bilet2_ulgowy_cena = 2.20;
            const double bilet3_normalny_cena = 15.0;
            const double bilet3_ulgowy_cena = 7.5;
            const double bilet4_normalny_cena = 20.0;
            const double bilet4_ulgowy_cena = 10.0;
            const double bilet5_normalny_cena = 23.0;
            const double bilet5_ulgowy_cena = 11.5;
            const double bilet6_normalny_cena = 30.0;
            const double bilet6_ulgowy_cena = 15.0;
            const double bilet7_normalny_cena = 46;
            const double bilet7_ulgowy_cena = 23;

            suma = bilet1_normalny_cena * bilety_jednorazowe_metropolitarne.bilet1_normalny + bilet1_ulgowy_cena * bilety_jednorazowe_metropolitarne.bilet1_ulgowy + bilet2_normalny_cena * bilety_jednorazowe_metropolitarne.bilet2_normalny + bilet2_ulgowy_cena * bilety_jednorazowe_metropolitarne.bilet2_ulgowy + bilet3_normalny_cena * bilety_jednorazowe_metropolitarne.bilet3_normalny + bilet3_ulgowy_cena * bilety_jednorazowe_metropolitarne.bilet3_ulgowy + bilet4_normalny_cena * (bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM + bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM + bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK) + bilet4_ulgowy_cena * (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK + bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM + bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM) + bilet5_normalny_cena * bilety_jednorazowe_metropolitarne.bilet5_normalny + bilet5_ulgowy_cena * bilety_jednorazowe_metropolitarne.bilet5_ulgowy + bilet6_normalny_cena * bilety_jednorazowe_metropolitarne.bilet6_normalny + bilet6_ulgowy_cena * bilety_jednorazowe_metropolitarne.bilet6_ulgowy + bilet7_normalny_cena * bilety_jednorazowe_metropolitarne.bilet7_normalny + bilet7_ulgowy_cena * bilety_jednorazowe_metropolitarne.bilet7_ulgowy;
            Suma_text.Text = "Razem: " + suma.ToString("F2") + " zł";
            if (suma > 0.0)
                KupButton.IsEnabled = true;
            else
                KupButton.IsEnabled = false;
        }

        private void Bilet1_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet1_normalny < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet1_normalny;
            Bilet1_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet1_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet1_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet1_normalny > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet1_normalny;
            Bilet1_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet1_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet1_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet1_ulgowy < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet1_ulgowy;
            Bilet1_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet1_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet1_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet1_ulgowy > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet1_ulgowy;
            Bilet1_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet1_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet2_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet2_normalny < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet2_normalny;
            Bilet2_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet2_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet2_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet2_normalny > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet2_normalny;
            Bilet2_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet2_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet2_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet2_ulgowy < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet2_ulgowy;
            Bilet2_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet2_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet2_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet2_ulgowy > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet2_ulgowy;
            Bilet2_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet2_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet3_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet3_normalny < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet3_normalny;
            Bilet3_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet3_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet3_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet3_normalny > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet3_normalny;
            Bilet3_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet3_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet3_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet3_ulgowy < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet3_ulgowy;
            Bilet3_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet3_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet3_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet3_ulgowy > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet3_ulgowy;
            Bilet3_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet3_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet5_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet5_normalny < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet5_normalny;
            Bilet5_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet5_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet5_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet5_normalny > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet5_normalny;
            Bilet5_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet5_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet5_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet5_ulgowy < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet5_ulgowy;
            Bilet5_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet5_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet5_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet5_ulgowy > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet5_ulgowy;
            Bilet5_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet5_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet6_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet6_normalny < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet6_normalny;
            Bilet6_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet6_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet6_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet6_normalny > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet6_normalny;
            Bilet6_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet6_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet6_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet6_ulgowy < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet6_ulgowy;
            Bilet6_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet6_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet6_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet6_ulgowy > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet6_ulgowy;
            Bilet6_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet6_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet7_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet7_normalny < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet7_normalny;
            Bilet7_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet7_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet7_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet7_normalny > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet7_normalny;
            Bilet7_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet7_normalny.ToString();
            sumuj_ceny();
        }

        private void Bilet7_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet7_ulgowy < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet7_ulgowy;
            Bilet7_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet7_ulgowy.ToString();
            sumuj_ceny();
        }

        private void Bilet7_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet7_ulgowy > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet7_ulgowy;
            Bilet7_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet7_ulgowy.ToString();
            sumuj_ceny();
        }

        private void KupButton_Click(object sender, RoutedEventArgs e)
        {
            PodsumowanieWindow okno = new PodsumowanieWindow(suma, rodzaj_biletu.BILET_JEDNORAZOWY_METROPOLITARNY);
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

        private void Wybor_organizatorow_Click(object sender, RoutedEventArgs e)
        {
            WyborOrganizatorowWIndow okno = new WyborOrganizatorowWIndow();
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Owner = Window.GetWindow(this);
            okno.aktualizuj_sume += value => aktualizacja_sumy = value;
            okno.Closed += new EventHandler(Zamkniecie_okna_wyboru_organizatorow);
            okno.ShowDialog();

        }

        private void Zamkniecie_okna_wyboru_organizatorow(object sender, EventArgs e)
        {
            sumuj_ceny();
        }
    }
}

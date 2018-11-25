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
    /// Interaction logic for WyborOrganizatorowWIndow.xaml
    /// </summary>
    public partial class WyborOrganizatorowWIndow : Window
    {
        public event Action<bool> aktualizuj_sume;
        public WyborOrganizatorowWIndow()
        {
            InitializeComponent();

            Bilet1_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM.ToString();
            Bilet1_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM.ToString();
            Bilet2_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM.ToString();
            Bilet2_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM.ToString();
            Bilet3_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK.ToString();
            Bilet3_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK.ToString();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Bilet1_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM;
            Bilet1_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet1_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM;
            Bilet1_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet1_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM;
            Bilet1_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet1_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM;
            Bilet1_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet2_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM;
            Bilet2_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet2_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM;
            Bilet2_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet2_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM;
            Bilet2_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet2_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM;
            Bilet2_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet3_normalny_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK;
            Bilet3_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet3_normalny_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK;
            Bilet3_normalny_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet3_ulgowy_odejmij_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK < 1)
                return;
            --bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK;
            Bilet3_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK.ToString();
            aktualizuj_sume(true);
        }

        private void Bilet3_ulgowy_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK > 99)
                return;
            ++bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK;
            Bilet3_ulgowy_liczba.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK.ToString();
            aktualizuj_sume(true);
        }

        private void ScrollViewer_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }
    }
}

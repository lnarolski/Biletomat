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
        double suma;
        double suma_zaplacono;
        rodzaj_biletu typ_biletow;

        public PodsumowanieWindow(double suma, rodzaj_biletu typ_biletow)
        {
            InitializeComponent();

            this.suma = suma;
            this.typ_biletow = typ_biletow;

            zaplacona_kwota = 0.0;
            Do_zaplaty_text.Text = "DO ZAPŁATY: " + suma.ToString("F2") + " zł";

            switch (typ_biletow)
            {
                case rodzaj_biletu.BILET_JEDNORAZOWY:
                    tworzenie_listy_jednorazowe();
                    break;
                case rodzaj_biletu.BILET_JEDNORAZOWY_METROPOLITARNY:
                    tworzenie_listy_jednorazowe_metropolitarne();
                    break;
                case rodzaj_biletu.BILET_OKRESOWY:
                    tworzenie_listy_okresowe();
                    break;
                default:
                    break;
            }
        }

        private void tworzenie_listy_jednorazowe()
        {
            if (bilety_jednorazowe.bilet1_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet1_normalny.ToString() + "x Jednoprzejazdowy na linie zwykłe normalny";
                temp.FontSize= 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe.bilet1_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet1_ulgowy.ToString() + "x Jednoprzejazdowy na linie zwykłe ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe.bilet2_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet2_normalny.ToString() + "x 1-godzinny na linie zwykłe normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe.bilet2_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet2_ulgowy.ToString() + "x 1-godzinny na linie zwykłe ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe.bilet3_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet3_normalny.ToString() + "x 1-godzinny lub jednoprzejazdowy na linie nocne, pospieszne i zwykłe normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe.bilet3_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet3_ulgowy.ToString() + "x 1-godzinny lub jednoprzejazdowy na linie nocne, pospieszne i zwykłe ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe.bilet4_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet4_normalny.ToString() + "x 24-godzinny na linie nocne, pospieszne i zwykłe normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe.bilet4_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet4_ulgowy.ToString() + "x 24-godzinny na linie nocne, pospieszne i zwykłe ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
        }

        private void tworzenie_listy_jednorazowe_metropolitarne()
        {

        }

        private void tworzenie_listy_okresowe()
        {

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
            if (!zaplacono)
                return;
            if (platnosc_karta)
            {
                suma_zaplacono = suma;
                aktualizuj_kwoty();
            }
            else
            {
                suma_zaplacono += zaplacona_kwota;
                aktualizuj_kwoty();
                if (suma_zaplacono >= suma)
                {

                }
            }
        }

        private void aktualizuj_kwoty()
        {
            Wplacono_text.Text = "Wpłacono: " + suma_zaplacono.ToString("F2") + " zł";
            Pozostalo_text.Text = "Pozostało: " + (suma - suma_zaplacono).ToString("F2") + " zł";
        }
    }
}

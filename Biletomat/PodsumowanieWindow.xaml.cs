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
                    status_biletomatu.wybrany_bilet = rodzaj_biletu.BILET_JEDNORAZOWY;
                    break;
                case rodzaj_biletu.BILET_JEDNORAZOWY_METROPOLITARNY:
                    tworzenie_listy_jednorazowe_metropolitarne();
                    status_biletomatu.wybrany_bilet = rodzaj_biletu.BILET_JEDNORAZOWY_METROPOLITARNY;
                    break;
                case rodzaj_biletu.BILET_OKRESOWY:
                    tworzenie_listy_okresowe();
                    status_biletomatu.wybrany_bilet = rodzaj_biletu.BILET_OKRESOWY;
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
            if (bilety_jednorazowe.bilet5_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet5_normalny.ToString() + "x jednoprzejazdowy na linie nocne, pospieszne i zwykłe normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe.bilet5_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet5_ulgowy.ToString() + "x jednoprzejazdowy na linie nocne, pospieszne i zwykłe ulgowy";
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
                temp.Text = bilety_jednorazowe.bilet3_normalny.ToString() + "x 1-godzinny na linie nocne, pospieszne i zwykłe normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe.bilet3_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe.bilet3_ulgowy.ToString() + "x 1-godzinny na linie nocne, pospieszne i zwykłe ulgowy";
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
            if (bilety_jednorazowe_metropolitarne.bilet1_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet1_normalny.ToString() + "x Jednoprzejazdowy na linie zwykłe normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet1_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet1_ulgowy.ToString() + "x Jednoprzejazdowy na linie zwykłe ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet2_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet2_normalny.ToString() + "x jednoprzejazdowy na linie nocne, pospieszne i zwykłe normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet2_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet2_ulgowy.ToString() + "x jednoprzejazdowy na linie nocne, pospieszne i zwykłe ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet3_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet3_normalny.ToString() + "x 24-godzinny komunalny normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet3_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet3_ulgowy.ToString() + "x 24-godzinny komunalny ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }

            if (bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_ZTM.ToString() + "x 24-godzinny Kolejowo-komunalny (SKM+PR+ZTM) normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZTM.ToString() + "x 24-godzinny Kolejowo-komunalny (SKM+PR+ZTM) ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_ZKM.ToString() + "x 24-godzinny Kolejowo-komunalny (SKM+PR+ZKM) normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_ZKM.ToString() + "x 24-godzinny Kolejowo-komunalny (SKM+PR+ZKM) ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet4_normalny_MZK.ToString() + "x 24-godzinny Kolejowo-komunalny (SKM+PR+MZK) normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet4_ulgowy_MZK.ToString() + "x 24-godzinny Kolejowo-komunalny (SKM+PR+MZK) ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }

            if (bilety_jednorazowe_metropolitarne.bilet5_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet5_normalny.ToString() + "x 24-godzinny kolejowo-komunalny wszystkich organizatorów normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet5_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet5_ulgowy.ToString() + "x 24-godzinny kolejowo-komunalny wszystkich organizatorów ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet6_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet6_normalny.ToString() + "x 72-godzinny komunalny normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet6_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet6_ulgowy.ToString() + "x 72-godzinny komunalny ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet7_normalny != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet7_normalny.ToString() + "x 72-godzinny kolejowo-komunalny wszystkich organizatorów normalny";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
            if (bilety_jednorazowe_metropolitarne.bilet7_ulgowy != 0)
            {
                TextBlock temp = new TextBlock();
                temp.Text = bilety_jednorazowe_metropolitarne.bilet7_ulgowy.ToString() + "x 72-godzinny kolejowo-komunalny wszystkich organizatorów ulgowy";
                temp.FontSize = 30;
                temp.TextWrapping = TextWrapping.Wrap;
                Lista_biletow.Children.Add(temp);
            }
        }

        private void tworzenie_listy_okresowe()
        {

        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            status_biletomatu.wyczysc();
            this.Close();
        }

        private void pomocGlosowa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SymulatorButton_Click(object sender, RoutedEventArgs e)
        {
            SymulatoPlatnosciWindow okno = new SymulatoPlatnosciWindow();
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Owner = Window.GetWindow(this);
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
                status_biletomatu.rodzaj_platnosci = wybrana_platnosc.KARTA_PLATNICZA;
                suma_zaplacono = suma;
                aktualizuj_kwoty();
                int liczba_biletow = 0;
                if (typ_biletow == rodzaj_biletu.BILET_JEDNORAZOWY)
                    liczba_biletow = bilety_jednorazowe.liczba_biletow();
                else if (typ_biletow == rodzaj_biletu.BILET_JEDNORAZOWY_METROPOLITARNY)
                    liczba_biletow = bilety_jednorazowe_metropolitarne.liczba_biletow();
                DrukowanieBiletowWIndow okno = new DrukowanieBiletowWIndow(liczba_biletow);
                okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                okno.Owner = Window.GetWindow(this);
                okno.Closed += new EventHandler(Zamkniecie_okna_drukowania_biletow);
                okno.ShowDialog();
            }
            else
            {
                suma_zaplacono += zaplacona_kwota;
                aktualizuj_kwoty();
                if (suma_zaplacono >= suma)
                {
                    if (suma_zaplacono == suma)
                        status_biletomatu.rodzaj_platnosci = wybrana_platnosc.GOTOWKA_BEZ_RESZTY;
                    else
                        status_biletomatu.rodzaj_platnosci = wybrana_platnosc.GOTOWKA;
                    DrukowanieBiletowWIndow okno = new DrukowanieBiletowWIndow(bilety_jednorazowe.liczba_biletow());
                    okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    okno.Owner = Window.GetWindow(this);
                    okno.Closed += new EventHandler(Zamkniecie_okna_drukowania_biletow);
                    okno.ShowDialog();
                }
            }
        }

        private void Zamkniecie_okna_drukowania_biletow(object sender, EventArgs e)
        {
            if (status_biletomatu.status_zakupu == status.WYDRUKOWANO_BILETY)
                this.Close();
        }

        private void aktualizuj_kwoty()
        {
            Wplacono_text.Text = "Wpłacono: " + suma_zaplacono.ToString("F2") + " zł";
            Pozostalo_text.Text = "Pozostało: " + (suma - suma_zaplacono).ToString("F2") + " zł";
        }

        private void ScrollViewer_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }
    }
}

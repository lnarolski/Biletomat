using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
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
        private CultureInfo culture_info;
        private SpeechSynthesizer reader;
        private bool wlaczona_pomoc_glosowa;
        private bool zatrzymaj_pomoc_glosowa;
        private Thread thread_pomocGlosowa;

        public PodsumowanieWindow(double suma, rodzaj_biletu typ_biletow)
        {
            InitializeComponent();

            this.suma = suma;
            this.typ_biletow = typ_biletow;

            zaplacona_kwota = 0.0;
            Do_zaplaty_text.Text = "DO ZAPŁATY: " + suma.ToString("F2") + " zł";

            culture_info = new CultureInfo("pl-PL");
            reader = new SpeechSynthesizer();
            var voices = reader.GetInstalledVoices(culture_info);
            reader.SelectVoice(voices[0].VoiceInfo.Name);

            status_biletomatu.wyczysc();
            status_biletomatu.powitanie = false;

            wlaczona_pomoc_glosowa = false;

            Closing += this.OnWindowClosing;

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

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            zatrzymaj_pomoc_glosowa = true;
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
            zatrzymaj_pomoc_glosowa = true;
            if (suma_zaplacono > 0.0)
            {
                status_biletomatu.rodzaj_platnosci = wybrana_platnosc.PLATNOSC_ANULOWANA;
                KomunikatWindow okno = new KomunikatWindow();
                okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                okno.Owner = Window.GetWindow(this);
                okno.ShowDialog();
            }
            status_biletomatu.wyczysc();
            this.Close();
        }

        private void pomocGlosowa_watek()
        {
            if (reader.State == SynthesizerState.Ready)
            {
                Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x22, 0x64, 0x9C)); }));
                resetuj_przyciski();
                reader.SpeakAsync("Ekran podsumowania zakupu.");
                Thread.Sleep(500);
                while (true)
                {
                    if (reader.State == SynthesizerState.Ready)
                    {
                        break;
                    }
                    if (zatrzymaj_pomoc_glosowa)
                    {
                        reader.SpeakAsyncCancelAll();
                        Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD)); }));
                        resetuj_przyciski();
                        wlaczona_pomoc_glosowa = false;
                        zatrzymaj_pomoc_glosowa = false;
                        return;
                    }
                }
                resetuj_przyciski();
                reader.SpeakAsync("W celu wyświetlenia wszystkich kupowanych biletów należy dotknąć i przesunąć palcem w górę lub w dół po liście biletów.");
                Thread.Sleep(500);
                while (true)
                {
                    if (reader.State == SynthesizerState.Ready)
                    {
                        break;
                    }
                    if (zatrzymaj_pomoc_glosowa)
                    {
                        reader.SpeakAsyncCancelAll();
                        Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD)); }));
                        resetuj_przyciski();
                        wlaczona_pomoc_glosowa = false;
                        zatrzymaj_pomoc_glosowa = false;
                        return;
                    }
                }
                resetuj_przyciski();
                reader.SpeakAsync("W przypadku płatności gotówką należy skorzystać z urządzenia wrzutowego znajdującego się po prawej stronie biletomatu. Po uiszczeniu wymaganej opłaty automat automatycznie rozpocznie proces drukowania biletów. Automat wydaje resztę.");
                Thread.Sleep(500);
                while (true)
                {
                    if (reader.State == SynthesizerState.Ready)
                    {
                        break;
                    }
                    if (zatrzymaj_pomoc_glosowa)
                    {
                        reader.SpeakAsyncCancelAll();
                        Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD)); }));
                        resetuj_przyciski();
                        wlaczona_pomoc_glosowa = false;
                        zatrzymaj_pomoc_glosowa = false;
                        return;
                    }
                }
                resetuj_przyciski();
                reader.SpeakAsync("W przypadku płatności kartą należy postępować zgodnie z poleceniami terminala znajdującego się po prawej stronie biletomatu.");
                Thread.Sleep(500);
                while (true)
                {
                    if (reader.State == SynthesizerState.Ready)
                    {
                        break;
                    }
                    if (zatrzymaj_pomoc_glosowa)
                    {
                        reader.SpeakAsyncCancelAll();
                        Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD)); }));
                        resetuj_przyciski();
                        wlaczona_pomoc_glosowa = false;
                        zatrzymaj_pomoc_glosowa = false;
                        return;
                    }
                }
                resetuj_przyciski();
                reader.SpeakAsync("Jeśli chcesz powrócić do ekranu głównego naciśnij przycisk wstecz. Zapłacona kwota zostanie zwrócona.");
                Thread.Sleep(500);
                przycisk_mruganie(WsteczButton);
                while (true)
                {
                    if (reader.State == SynthesizerState.Ready)
                    {
                        break;
                    }
                    if (zatrzymaj_pomoc_glosowa)
                    {
                        reader.SpeakAsyncCancelAll();
                        Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD)); }));
                        resetuj_przyciski();
                        wlaczona_pomoc_glosowa = false;
                        zatrzymaj_pomoc_glosowa = false;
                        return;
                    }
                }
                Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD)); }));
                resetuj_przyciski();
                wlaczona_pomoc_glosowa = false;
                zatrzymaj_pomoc_glosowa = false;
            }
        }

        private void pomocGlosowa_Click(object sender, RoutedEventArgs e)
        {
            if (!wlaczona_pomoc_glosowa)
            {
                thread_pomocGlosowa = new Thread(pomocGlosowa_watek);
                thread_pomocGlosowa.Start();
                wlaczona_pomoc_glosowa = true;
            }
            else
            {
                zatrzymaj_pomoc_glosowa = true;
            }
        }

        private void przycisk_mruganie(Button przycisk)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                przycisk.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x22, 0x64, 0x9C));
            }));
        }

        private void resetuj_przyciski()
        {
            Dispatcher.BeginInvoke(new Action(() => {
                WsteczButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
            }));
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
                zatrzymaj_pomoc_glosowa = true;
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
                    zatrzymaj_pomoc_glosowa = true;
                    if (suma_zaplacono == suma)
                        status_biletomatu.rodzaj_platnosci = wybrana_platnosc.GOTOWKA_BEZ_RESZTY;
                    else
                        status_biletomatu.rodzaj_platnosci = wybrana_platnosc.GOTOWKA;
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
            }
        }

        private void Zamkniecie_okna_drukowania_biletow(object sender, EventArgs e)
        {
            if (status_biletomatu.status_zakupu == status.WYDRUKOWANO_BILETY)
            {
                KomunikatWindow okno = new KomunikatWindow();
                okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                okno.Owner = Window.GetWindow(this);
                okno.ShowDialog();
                this.Close();
            }
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

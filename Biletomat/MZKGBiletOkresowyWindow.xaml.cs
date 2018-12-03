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
    /// Interaction logic for MZKGBiletOkresowyWindow.xaml
    /// </summary>
    public partial class MZKGBiletOkresowyWindow : Window
    {
        private CultureInfo culture_info;
        private SpeechSynthesizer reader;
        private bool wlaczona_pomoc_glosowa;
        private bool zatrzymaj_pomoc_glosowa;
        private Thread thread_pomocGlosowa;

        public MZKGBiletOkresowyWindow()
        {
            InitializeComponent();

            if (bilet_okresowy.wlozony_Bilet_Okresowy == wlozony_bilet_okresowy.LEGITYMACJA_STUDENCKA)
            {
                Komunalny_30_normalny.IsEnabled = false;
                Komunalny_mies_normalny.IsEnabled = false;
            }

            culture_info = new CultureInfo("pl-PL");
            reader = new SpeechSynthesizer();
            var voices = reader.GetInstalledVoices(culture_info);
            reader.SelectVoice(voices[0].VoiceInfo.Name);
            wlaczona_pomoc_glosowa = false;
            Closing += this.OnWindowClosing;
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            zatrzymaj_pomoc_glosowa = true;
        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pomocGlosowa_watek()
        {
            if (reader.State == SynthesizerState.Ready)
            {
                Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x22, 0x64, 0x9C)); }));
                resetuj_przyciski();
                reader.SpeakAsync("Ekran zakupu biletów okresowych MZKG.");
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
                reader.SpeakAsync("W celu zakupu biletu naciśnij przycisk z ceną pożądanego biletu. Dodatkowe parametry można wybrać w kolejnych oknach dialogowych.");
                Thread.Sleep(500);
                przycisk_mruganie(Komunalny_30_ulgowy);
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
                reader.SpeakAsync("Jeśli chcesz wrócić do poprzedniego ekranu naciśnij przycisk wstecz.");
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
                Komunalny_30_ulgowy.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                WsteczButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
            }));
        }

        private void Komunalny_30_normalny_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.MZKG;
            bilet_okresowy.okres_Biletu = okres_biletu._30_DNIOWY;
            bilet_okresowy.typ_Biletu = typ_biletu.BRAK;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.BRAK;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.METROPOLITALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.BRAK;
            zatrzymaj_pomoc_glosowa = true;
            PodsumowanieWindow okno = new PodsumowanieWindow(bilet_okresowy.cena_bilet(), rodzaj_biletu.BILET_OKRESOWY);
            okno.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
            okno.Show();
        }

        private void Zamkniecie_okna_podsumowania(object sender, EventArgs e)
        {
            if (status_biletomatu.status_zakupu == status.WYDRUKOWANO_BILETY)
                this.Close();
        }

        private void Komunalny_30_ulgowy_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.MZKG;
            bilet_okresowy.okres_Biletu = okres_biletu._30_DNIOWY;
            bilet_okresowy.typ_Biletu = typ_biletu.BRAK;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.BRAK;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.METROPOLITALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.BRAK;
            zatrzymaj_pomoc_glosowa = true;
            PodsumowanieWindow okno = new PodsumowanieWindow(bilet_okresowy.cena_bilet(), rodzaj_biletu.BILET_OKRESOWY);
            okno.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
            okno.Show();
        }

        private void Komunalny_mies_normalny_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.MZKG;
            bilet_okresowy.okres_Biletu = okres_biletu.MIESIECZNY;
            bilet_okresowy.typ_Biletu = typ_biletu.BRAK;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.BRAK;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.METROPOLITALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.BRAK;

            WyborMiesiacaWindow okno = new WyborMiesiacaWindow();
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_wyboru_miesiaca);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void Zamkniecie_okna_wyboru_miesiaca(object sender, EventArgs e)
        {
            if (!(String.Compare(bilet_okresowy.wybrany_miesiac, "") == 0))
            {
                zatrzymaj_pomoc_glosowa = true;
                PodsumowanieWindow okno = new PodsumowanieWindow(bilet_okresowy.cena_bilet(), rodzaj_biletu.BILET_OKRESOWY);
                okno.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
                okno.Show();
            }
        }

        private void Komunalny_mies_ulgowy_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.MZKG;
            bilet_okresowy.okres_Biletu = okres_biletu.MIESIECZNY;
            bilet_okresowy.typ_Biletu = typ_biletu.BRAK;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.BRAK;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.METROPOLITALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.BRAK;

            WyborMiesiacaWindow okno = new WyborMiesiacaWindow();
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_wyboru_miesiaca);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;
using definicje_zmiennych;
using System.ComponentModel;

namespace Biletomat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private System.Timers.Timer zegar;
        private CultureInfo culture_info;
        private SpeechSynthesizer reader;
        private bool wlaczona_pomoc_glosowa;
        private bool zatrzymaj_pomoc_glosowa;
        private Thread thread_pomocGlosowa;

        public MainWindow()
        {
            InitializeComponent();
            culture_info = new CultureInfo("pl-PL");
            czas.Text = culture_info.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek) + ", " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss");

            zegar = new System.Timers.Timer(1000);
            zegar.Elapsed += zegar_tick;
            zegar.Start();

            reader = new SpeechSynthesizer();
            var voices = reader.GetInstalledVoices(culture_info);
            reader.SelectVoice(voices[0].VoiceInfo.Name);
            
            status_biletomatu.wyczysc();
            status_biletomatu.powitanie = false;

            wlaczona_pomoc_glosowa = false;

            Closing += this.OnWindowClosing;
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            zatrzymaj_pomoc_glosowa = true;
        }

        private void zegar_tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { czas.Text = culture_info.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek) + ", " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss"); }));
        }

        private void biletJednorazowyButton_Click(object sender, RoutedEventArgs e)
        {
            zatrzymaj_pomoc_glosowa = true;
            BiletJednorazowyWindow okno = new BiletJednorazowyWindow();
            okno.Closed += new EventHandler(Zamkniecie_okna_biletJednorazowy);
            okno.Show();
        }

        private void Zamkniecie_okna_biletJednorazowy(object sender, EventArgs e)
        {
            if (status_biletomatu.rodzaj_platnosci == wybrana_platnosc.BRAK)
                status_biletomatu.wyczysc(); //GDZIEŚ JEST NADPISYWANA WARTOŚĆ status_biletomatu.status_zakupu -> Znaleźć w przyszłości
            if (status_biletomatu.status_zakupu == status.WYDRUKOWANO_BILETY)
            {
                KomunikatWindow okno = new KomunikatWindow();
                okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                okno.Owner = Window.GetWindow(this);
                okno.ShowDialog();
            }
            status_biletomatu.powitanie = false;
        }

        private void biletJednorazowyMetropolitalnyButton_Click(object sender, RoutedEventArgs e)
        {
            zatrzymaj_pomoc_glosowa = true;
            BiletJednorazowyMetropolitalny okno = new BiletJednorazowyMetropolitalny();
            okno.Closed += new EventHandler(Zamkniecie_okna_biletJednorazowy);
            okno.Show();
        }

        private void taryfaButton_Click(object sender, RoutedEventArgs e)
        {
            zatrzymaj_pomoc_glosowa = true;
            TaryfaWindow okno = new TaryfaWindow();
            okno.Show();
        }

        private void pomocGlosowa_watek()
        {
            if (reader.State == SynthesizerState.Ready)
            {
                Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x22, 0x64, 0x9C)); }));
                resetuj_przyciski();
                reader.SpeakAsync("WItaj w biletomacie ZKM Gdynia.");
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
                reader.SpeakAsync("Jeśli chcesz kupić bilet jednorazowy dotknij przycisku \"BILET JEDNORAZOWY\"");
                Thread.Sleep(500);
                przycisk_mruganie(biletJednorazowyButton);
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
                reader.SpeakAsync("Jeśli chcesz kupić bilet jednorazowy metropolitalny obowiązujący na terenie całego Trójmiasta dotknij przycisku \"BILET JEDNORAZOWY METROPOLITALNY\"");
                Thread.Sleep(500);
                przycisk_mruganie(biletJednorazowyMetropolitalnyButton);
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
                reader.SpeakAsync("Aby doładować kartę miejską umieść ją w czytniku kart zbliżeniowych");
                Thread.Sleep(500);
                przycisk_mruganie(biletOkresowyButton);
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
                reader.SpeakAsync("Jeśli chcesz uzyskać infromacje o obowiązujących taryfach oraz regulaminach przewozu dotknij przycisku \"TARYFA\"");
                Thread.Sleep(500);
                przycisk_mruganie(taryfaButton);
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
                przycisk.Background = new SolidColorBrush(Color.FromArgb(0xFF,0x22,0x64,0x9C));
            }));
        }

        private void resetuj_przyciski()
        {
            Dispatcher.BeginInvoke(new Action(() => {
                biletJednorazowyButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                biletJednorazowyMetropolitalnyButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                biletOkresowyButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                taryfaButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
            }));
        }

        private void biletOkresowyButton_Click(object sender, RoutedEventArgs e)
        {
            zatrzymaj_pomoc_glosowa = true;
        }
    }
}

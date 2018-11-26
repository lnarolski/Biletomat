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
using System.Windows.Controls.Primitives;
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
        private CultureInfo culture_info;
        private SpeechSynthesizer reader;
        private bool wlaczona_pomoc_glosowa;
        private bool zatrzymaj_pomoc_glosowa;
        private Thread thread_pomocGlosowa;
        double suma;

        public BiletJednorazowyWindow()
        {
            InitializeComponent();
            bilety_jednorazowe.czysc_ilosc();

            suma = 0.0;

            culture_info = new CultureInfo("pl-PL");

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

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            zatrzymaj_pomoc_glosowa = true;
            status_biletomatu.wyczysc();
            this.Close();
        }

        private void pomocGlosowa_watek()
        {
            if (reader.State == SynthesizerState.Ready)
            {
                Dispatcher.BeginInvoke(new Action(() => { pomocGlosowa.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x22, 0x64, 0x9C)); }));
                resetuj_przyciski();
                reader.SpeakAsync("Ekran zakupu biletów jednorazowych.");
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
                reader.SpeakAsync("W celu wyświetlenia wszystkich biletów należy dotknąć i przesunąć palcem w górę lub w dół po liście biletów.");
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
                reader.SpeakAsync("W celu zakupu biletu naciskaj przycisk z plusem pożądaną liczbę razy. Aby dodać większą liczbę biletów dotknij i przytrzymaj przycisk ze znakiem plus.");
                Thread.Sleep(500);
                przycisk_mruganie(Bilet1_normalny_dodaj);
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
                reader.SpeakAsync("W celu zmniejszenia liczby biletów należy nacisnąć przycisk ze znakiem minus pożądaną liczbę razy.");
                Thread.Sleep(500);
                przycisk_mruganie(Bilet1_normalny_odejmij);
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
                reader.SpeakAsync("Aby przejść do ekranu podsumowania naciśnij przycisk zapłać. Aby przycisk był aktywny należy wybrać przynajmniej jeden bilet.");
                Thread.Sleep(500);
                przycisk_mruganie(KupButton);
                Dispatcher.BeginInvoke(new Action(() => { KupButton.IsEnabled = true; }));
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
                sumuj_ceny();
                reader.SpeakAsync("Jeśli chcesz powrócić do ekranu głównego naciśnij przycisk wstecz.");
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

        private void przycisk_mruganie(RepeatButton przycisk)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                przycisk.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x22, 0x64, 0x9C));
            }));
        }

        private void resetuj_przyciski()
        {
            Dispatcher.BeginInvoke(new Action(() => {
                Bilet1_normalny_odejmij.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                Bilet1_normalny_dodaj.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                KupButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                WsteczButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
            }));
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
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Suma_text.Text = "Razem: " + suma.ToString("F2") + " zł";
                if (suma > 0.0)
                    KupButton.IsEnabled = true;
                else
                    KupButton.IsEnabled = false;
            } ));
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
            if (suma > 0.0)
            {
                zatrzymaj_pomoc_glosowa = true;
                PodsumowanieWindow okno = new PodsumowanieWindow(suma, rodzaj_biletu.BILET_JEDNORAZOWY);
                okno.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
                okno.Show();
            }
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

﻿using System;
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
    /// Interaction logic for ZKMBiletOkresowyWindow.xaml
    /// </summary>
    public partial class ZKMBiletOkresowyWindow : Window
    {
        private CultureInfo culture_info;
        private SpeechSynthesizer reader;
        private bool wlaczona_pomoc_glosowa;
        private bool zatrzymaj_pomoc_glosowa;
        private Thread thread_pomocGlosowa;

        public ZKMBiletOkresowyWindow()
        {
            InitializeComponent();

            tlo.Visibility = Visibility.Hidden;

            if (bilet_okresowy.wlozony_Bilet_Okresowy == wlozony_bilet_okresowy.LEGITYMACJA_STUDENCKA)
            {
                _1x1.IsEnabled = false;
                _1x2.IsEnabled = false;
                _1x3.IsEnabled = false;
                _1x4.IsEnabled = false;
                _1x5.IsEnabled = false;
                _3x1.IsEnabled = false;
                _3x2.IsEnabled = false;
                _3x3.IsEnabled = false;
                _3x4.IsEnabled = false;
                _3x5.IsEnabled = false;
                _5x1.IsEnabled = false;
                _5x2.IsEnabled = false;
                _5x3.IsEnabled = false;
                _5x4.IsEnabled = false;
                _5x5.IsEnabled = false;
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
                reader.SpeakAsync("Ekran zakupu biletów okresowych ZKM.");
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
                przycisk_mruganie(_2x1);
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
                _2x1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
                WsteczButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
            }));
        }

        private void _1x2_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _1x1_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.ZWYKLE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false,false,false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void Zamkniecie_okna_WyborParametrowBiletuZKMWindow(object sender, EventArgs e)
        {
            if (bilet_okresowy.okres_Biletu != okres_biletu.BRAK)
            {
                tlo.Visibility = Visibility.Visible;
                if (bilet_okresowy.okres_Biletu == okres_biletu.MIESIECZNY)
                {
                    WyborMiesiacaWindow okno = new WyborMiesiacaWindow();
                    okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    okno.Closed += new EventHandler(Zamkniecie_okna_WyborMiesiacaWindow);
                    okno.Owner = Window.GetWindow(this);
                    okno.ShowDialog();
                }
                else
                {
                    zatrzymaj_pomoc_glosowa = true;
                    PodsumowanieWindow okno2 = new PodsumowanieWindow(bilet_okresowy.cena_bilet(), rodzaj_biletu.BILET_OKRESOWY);
                    okno2.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
                    okno2.Show();
                    tlo.Visibility = Visibility.Hidden;
                }

            }

            tlo.Visibility = Visibility.Hidden;
        }

        private void Zamkniecie_okna_WyborMiesiacaWindow(object sender, EventArgs e)
        {
            if ((String.Compare(bilet_okresowy.wybrany_miesiac, "") == 0))
            {
                tlo.Visibility = Visibility.Hidden;
                return;
            }
            else
            {
                zatrzymaj_pomoc_glosowa = true;
                PodsumowanieWindow okno2 = new PodsumowanieWindow(bilet_okresowy.cena_bilet(), rodzaj_biletu.BILET_OKRESOWY);
                okno2.Closed += new EventHandler(Zamkniecie_okna_podsumowania);
                okno2.Show();
                tlo.Visibility = Visibility.Hidden;
            }
        }

        private void Zamkniecie_okna_podsumowania(object sender, EventArgs e)
        {
            if (status_biletomatu.status_zakupu == status.WYDRUKOWANO_BILETY)
            {
                bilet_okresowy.czysc_bilet();
                this.Close();
            }
        }

        private void _1x3_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, true, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _1x4_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _1x5_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.SIEC_KOMUNIKACYJNA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _2x1_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.ZWYKLE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _2x2_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _2x3_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, true, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _2x4_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _2x5_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.OD_PON_DO_PT;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.SIEC_KOMUNIKACYJNA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _3x1_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.ZWYKLE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _3x2_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _3x3_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, true, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _3x4_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _3x5_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.SIEC_KOMUNIKACYJNA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _4x1_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.ZWYKLE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _4x2_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _4x3_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, true, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _4x4_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _4x5_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.SIEC_KOMUNIKACYJNA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _5x1_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.NA_OKAZICIELA;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.ZWYKLE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _5x2_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.NA_OKAZICIELA;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _5x3_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.NA_OKAZICIELA;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, true, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _5x4_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.NA_OKAZICIELA;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _5x5_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            bilet_okresowy.typ_Biletu = typ_biletu.NA_OKAZICIELA;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.NORMALNY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.SIEC_KOMUNIKACYJNA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _6x1_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.ZWYKLE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, true);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _6x2_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, true);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _6x3_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, true, true);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _6x4_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, false, true);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _6x5_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.SIEC_KOMUNIKACYJNA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, true);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _7x1_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.ZWYKLE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _7x2_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.GDYNIA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _7x3_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, true, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _7x4_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.BRAK;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(true, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }

        private void _7x5_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.przewoznik = przewoznik.ZKM;
            bilet_okresowy.okres_Biletu = okres_biletu.SEMESTRALNY;
            bilet_okresowy.typ_Biletu = typ_biletu.IMIENNY;
            bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci.CALY_TYDZIEN;
            bilet_okresowy.okres_Semestru = okres_semestru.BRAK;
            bilet_okresowy.rodzaj_Ulgi = rodzaj_ulgi.ULGOWY;
            bilet_okresowy.rodzaj_Linii = rodzaj_linii.NOCNE;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.SIEC_KOMUNIKACYJNA;

            tlo.Visibility = Visibility.Visible;
            WyborParametrowBiletuZKMWindow okno = new WyborParametrowBiletuZKMWindow(false, false, false);
            okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            okno.Closed += new EventHandler(Zamkniecie_okna_WyborParametrowBiletuZKMWindow);
            okno.Owner = Window.GetWindow(this);
            okno.ShowDialog();
        }
    }
}

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
using System.Timers;
using definicje_zmiennych;

namespace Biletomat
{
    /// <summary>
    /// Interaction logic for DrukowanieBiletowWIndow.xaml
    /// </summary>
    public partial class DrukowanieBiletowWIndow : Window
    {
        Timer timer;
        int liczba_biletow_do_wydrukowania;
        int liczba_biletow;
        int sekundy;
        DateTime pozostaly_czas;

        public DrukowanieBiletowWIndow(int liczba_biletow)
        {
            InitializeComponent();

            this.liczba_biletow_do_wydrukowania = liczba_biletow;
            this.liczba_biletow = liczba_biletow;

            if (status_biletomatu.wybrany_bilet == rodzaj_biletu.BILET_JEDNORAZOWY || status_biletomatu.wybrany_bilet == rodzaj_biletu.BILET_JEDNORAZOWY_METROPOLITARNY)
                Opis.Text = "DRUKOWANIE BILETÓW";
            if (status_biletomatu.wybrany_bilet == rodzaj_biletu.BILET_OKRESOWY)
                Opis.Text = "PROGRAMOWANIE KARTY MIEJSKIEJ";

            Pasek.Value = 0;
            this.sekundy = 0;
            pozostaly_czas = new DateTime();
            pozostaly_czas = pozostaly_czas.AddSeconds(3 * liczba_biletow);
            Czas_drukowania_text.Text = pozostaly_czas.ToString("mm:ss");

            timer = new Timer(1000);
            timer.Elapsed += AktualizujEkran;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        private void AktualizujEkran(Object source, ElapsedEventArgs e)
        {
            ++sekundy;
            Dispatcher.BeginInvoke(new Action(() => { Pasek.Value = (int)((sekundy/(liczba_biletow * 3.0)) * 100); }));
            if (pozostaly_czas.Second > 1)
            {
                pozostaly_czas = pozostaly_czas.AddSeconds(-1);
                Dispatcher.BeginInvoke(new Action(() => { Czas_drukowania_text.Text = pozostaly_czas.ToString("mm:ss"); }));
            }
            else
            {
                Dispatcher.BeginInvoke(new Action(() => { Czas_drukowania_text.Text = "00:00"; }));
                Dispatcher.BeginInvoke(new Action(() => { Pasek.Value = 100; }));
                Dispatcher.BeginInvoke(new Action(() => { this.Close(); }));
                status_biletomatu.status_zakupu = status.WYDRUKOWANO_BILETY;
            }
        }
    }
}

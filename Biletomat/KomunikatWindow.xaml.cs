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
    /// Interaction logic for KomunikatWindow.xaml
    /// </summary>
    public partial class KomunikatWindow : Window
    {
        public KomunikatWindow()
        {
            InitializeComponent();

            if (status_biletomatu.rodzaj_platnosci == wybrana_platnosc.PLATNOSC_ANULOWANA)
            {
                Naglowek_tresc.Text = "PŁATNOŚĆ ANULOWANA";
                Komunikat_tresc.Text = "Odbierz resztę.";
            }
            else
            {
                if (status_biletomatu.rodzaj_platnosci == wybrana_platnosc.GOTOWKA)
                    Naglowek_tresc.Text = "ODBIERZ BILETY ORAZ RESZTĘ";
                else if (status_biletomatu.rodzaj_platnosci == wybrana_platnosc.GOTOWKA_BEZ_RESZTY)
                    Naglowek_tresc.Text = "ODBIERZ BILETY";
                else if (status_biletomatu.rodzaj_platnosci == wybrana_platnosc.KARTA_PLATNICZA)
                    Naglowek_tresc.Text = "ODBIERZ BILETY";
                Komunikat_tresc.Text = "Dziękujemy za skorzystanie z usług naszego biletomatu.";
            }
            status_biletomatu.wyczysc();
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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

            if (status_biletomatu.rodzaj_platnosci == wybrana_platnosc.GOTOWKA)
                Komunikat_tresc.Text = "Odbierz bilety oraz resztę.";
            else if (status_biletomatu.rodzaj_platnosci == wybrana_platnosc.GOTOWKA_BEZ_RESZTY)
                Komunikat_tresc.Text = "Odbierz bilety.";
            else if (status_biletomatu.rodzaj_platnosci == wybrana_platnosc.KARTA_PLATNICZA)
                Komunikat_tresc.Text = "Odbierz bilety.";
            status_biletomatu.wyczysc();
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

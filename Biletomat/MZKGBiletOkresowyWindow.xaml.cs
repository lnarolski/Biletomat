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
    /// Interaction logic for MZKGBiletOkresowyWindow.xaml
    /// </summary>
    public partial class MZKGBiletOkresowyWindow : Window
    {
        private bool zatrzymaj_pomoc_glosowa;

        public MZKGBiletOkresowyWindow()
        {
            InitializeComponent();

            if (bilet_okresowy.wlozony_Bilet_Okresowy == wlozony_bilet_okresowy.LEGITYMACJA_STUDENCKA)
            {
                Komunalny_30_normalny.IsEnabled = false;
                Komunalny_mies_normalny.IsEnabled = false;
            }
        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pomocGlosowa_Click(object sender, RoutedEventArgs e)
        {

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

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
    /// Interaction logic for WyborParametrowBiletuZKMWindow.xaml
    /// </summary>
    public partial class WyborParametrowBiletuZKMWindow : Window
    {
        bool _4_mies;
        bool pierwsza_lista_obszaru_waznosci;
        bool wymagana_lista_obszarow;
        public WyborParametrowBiletuZKMWindow(bool wymagana_lista_obszarow = false, bool pierwsza_lista_obszaru_waznosci = false, bool _4_mies = false)
        {
            InitializeComponent();

            this.wymagana_lista_obszarow = wymagana_lista_obszarow;
            this.pierwsza_lista_obszaru_waznosci = pierwsza_lista_obszaru_waznosci;

            wybor1.IsChecked = true;

            if (bilet_okresowy.okres_Biletu != okres_biletu.SEMESTRALNY)
            {
                wybor1.Content = "Miesięczny";
                wybor2.Content = "30 dniowy";
            }
            else
            {
                this._4_mies = _4_mies;
                if (_4_mies)
                {
                    wybor1.Content = "01.10 - 31.01";
                    wybor2.Content = "01.02 - 31.05";
                }
                else
                {
                    wybor1.Content = "01.09 - 31.01";
                    wybor2.Content = "01.02 - 30.06";
                }
            }

            if (wymagana_lista_obszarow)
            {
                if (pierwsza_lista_obszaru_waznosci)
                {
                    Sopot.IsChecked = true;
                    Rumia_Reda_Wejherowo.IsEnabled = false;
                    Gm_wejherowo_Rumia.IsEnabled = false;
                }
                else
                {
                    Rumia_Reda_Wejherowo.IsChecked = true;
                    Sopot.IsEnabled = false;
                    Rumia.IsEnabled = false;
                    Gm_Kosakowo.IsEnabled = false;
                    Gm_Zukowo.IsEnabled = false;
                    Gm_Szemud.IsEnabled = false;
                    Gm_Wejherowo.IsEnabled = false;
                }
            }
            else
            {
                Panel1.Visibility = Visibility.Hidden;
                Panel2.Visibility = Visibility.Hidden;
                ObszarNapis.Visibility = Visibility.Hidden;
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void wybor1_Checked(object sender, RoutedEventArgs e)
        {
            wybor2.IsChecked = false;
            if (bilet_okresowy.okres_Biletu != okres_biletu.SEMESTRALNY)
            {
                bilet_okresowy.okres_Biletu = okres_biletu.MIESIECZNY;
            }
            else
            {
                if (_4_mies)
                {
                    bilet_okresowy.okres_Semestru = okres_semestru.ZIMOWY_4_MIES;
                    bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci._4_MIESIECZNY;
                }
                else
                {
                    bilet_okresowy.okres_Semestru = okres_semestru.ZIMOWY_5_MIES;
                    bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci._5_MIESIECZNY;
                }
            }
        }

        private void wybor2_Checked(object sender, RoutedEventArgs e)
        {
            wybor1.IsChecked = false;
            if (bilet_okresowy.okres_Biletu != okres_biletu.SEMESTRALNY)
            {
                bilet_okresowy.okres_Biletu = okres_biletu._30_DNIOWY;
            }
            else
            {
                if (_4_mies)
                {
                    bilet_okresowy.okres_Semestru = okres_semestru.LETNI_4_MIES;
                    bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci._4_MIESIECZNY;
                }
                else
                {
                    bilet_okresowy.okres_Semestru = okres_semestru.LETNI_5_MIES;
                    bilet_okresowy.dlugosc_Waznosci = dlugosc_waznosci._5_MIESIECZNY;
                }
            }
        }

        private void Sopot_Checked(object sender, RoutedEventArgs e)
        {
            Sopot.IsChecked = true;
            Rumia.IsChecked = false;
            Gm_Kosakowo.IsChecked = false;
            Gm_Zukowo.IsChecked = false;
            Gm_Szemud.IsChecked = false;
            Gm_Wejherowo.IsChecked = false;
            Rumia_Reda_Wejherowo.IsChecked = false;
            Gm_wejherowo_Rumia.IsChecked = false;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.SOPOT;
        }

        private void Rumia_Checked(object sender, RoutedEventArgs e)
        {
            Sopot.IsChecked = false;
            Rumia.IsChecked = true;
            Gm_Kosakowo.IsChecked = false;
            Gm_Zukowo.IsChecked = false;
            Gm_Szemud.IsChecked = false;
            Gm_Wejherowo.IsChecked = false;
            Rumia_Reda_Wejherowo.IsChecked = false;
            Gm_wejherowo_Rumia.IsChecked = false;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.RUMIA;
        }

        private void Gm_Kosakowo_Checked(object sender, RoutedEventArgs e)
        {
            Sopot.IsChecked = false;
            Rumia.IsChecked = false;
            Gm_Kosakowo.IsChecked = true;
            Gm_Zukowo.IsChecked = false;
            Gm_Szemud.IsChecked = false;
            Gm_Wejherowo.IsChecked = false;
            Rumia_Reda_Wejherowo.IsChecked = false;
            Gm_wejherowo_Rumia.IsChecked = false;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.KOSAKOWO_GM;
        }

        private void Gm_Zukowo_Checked(object sender, RoutedEventArgs e)
        {
            Sopot.IsChecked = false;
            Rumia.IsChecked = false;
            Gm_Kosakowo.IsChecked = false;
            Gm_Zukowo.IsChecked = true;
            Gm_Szemud.IsChecked = false;
            Gm_Wejherowo.IsChecked = false;
            Rumia_Reda_Wejherowo.IsChecked = false;
            Gm_wejherowo_Rumia.IsChecked = false;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.ZUKOWO_GM;
        }

        private void Gm_Szemud_Checked(object sender, RoutedEventArgs e)
        {
            Sopot.IsChecked = false;
            Rumia.IsChecked = false;
            Gm_Kosakowo.IsChecked = false;
            Gm_Zukowo.IsChecked = false;
            Gm_Szemud.IsChecked = true;
            Gm_Wejherowo.IsChecked = false;
            Rumia_Reda_Wejherowo.IsChecked = false;
            Gm_wejherowo_Rumia.IsChecked = false;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.SZEMUD_GM;
        }

        private void Gm_Wejherowo_Checked(object sender, RoutedEventArgs e)
        {
            Sopot.IsChecked = false;
            Rumia.IsChecked = false;
            Gm_Kosakowo.IsChecked = false;
            Gm_Zukowo.IsChecked = false;
            Gm_Szemud.IsChecked = false;
            Gm_Wejherowo.IsChecked = true;
            Rumia_Reda_Wejherowo.IsChecked = false;
            Gm_wejherowo_Rumia.IsChecked = false;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.WEJHEROWO_GM;
        }

        private void Rumia_Reda_Wejherowo_Checked(object sender, RoutedEventArgs e)
        {
            Sopot.IsChecked = false;
            Rumia.IsChecked = false;
            Gm_Kosakowo.IsChecked = false;
            Gm_Zukowo.IsChecked = false;
            Gm_Szemud.IsChecked = false;
            Gm_Wejherowo.IsChecked = false;
            Rumia_Reda_Wejherowo.IsChecked = true;
            Gm_wejherowo_Rumia.IsChecked = false;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.RUMA_REDA_WEJHEROWO;
        }

        private void Gm_wejherowo_Rumia_Checked(object sender, RoutedEventArgs e)
        {
            Sopot.IsChecked = false;
            Rumia.IsChecked = false;
            Gm_Kosakowo.IsChecked = false;
            Gm_Zukowo.IsChecked = false;
            Gm_Szemud.IsChecked = false;
            Gm_Wejherowo.IsChecked = false;
            Rumia_Reda_Wejherowo.IsChecked = false;
            Gm_wejherowo_Rumia.IsChecked = true;
            bilet_okresowy.obszar_Waznosci = obszar_waznosci.RUMIA_WEJHEROWO_GM;
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.okres_Biletu = okres_biletu.BRAK;
            this.Close();
        }
    }
}

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
    /// Interaction logic for SymulatoPlatnosciWindow.xaml
    /// </summary>
    public partial class SymulatoPlatnosciWindow : Window
    {
        public event Action<bool> zaplacono;
        public event Action<bool> zaplacono_karta;
        public event Action<double> zaplacona_kwota;

        public SymulatoPlatnosciWindow()
        {
            InitializeComponent();
        }

        private void Karta_radiobutton_Checked(object sender, RoutedEventArgs e)
        {
            Gotowka_radiobutton.IsChecked = false;
            kwota.Visibility = System.Windows.Visibility.Hidden;
            kwota_napis.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Gotowka_radiobutton_Checked(object sender, RoutedEventArgs e)
        {
            Karta_radiobutton.IsChecked = false;
            kwota.Visibility = System.Windows.Visibility.Visible;
            kwota_napis.Visibility = System.Windows.Visibility.Visible;

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool) Karta_radiobutton.IsChecked)
                zaplacona_kwota(-1.0);
            else
            {
                try
                {
                    zaplacona_kwota(Double.Parse(kwota.Text));
                }
                catch (Exception)
                {

                    zaplacona_kwota(0.0);
                }
            }
            if ((bool)Karta_radiobutton.IsChecked)
                zaplacono_karta(true);
            else
                zaplacono_karta(false);
            zaplacono(true);
            this.Close();
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            zaplacono(false);
            this.Close();
        }
    }
}

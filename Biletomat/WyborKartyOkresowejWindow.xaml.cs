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
    /// Interaction logic for WyborKartyOkresowejWindow.xaml
    /// </summary>
    public partial class WyborKartyOkresowejWindow : Window
    {
        public WyborKartyOkresowejWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool) legitymacja_radiobutton.IsChecked)
            {
                bilet_okresowy.wlozony_Bilet_Okresowy = wlozony_bilet_okresowy.LEGITYMACJA_STUDENCKA;
                
            }
            else
            {
                bilet_okresowy.wlozony_Bilet_Okresowy = wlozony_bilet_okresowy.KARTA_MIEJSKA;
            }
            this.Close();
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.wlozony_Bilet_Okresowy = wlozony_bilet_okresowy.BRAK;
            this.Close();
        }

        
    }
}

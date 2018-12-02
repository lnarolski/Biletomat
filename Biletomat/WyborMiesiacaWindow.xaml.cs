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
    /// Interaction logic for WyborMiesiacaWindow.xaml
    /// </summary>
    public partial class WyborMiesiacaWindow : Window
    {
        DateTime aktualny_miesiac = DateTime.Now;
        DateTime przyszly_miesiac = DateTime.Now;

        public WyborMiesiacaWindow()
        {
            InitializeComponent();

            AktualnyMiesiac.Content = aktualny_miesiac.ToString("MMMM yyyy");
            przyszly_miesiac = aktualny_miesiac.AddMonths(1);
            PrzyszlyMiesiac.Content = przyszly_miesiac.ToString("MMMM yyyy");
        }

        private void AktualnyMiesiac_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.wybrany_miesiac = aktualny_miesiac.ToString("MMMM yyyy");
            this.Close();
        }

        private void PrzyszlyMiesiac_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.wybrany_miesiac = przyszly_miesiac.ToString("MMMM yyyy");
            this.Close();
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            bilet_okresowy.wybrany_miesiac = "";
            this.Close();
        }
    }
}

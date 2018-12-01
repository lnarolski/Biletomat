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

namespace Biletomat
{
    /// <summary>
    /// Interaction logic for LegitymacjaWyborBiletuOkresowegoWindow.xaml
    /// </summary>
    public partial class LegitymacjaWyborBiletuOkresowegoWindow : Window
    {
        public LegitymacjaWyborBiletuOkresowegoWindow()
        {
            InitializeComponent();
        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KupButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pomocGlosowa_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

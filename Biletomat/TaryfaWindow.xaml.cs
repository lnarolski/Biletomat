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
    /// Interaction logic for TaryfaWindow.xaml
    /// </summary>
    public partial class TaryfaWindow : Window
    {
        public TaryfaWindow()
        {
            InitializeComponent();
        }

        private void WsteczButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void taryfaZKMButton_Click(object sender, RoutedEventArgs e)
        {
            taryfa_zkm okno = new taryfa_zkm();
            okno.Show();
        }

        private void taryfaMZKGButton_Click(object sender, RoutedEventArgs e)
        {
            taryfa_mzkg okno = new taryfa_mzkg();
            okno.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biletomat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Timer zegar;

        public MainWindow()
        {
            InitializeComponent();
            czas.Text = DateTime.Now.ToString();

            zegar = new Timer(1000);
            zegar.Elapsed += zegar_tick;
            zegar.Start();
        }

        private void zegar_tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { czas.Text = DateTime.Now.ToString(); }));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
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
        private CultureInfo culture_info;

        public MainWindow()
        {
            InitializeComponent();
            culture_info = new CultureInfo("pl-PL");
            czas.Text = culture_info.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek) + ", " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss");

            zegar = new Timer(1000);
            zegar.Elapsed += zegar_tick;
            zegar.Start();

            //SpeechSynthesizer reader = new SpeechSynthesizer();
        }

        private void zegar_tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { czas.Text = culture_info.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek) + ", " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss"); }));
        }

        private void biletJednorazowyButton_Click(object sender, RoutedEventArgs e)
        {
            BiletJednorazowyWindow okno = new BiletJednorazowyWindow();
            okno.Show();
        }

        private void biletJednorazowyMetropolitalnyButton_Click(object sender, RoutedEventArgs e)
        {
            BiletJednorazowyMetropolitalny okno = new BiletJednorazowyMetropolitalny();
            okno.Show();
        }

        private void taryfaButton_Click(object sender, RoutedEventArgs e)
        {
            TaryfaWindow okno = new TaryfaWindow();
            okno.Show();
        }
    }
}

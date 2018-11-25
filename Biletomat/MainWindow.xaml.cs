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
using System.Speech.Synthesis;
using definicje_zmiennych;


namespace Biletomat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Timer zegar;
        private CultureInfo culture_info;
        private SpeechSynthesizer reader;

        public MainWindow()
        {
            InitializeComponent();
            culture_info = new CultureInfo("pl-PL");
            czas.Text = culture_info.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek) + ", " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss");

            zegar = new Timer(1000);
            zegar.Elapsed += zegar_tick;
            zegar.Start();

            reader = new SpeechSynthesizer();
            var voices = reader.GetInstalledVoices(culture_info);
            reader.SelectVoice(voices[0].VoiceInfo.Name);
            
            status_biletomatu.wyczysc();
            status_biletomatu.powitanie = false;
        }

        private void zegar_tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { czas.Text = culture_info.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek) + ", " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss"); }));
        }

        private void biletJednorazowyButton_Click(object sender, RoutedEventArgs e)
        {
            BiletJednorazowyWindow okno = new BiletJednorazowyWindow();
            okno.Closed += new EventHandler(Zamkniecie_okna_biletJednorazowy);
            okno.Show();
        }

        private void Zamkniecie_okna_biletJednorazowy(object sender, EventArgs e)
        {
            if (status_biletomatu.rodzaj_platnosci == wybrana_platnosc.BRAK)
                status_biletomatu.wyczysc(); //GDZIEŚ JEST NADPISYWANA WARTOŚĆ status_biletomatu.status_zakupu -> Znaleźć w przyszłości
            if (status_biletomatu.status_zakupu == status.WYDRUKOWANO_BILETY)
            {
                KomunikatWindow okno = new KomunikatWindow();
                okno.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                okno.Owner = Window.GetWindow(this);
                okno.ShowDialog();
            }
            status_biletomatu.powitanie = false;
        }

        private void biletJednorazowyMetropolitalnyButton_Click(object sender, RoutedEventArgs e)
        {
            BiletJednorazowyMetropolitalny okno = new BiletJednorazowyMetropolitalny();
            okno.Closed += new EventHandler(Zamkniecie_okna_biletJednorazowy);
            okno.Show();
        }

        private void taryfaButton_Click(object sender, RoutedEventArgs e)
        {
            TaryfaWindow okno = new TaryfaWindow();
            okno.Show();
        }

        private void pomocGlosowa_Click(object sender, RoutedEventArgs e)
        {
            if (!status_biletomatu.powitanie)
                reader.SpeakAsync("WItaj w biletomacie ZKM Gdynia.");
            reader.SpeakAsync("Zaraz opowiem o opcjach. BLABLABLA");
        }

        private void biletOkresowyButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

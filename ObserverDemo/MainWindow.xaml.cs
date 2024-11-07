using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObserverDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Weather weather = new Weather();
        CurrentTempWindow CurrentTempWindow = new CurrentTempWindow();
        AvergeTemperature AvergeTemperature = new AvergeTemperature();

        public MainWindow()
        {
            InitializeComponent();
            CurrentTempWindow.Show();
            AvergeTemperature.Show();

            weather.AddObserver(CurrentTempWindow);
            weather.AddObserver(AvergeTemperature);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            weather.GenerateTem();
        }
        private void Tap_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("а вот зачем нажимать? сказали, и сделал? а скажут с крыши прыгнуть, ты прыгнешь?");
        }
    }
}
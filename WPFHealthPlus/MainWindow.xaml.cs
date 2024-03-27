using System.Windows;
using System.Windows.Controls;

namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame mainframe = null;
        public MainWindow()
        {
            InitializeComponent();
            mainframe = MainFrame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainButtonLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainButtonRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
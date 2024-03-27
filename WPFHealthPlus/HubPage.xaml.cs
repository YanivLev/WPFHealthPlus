using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for HubPage.xaml
    /// </summary>
    public partial class HubPage : Page
    {

        public HubPage()
        {
            InitializeComponent();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new PersonalSettingsPage(LoginPage.userToSend));

        }

        private void DiaryBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new DiaryPage());
        }

        private void MoreBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new MorePage());
        }
    }
}

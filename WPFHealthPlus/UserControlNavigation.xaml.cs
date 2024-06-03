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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for UserControlNavigation.xaml
    /// </summary>
    public partial class UserControlNavigation : UserControl
    {
        public UserControlNavigation()
        {
            InitializeComponent();
            if (LoginPage.userDataToSend.IsManager)
            {
                AllUserList.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new HubPage());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage());
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new PersonalSettingsPage());
        }

        private void UserList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new ManagerUserPreview());
        }
    }
}

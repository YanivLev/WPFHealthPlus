using HealthPlusApiService;
using Model;
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
    /// Interaction logic for ManagerUserPreview.xaml
    /// </summary>
    public partial class ManagerUserPreview : Page
    {
        List<User> userlist = new List<User>();
        public ManagerUserPreview()
        {
            InitializeComponent();
            FillListView();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        public async void FillListView()
        {
            ApiService api = new ApiService();
            userlist = await api.GetUserList();
            uLView.ItemsSource = userlist;
        }
        private void MakeManager_Click(object sender, RoutedEventArgs e)
        {
            ApiService api = new ApiService();
            User user = uLView.SelectedItem as User;
            if(user.IsManager)
            {
                user.IsManager = false;
                api.UpdateUser(user);
                MessageBox.Show("You unmade "+user.Username+" as a manager");
            }
            else
            {
                user.IsManager = true;
                api.UpdateUser(user);
                MessageBox.Show("You made " + user.Username + " a manager");
            }
           
           

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private async void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            ApiService api = new ApiService();
            User user = uLView.SelectedItem as User;
            //UserDataList udl = await api.GetUserDataList();
            //UserData ud = udl.Find(item => item.Id.ToString() == user.Id.ToString());
            //if (ud != null)
            //    api.DeleteUser(ud);
            MessageBox.Show("You removed "+user.Username+" Successfully");
            await api.DeleteUser(user);
           
            uLView.SelectedItem = null;

        }
    }
}

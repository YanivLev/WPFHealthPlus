using HealthPlusApiService;
using Model;
using System.Windows;
using System.Windows.Controls;

namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static UserData userToSend = null;

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ApiService services = new ApiService();
            var userList = await services.GetUserList();
            string username = UsernameTextBox.Text.ToString();
            string gmail = GmailTextBox.Text.ToString();
            User user = new User();
            user = userList.Find(item => item.Username == username && item.Gmail == gmail);
            int idcheck = user.Id;
            UserData userdata = new UserData();
            var userdataList = await services.GetUserDataList();
            userdata = userdataList.Find(item => item.Id == idcheck);
            if (user == null)
            {
                MessageBox.Show("There is no such user");
            }
            userToSend = userdata;
            MessageBox.Show("Successfully logged in");
            MainWindow.mainframe.Navigate(new HubPage());


        }
        //private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ApiService services = new ApiService();
        //    var userList = await services.GetUserList();
        //    string username = UsernameTextBox.Text.ToString();
        //    string gmail = GmailTextBox.Text.ToString();
        //    User user = new User();
        //    user = userList.Find(item => item.Username == username && item.Gmail == gmail);
        //    if (user == null)
        //    {
        //        MessageBox.Show("There is no such user");
        //        return;
        //    }
        //    userToSend = user;
        //    MessageBox.Show("Successfully logged in");

        //string to, from, pass, mail;
        //to = GmailTextBox.Text;
        //from = "";//Your gmail goes here
        //mail =  
    }





    //private void SendButton_Click(object sender, RoutedEventArgs e)
    //{
    //    string o
    //}

}

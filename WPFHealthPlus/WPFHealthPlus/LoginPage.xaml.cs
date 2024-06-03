using HealthPlusApiService;
using Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;

namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        //יצירת משתנה סטטי שמקבל את נתוני המשתמש, ניתן יהיה להשתמש בפרטים אלו בדפים אחרים
        public static UserData userDataToSend { get; set;}
        
        //הפעולה נקראת בעת יצירת מופע חדש של דף ההתחברות
        //בתוך פעולה זו מתבצעת הגדרת תכונות והשמה של ערכים
        public LoginPage()
        {
            InitializeComponent();
            UsernameTextBox.Text = "Itay Zadaka";
            GmailTextBox.Text = "itayzadaka@gmail.com";
        }

        //הפעולה מחפשת משתמש מסוים לפי שם משתמש ודוא"ל מתוך רשימת המשתמשים
        //באמצעות קריאה לאיי-פי-איי
        //הפעולה מבצעת קריאה א-סינכרונית לאיי-פי-איי כדי לקבל את רשימת המשתמשים
        public async Task<UserData> SpecificUser(string username, string gmail)
        {
            HealthPlusApiService.ApiService apiService = new HealthPlusApiService.ApiService();
            var userList = await apiService.GetUserDataList();
            return userList.Find(x => x.Username == username && x.Gmail == gmail);
        }

        //הפונקציה מאמתת את פרטי המשתמש ומנווטת לדף המרכזי במקרה של הצלחה, ומציגה הודעת שגיאה במקרה של כשלון או שגיאה
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = UsernameTextBox.Text;
                string gmail = GmailTextBox.Text;
                UserData user = await SpecificUser(username, gmail);
                if(user==null)
                {
                    MessageBox.Show("Invalid Username or Gmail. Please Try Again!", "Login Failed");
                    return;
                }
                userDataToSend = user;
                ApiService api = new ApiService();

                NavigationService.Navigate(new HubPage());  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

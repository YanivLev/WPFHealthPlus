using HealthPlusApiService;
using Model;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private HttpClient client;
        private readonly Regex phoneregex = new Regex(@"05\d{8}$");
        private readonly Regex usernameregex = new Regex(@"^[a-zA-Z ]{3,20}$");
        private readonly Regex gmailregex = new Regex(@"^[a-zA-Z0-9._%+-]+@gmail\.com$");
        public RegisterPage()
        {
            InitializeComponent();
            FillBox();
            client = new();
        }


        public async Task FillBox()
        {
            ApiService service = new ApiService();
            List<Gender> genders = await service.GetGenderList() as List<Gender>;
            List<string> genderName = new List<string>();
            foreach (Gender item in genders)
            {
                genderName.Add(item.NameGender);
            }
            GenderTextBox.ItemsSource = genderName;
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!phoneregex.IsMatch(PhoneNumberTextBox.Text.ToString()))
            {
                MessageBox.Show("Phone number is not correct");
                return;
            }
            if (!usernameregex.IsMatch(UsernameTextBox.Text.ToString()))
            {
                MessageBox.Show("Username contains is not correct");
                return;
            }
            if (!gmailregex.IsMatch(GmailTextBox.Text.ToString()))
            {
                MessageBox.Show("Gmail is not correct");
                return;
            }
            ApiService s = new ApiService();
            User u = new User();
            GenderList g = await s.GetGenderList();
            u.Username = UsernameTextBox.Text.ToString();
            u.Phone = PhoneNumberTextBox.Text.ToString();
            u.Gmail = GmailTextBox.Text.ToString();
            u.Gender = g.Find(item => item.NameGender == GenderTextBox.SelectedItem.ToString());
            u.IsManager = false;
            await s.InsertUser(u);
            //            client.PostAsJsonAsync($"https://gmail.googleapis.com/upload/gmail/v1/users/{GmailTextBox.Text}/messages/send", new
            //            {
            //                id= "",
            //                "threadId": string,
            //                "labelIds": [
            //    string
            //  ],
            //                "snippet": string,
            //                "historyId": string,
            //                "internalDate": string,
            //                "payload": {
            //                object(MessagePart)
            //                },
            //  "sizeEstimate": integer,
            //  "raw": string
            //});
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage());

        }
    }
}

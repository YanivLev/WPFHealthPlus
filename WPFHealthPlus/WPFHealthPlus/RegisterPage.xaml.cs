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
        //יצירת מופע של פרוטוקול תקשורת והגדרת ביטויים רגולריים לבדיקת תקינות של מספר טלפון, שם משתמש וגימייל
        private HttpClient client;
        private readonly Regex phoneregex = new Regex(@"05\d{8}$");
        private readonly Regex usernameregex = new Regex(@"^[a-zA-Z ]{3,20}$");
        private readonly Regex gmailregex = new Regex(@"^[a-zA-Z0-9._%+-]+@gmail\.com$");
        
        //אתחול דף הרישום, קריאה לפונקציה שממלאת את אחד השדות
        public RegisterPage()
        {
            InitializeComponent();
            FillBox();
            client = new();
        }

        //הםעולה מאחזרת רשימת מגדרים מהשרת באמצעות האיי-פי-איי
        //ומוציאה את שמות המגדרים מהרשימה ומגדירה אותם כמקור הפריטים עבור השדה המתאים
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

        //הפעולה מאמתת את הנתונים שהמשתמש הזין בטקסטבוקסים באמצעות רג'קס
        //אם אחד הנתונים אינו תקין מוצגת הודעת שגיאה ומפסיקים את הפעולה. 
        //אם כל הנתונים תקינים היא יוצרת אובייקט של משתמש חדש עם המידע שהוזן
        //ומבצעת קריאה לשירות איי-פי-איי כדי להוסיף את המשתמש החדש
        //לאחר ההוספה, היא מנווטת לעמוד ההתחברות
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
            UserData ud = new UserData();
            GenderList g = await s.GetGenderList();
            ud.Username = UsernameTextBox.Text.ToString();
            ud.Phone = PhoneNumberTextBox.Text.ToString();
            ud.Gmail = GmailTextBox.Text.ToString();
            ud.Gender = g.Find(item => item.NameGender == GenderTextBox.SelectedItem.ToString());
            ud.IsManager = false;
            ud.Weight = 0;
            ud.Height = 0;
            ud.Birthdate = DateTime.Now;
            ud.Caloriegoal = 0;
            ud.Weightgoal = 0;
            await s.InsertUserData(ud);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LoginPage());
            
           



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
        }
    }
}

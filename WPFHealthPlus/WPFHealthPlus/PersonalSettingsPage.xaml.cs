using Model;
using System.Windows;
using System.Windows.Controls;
using HealthPlusApiService;
namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for PersonalSettingsPage.xaml
    /// </summary>
    public partial class PersonalSettingsPage : Page
    {
        //הגדרת משתנה פרטי למחלקה
        private UserData user;
        //הגדרת רשימה של נתוני-משתמשים
        UserDataList userdataList = new UserDataList();

        //הפעולה מגדירה בנאי עבור מחלקת הדף
        //הבנאי מקבל אובייקט מסוג נתוני-משתמש ומבצע אתחול של הריכיבים המוגדרים בדף
        //ואז מפיל את הפעולה "קבל נתונים" על מנת לטעון נתונים לדף
        public PersonalSettingsPage()
        {
            InitializeComponent();
            GetData();
            //FillBox();
            
        }
        //public async Task FillBox()
        //{
        //    ApiService service = new ApiService();
        //    List<Gender> genders = await service.GetGenderList() as List<Gender>;
        //    List<string> genderName = new List<string>();
        //    foreach (Gender item in genders)
        //    {
        //        genderName.Add(item.NameGender);
        //    }
        //    GenderTextBox.ItemsSource = genderName;
        //}

        //הפעולה "קבל נתונים" משתמשת בשירות האיי-פי-איי כדי לקבל את נתוני המשתמש
        public async Task GetData()
        {
           
            userName.Text = LoginPage.userDataToSend.Username;
            userPhone.Text = LoginPage.userDataToSend.Phone;
            userGmail.Text = LoginPage.userDataToSend.Gmail;
            GenderTextBox.Text = LoginPage.userDataToSend.Gender.NameGender;
           

            
            //userHeight.Text = (LoginPage.userToSend.Height).ToString();
            //userWeight.Text = (LoginPage.userToSend.Weight).ToString();
            //userBirthdate.Text = (LoginPage.userToSend.Birthdate.ToString();
        }

        //הפעולה מתבצעת כאשר המשתמש לוחץ על כפתור העדכון בדף ההגדרות האישיות
        // בעת לחיצה היא משנה את נתוני המשתמש בהתאם לערכים שהוזנו בשדות הקלט בדף
        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {   
            ApiService api = new ApiService();
            GenderList g = await api.GetGenderList();
            LoginPage.userDataToSend.Username = userName.Text.ToString();
            LoginPage.userDataToSend.Phone = userPhone.Text.ToString();
            LoginPage.userDataToSend.Gmail = userGmail.Text.ToString();
            LoginPage.userDataToSend.Gender = g.Find(item=>item.NameGender==GenderTextBox.Text);
            if(LoginPage.userDataToSend.IsManager)
            {
                LoginPage.userDataToSend.IsManager = true;
            }
            else
            {
                LoginPage.userDataToSend.IsManager = false;
            }
            MessageBox.Show("You updated your personal info Successfully");
            await api.UpdateUser(LoginPage.userDataToSend);
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}



        //private void updateMe(object sender, RoutedEventArgs e)
        //{
        //    ApiService.update(User)
        //}
    }
}

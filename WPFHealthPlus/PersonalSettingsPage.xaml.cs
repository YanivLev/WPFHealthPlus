using Model;
using System.Windows;
using System.Windows.Controls;

namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for PersonalSettingsPage.xaml
    /// </summary>
    public partial class PersonalSettingsPage : Page
    {

        private UserData user;
        UserDataList userdataList = new UserDataList();
        public PersonalSettingsPage(UserData userdata)
        {
            InitializeComponent();
            GetData(userdata);
            this.user = userdata;
        }

        public async Task GetData(UserData userdata)
        {
            HealthPlusApiService.ApiService api = new HealthPlusApiService.ApiService();
            this.userName.Text = userdata.Username;
            this.userPhone.Text = userdata.Phone;
            this.userGmail.Text = userdata.Gmail;
            this.userGender.Text = userdata.Gender.NameGender;
            this.userHeight.Text = userdata.Height.ToString();
            this.userWeight.Text = userdata.Weight.ToString();
            this.userBirthdate.Text = userdata.Birthdate.ToString();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //HealthPlusApiService.ApiService api = new HealthPlusApiService.ApiService();
            //PersonalSettingsPage.chosenUser.Username = userName.Text.ToString();
            //PersonalSettingsPage.chosenUser.Gmail = userGmail.Text.ToString();
            //PersonalSettingsPage.chosenUser.Phone = userPhone.Text.ToString();
            //PersonalSettingsPage.chosenUser.Gender.NameGender = userGender.Text.ToString();
            //PersonalSettingsPage.chosenUser.Weight = int.Parse(userWeight.Text.ToString());
            //PersonalSettingsPage.chosenUser.Height = int.Parse(userHeight.Text.ToString());
            //PersonalSettingsPage.chosenUser.IsManager = false;
            //PersonalSettingsPage.chosenUser.Birthdate = DateTime.Parse(userBirthdate.Text.ToString());
            //api.UpdateUserData(PersonalSettingsPage.chosenUser);

            HealthPlusApiService.ApiService api = new HealthPlusApiService.ApiService();
            user.Username = this.userName.Text.ToString();
            user.Phone = this.userPhone.Text.ToString();
            user.Gmail = this.userGmail.Text.ToString();
            user.Gender.NameGender = this.userGender.Text.ToString();
            user.Height = int.Parse(this.userHeight.Text.ToString());
            user.Weight = int.Parse(this.userWeight.Text.ToString());
            user.Birthdate = DateTime.Parse(this.userBirthdate.Text.ToString());
            user.IsManager = false;
            api.UpdateUserData(user);
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

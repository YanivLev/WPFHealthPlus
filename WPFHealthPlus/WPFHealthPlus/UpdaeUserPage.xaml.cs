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
    /// Interaction logic for UpdaeUserPage.xaml
    /// </summary>
    public partial class UpdaeUserPage : Page
    {
        public UpdaeUserPage()
        {
            InitializeComponent();
            GetData();
        }
        public async Task GetData()
        {

            HeightTextBox.Text = LoginPage.userDataToSend.Height.ToString();
            WeightTextBox.Text = LoginPage.userDataToSend.Weight.ToString();
            DatePicker.Text = LoginPage.userDataToSend.Birthdate.ToString();

        }
        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ApiService api = new ApiService();
            LoginPage.userDataToSend.Height = int.Parse(HeightTextBox.Text.ToString());
            LoginPage.userDataToSend.Weight = int.Parse(WeightTextBox.Text.ToString());
            LoginPage.userDataToSend.Birthdate = DateTime.Parse(DatePicker.ToString());

            if(LoginPage.userDataToSend.Birthdate>DateTime.Now)
            {
                MessageBox.Show("Birthdate is not correct");
                return;
            }

            if (LoginPage.userDataToSend.Height < 130)
            {
                MessageBox.Show("Your Height is not correct");
                return;
            }

            if (LoginPage.userDataToSend.Weight < 30)
            {
                MessageBox.Show("Weight is not correct");
                return;
            }

            MessageBox.Show("You updated your data Successfully");
            await api.UpdateUserData(LoginPage.userDataToSend);
        }
    }
}

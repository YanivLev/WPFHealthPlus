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
    /// Interaction logic for GoalPage.xaml
    /// </summary>
    public partial class GoalPage : Page
    {
       
        public GoalPage()
        {
            InitializeComponent();
            GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public async Task GetData()
        {

            caloriegoal.Text = LoginPage.userDataToSend.Caloriegoal.ToString();
            weightgoal.Text = LoginPage.userDataToSend.Weightgoal.ToString();

        }

        private async void GoalUpdateButton(object sender, RoutedEventArgs e)
        {
            ApiService api = new ApiService();
            LoginPage.userDataToSend.Caloriegoal = int.Parse(caloriegoal.Text.ToString());
            LoginPage.userDataToSend.Weightgoal = int.Parse(weightgoal.Text.ToString());
            if (LoginPage.userDataToSend.Caloriegoal < 0)
            {
                MessageBox.Show("Your Calorie goal is not correct");
                return;
            }
            if (LoginPage.userDataToSend.Weightgoal < 0)
            {
                MessageBox.Show("Your Weight goal is not correct");
                return;
            }
            MessageBox.Show("You Updated your goals Successfully");
            await api.UpdateUserData(LoginPage.userDataToSend);
        }


    }
}

using Model;
using System.Windows;
using System.Windows.Controls;


namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for DiaryPage.xaml
    /// </summary>
    public partial class DiaryPage : Page
    {
        private Meal meal;
        MealList mealList = new MealList();
        public DiaryPage()
        {
            InitializeComponent();
            //GetData(mealex);
            //this.meal = mealex;
        }

        public async Task GetData(Meal meal)
        {
            //HealthPlusApiService.ApiService api = new HealthPlusApiService.ApiService();
            //this.meal.Text = meal.Mealdate.ToString();
            //this.mealFood.Text = meal.Food.Foodname;
            //this.mealName.Text = meal.Mealname.Mealname;
            //this.foodAmount.Text = meal.Amount.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchFood_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

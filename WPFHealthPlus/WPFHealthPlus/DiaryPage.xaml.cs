using HealthPlusApiService;
using Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for DiaryPage.xaml
    /// </summary>
    public partial class DiaryPage : Page
    {
        //הגדרת משתנה פרטי של ארוחה
        private Meal meal;

        //הגדרת רשימת ארוחות
        List<Meal> meallist = new List<Meal>();

        //אתחול הדף
        public DiaryPage()
        {
            InitializeComponent();
            //GetData(mealex);
            //this.meal = mealex;
            FillListView();
        }

        //הפעולה מציגה את רשימת הארוחות של המשתמש בתוך ממשק המשתמש. היא משתמש בשירות האיי-פי-איי כדי לקבל את הארוחות מהשרת
        public async void FillListView()
        {
            //Make it to show only the meal data of the user

            ApiService api = new ApiService();
            meallist = await api.GetMealList();
            List<Meal> mealsperuser = meallist.Where(x=> x.User.Id == LoginPage.userDataToSend.Id).ToList();
            umLView.ItemsSource = mealsperuser;

            //Add the sum of the Calories on this specific meal..
        }

        public async Task GetData(Meal meal)
        {
            //HealthPlusApiService.ApiService api = new HealthPlusApiService.ApiService();
            //this.meal.Text = meal.Mealdate.ToString();
            //this.mealFood.Text = meal.Food.Foodname;
            //this.mealName.Text = meal.Mealname.Mealname;
            //this.foodAmount.Text = meal.Amount.ToString();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new HubPage());
        }
    }
}

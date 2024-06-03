using HealthPlusApiService;
using Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for MorePage.xaml
    /// </summary>
    public partial class MorePage : Page
    {
        //רשימת נתוני אוכל
        List<FoodData> foodlist = new List<FoodData>();

        //אתחול הדף והפעלת הפעולה שממלאת את הרשימה
        public MorePage()
        {
            InitializeComponent();
            FillListView();
            if (LoginPage.userDataToSend.IsManager)
            {
                AddFoodManager.Visibility = System.Windows.Visibility.Visible;
            }
        }

        //הפעולה ממלאת את רשימת התצוגה של המאכלים בממשק המשתמש. היא מבצעת קריאה א-סינכרונית לאיי-פי-איי כדי לקבל את רשימת המאכלים מהשרת
        public async void FillListView()
        {
            ApiService api = new ApiService();
            foodlist = await api.GetFoodDataList();
            fLView.ItemsSource = foodlist;
        }

        //הפעולה מופעלת כאשר המשתמש לוחץ על כפתור או פקד שמיועד להוספת מאכל לארוחה
        private void AddFoodToMeal(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.mainframe.Navigate(new MealAddPage());
        }

        //הפעולה מופעלת כאשר המשתמש משנה את התוכן של שדה החיפוש בממשק המשתמש. רק המאכלים ששמותיהם מתחילים עם מילות המפתח יופיעו
        private void SearchFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = SearchFilter.Text.ToLower();

            var list = foodlist.Where(x => x.Foodname.ToLower().StartsWith(keyword)).ToList();
            fLView.ItemsSource = list;
        }

        private void AddFoodManager_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new ManagerAddFood());

        }
    }
}

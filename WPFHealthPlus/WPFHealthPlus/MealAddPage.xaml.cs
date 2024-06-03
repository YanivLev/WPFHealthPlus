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
    /// Interaction logic for MealAddPage.xaml
    /// </summary>
    public partial class MealAddPage : Page
    {
        //אתחול הדף והפעלת פעולה שממלאת את השדות המתאימים
        public MealAddPage()
        {
            InitializeComponent();
            FillBox();
            
        }

        //הפעולה מבצעת מילוי בממשק המשתמש היא משתמשת בשירות האיי-פי-איי כדי לקבל את רשימת שמות הארוחות והמאכלים מהשרת
        public async Task FillBox()
        {
            ApiService service = new ApiService();
            List<MealName> mealnames = await service.GetMealNameList() as List<MealName>;
            List<string> mealName = new List<string>();
            foreach (MealName item in mealnames)
            {
                mealName.Add(item.Mealname);
            }
            MealTypeComboBox.ItemsSource = mealName;


            List<Food> foodnames = await service.GetFoodList() as List<Food>;
            List<string> foodName = new List<string>();
            foreach (Food item in foodnames)
            {
                foodName.Add(item.Foodname);
            }
            FoodComboBox.ItemsSource = foodName;
        }

        //הפעולה מתבצעת כאשר המשתמש לוחץ כפתור ההוספה, היא יוצרת מופע של השירות איי-פי-איי
        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(DatePicker.SelectedDate>DateTime.Now)
            {
                MessageBox.Show("You Picked wrong date");
            }

            ApiService s = new ApiService();
            Meal m = new Meal();
            MealNameList mnl = await s.GetMealNameList();
            m.User = LoginPage.userDataToSend;
            m.Mealdate = DateTime.Parse(DatePicker.ToString());
            FoodList fl = await s.GetFoodList();
            m.Amount = int.Parse(AmountTextBox.Text.ToString());
            m.Food = fl.Find(item => item.Foodname == FoodComboBox.SelectedItem.ToString());
            m.Mealname = mnl.Find(item => item.Mealname == MealTypeComboBox.SelectedItem.ToString());
            await s.InsertMeal(m);
            MessageBox.Show("You added a meal Successfully");
            NavigationService.Navigate(new MorePage());
        }

        
    }
}
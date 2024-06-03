using System;
using System.Collections.Generic;
using System.Globalization;
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
using HealthPlusApiService;
using Microsoft.VisualBasic;
using Model;
using ViewModel;

namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for SumCalsPerDay.xaml
    /// </summary>
    public partial class SumCalsPerDay : Page
    {


        public async void SumCaloriesPerDay()
        {
            ApiService apiService = new ApiService();
            List<FoodData> fooddataList = await apiService.GetFoodDataList();
            List<Meal> mealList = await apiService.GetMealList();
            List<Meal> mealsperuser = mealList.Where(x => x.User.Id == LoginPage.userDataToSend.Id).ToList();
            List<SumCalories> sum = new List<SumCalories>();
            
            foreach (Meal meal in mealsperuser)
            {
                sum.Add(new SumCalories { MealDate = meal.Mealdate, MealCalories = fooddataList.Where(x => meal.Food.Id == x.Id).Sum(x => x.Calories*meal.Amount)});
            }

            sumLView.ItemsSource = null; sumLView.ItemsSource = sum; 
        }
        public SumCalsPerDay()
        {
            InitializeComponent();
            SumCaloriesPerDay();
        }

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show((sumLView.SelectedItem as SumCalories)?.MealCalories.ToString());
        //}
    }
    public class SumCalories
    {
        public DateTime MealDate { get; set; }
       public double MealCalories { get; set; }

        
    }
   
}

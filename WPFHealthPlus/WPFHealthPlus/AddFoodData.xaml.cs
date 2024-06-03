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
    /// Interaction logic for AddFoodData.xaml
    /// </summary>
    public partial class AddFoodData : Page
    {
        public AddFoodData()
        {
            InitializeComponent();
            FillBox();
        }
        public async Task FillBox()
        {
            ApiService service = new ApiService();
            List<Food> foodlist = await service.GetFoodList();
            List<string> foodname = new List<string>();
            foreach (Food item in foodlist)
            {
                foodname.Add(item.Foodname);
            }
            FoodIdComboBox.ItemsSource = foodname;

        }
            private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ApiService s = new ApiService();
            FoodData fd = new FoodData();
            FoodList fl = await s.GetFoodList();
            Food f = fl.Find(item => item.Foodname == FoodIdComboBox.Text.ToString());
            fd.Id = f.Id;
            fd.Foodname = f.Foodname;
            fd.Servingtype = f.Servingtype;
            fd.Calories = int.Parse(CaloriesTextBox.Text.ToString());
            fd.Protein = int.Parse(ProteinTextBox.Text.ToString());
            fd.Carbs = int.Parse(CarbsTextBox.Text.ToString());
            fd.Fibers = int.Parse(FibersTextBox.Text.ToString());
            fd.Fat = int.Parse(FatTextBox.Text.ToString());
            fd.Sugar = int.Parse(SugarTextBox.Text.ToString());
            fd.Cholesterol = int.Parse(CholesterolTextBox.Text.ToString());

            await s.InsertFoodData(fd);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new MorePage());
        }
    }
}

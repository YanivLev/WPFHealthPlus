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
    /// Interaction logic for ManagerAddFood.xaml
    /// </summary>
    public partial class ManagerAddFood : Page
    {
        public ManagerAddFood()
        {
            InitializeComponent();
            FillBox();
        }
        public async Task FillBox()
        {
            ApiService service = new ApiService();
            List<Serving> servinglist = await service.GetServingList();
            List<string> serving = new List<string>();
            foreach (Serving item in servinglist)
            {
                serving.Add(item.Servingtype);
            }
            ServingTypeComboBox.ItemsSource = serving;
        }

            private async void AddButton_Click(object sender, RoutedEventArgs e)
        {

            ApiService s = new ApiService();
            Food f = new Food();
            ServingList sl = await s.GetServingList();
            f.Foodname = FoodNameTextBox.Text.ToString();
            f.Servingtype = sl.Find(item => item.Servingtype == ServingTypeComboBox.SelectedItem.ToString());
            MessageBox.Show("You added a food to the database Successfully");
            await s.InsertFood(f);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AddFoodData());
        }
    }
}

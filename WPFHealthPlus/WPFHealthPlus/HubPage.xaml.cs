using Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WPFHealthPlus
{
    /// <summary>
    /// Interaction logic for HubPage.xaml
    /// </summary>
    public partial class HubPage : Page
    {
     

        //הפעולה מאתחלת את הדף על פי התצוגה שנקבעה
        public HubPage()
        {
            InitializeComponent();
          
           
        }

    


        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new UpdaeUserPage());

        }

        //הפעולה נקראת כאשר לוחצים על כפתור התפריט שמוביל לדף היומן
        private void DiaryBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new DiaryPage());
        }


        //הפעולה נקראת כאשר לוחצים על כפתור התפריט שמוביל לדף המאכלים
        private void MoreBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new MorePage());
        }

        private void SumCalorie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SumCalories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new SumCalsPerDay());
        }



        private void Goal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new GoalPage());
        }
    }
}

using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            //LoginWindow myLogWindow = new LoginWindow();
            //myLogWindow.Show();          
            Function.DateTimeToSQLTime(new System.DateTime(2019, 01, 28,00,00,00, System.DateTimeKind.Local));
            //DataAccess.SelectInBDD();
            AddSteps addSteps = new AddSteps();
            addSteps.Show();
        }

        private void AddIngre_click(object sender, RoutedEventArgs e)
        {
            AddIngredients addIngredient = new AddIngredients();
            addIngredient.Show();
        }
    }
}

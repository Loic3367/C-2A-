using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour ShowSelRecipe.xaml
    /// </summary>
    public partial class ShowSelRecipe : Window
    {
        private RecipeViewModel rvm;
        public ShowSelRecipe()
        {
            InitializeComponent();
        }
        public ShowSelRecipe(RecipeViewModel r)
        {
            rvm = r;
            this.DataContext = rvm;
            
            InitializeComponent();
            lvListIngre.ItemsSource = rvm.ListIngredients;
            lvListSteps.ItemsSource = rvm.ListSteps;
        }
    }
}

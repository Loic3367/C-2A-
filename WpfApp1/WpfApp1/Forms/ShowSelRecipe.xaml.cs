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
            InitializeComponent();
            rvm = r;
        }
    }
}

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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour AjoutRecette.xaml
    /// </summary>

    public partial class AddRecipes : Window
    {
        // Region for GetDifficulty & GetCosts
        #region
        static IReadOnlyList<Cost> GetCosts()
        {
            List<Cost> ret = new List<Cost>();
            foreach (Cout cost in Enum.GetValues(typeof(Cout)))
                ret.Add(new Cost() { valeur = cost });
            return ret;
        }
        static IReadOnlyList<Difficulty> GetDifficulty()
        {
            List<Difficulty> ret = new List<Difficulty>();
            foreach (Difficultee diff in Enum.GetValues(typeof(Difficultee)))
                ret.Add(new Difficulty() { value = diff });
            return ret;
        }

        static IReadOnlyList<Category> getCategories()
        {
            List<Category> ret = new List<Category>();
            foreach (Categorie cate in Enum.GetValues(typeof(Categorie)))
                ret.Add(new Category() { value = cate });
            return ret;
        }
        #endregion
        public AddRecipes()
        {

            InitializeComponent();
            cbDifficulte.ItemsSource = GetDifficulty();
            cbCout.ItemsSource = GetCosts();
            cbCategories.ItemsSource = getCategories();
        }

        private void ButtonAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            AddIngredient addIngredient = new AddIngredient();
            addIngredient.ShowDialog();

            UCSteps uCSteps = new UCSteps();
        }

        private void ButtonAddRecipes_Click(object sender, RoutedEventArgs e)
        {
            Recipes recipe = new Recipes();
            recipe.CookTime = Int32.Parse(CookTime.Text);
            recipe.Cost = (Cost)cbCout.SelectedItem;
            recipe.Difficulty = (Difficulty)cbDifficulte.SelectedItem;
            recipe.NbrPeople = Int32.Parse(cbNbrPers.Text);
            recipe.Categorie = (Category)cbCategories.SelectedItem;
            
            
            AddSteps newListSteps = new AddSteps(recipe);
            this.Close();
            newListSteps.ShowDialog();
        }
    }
}

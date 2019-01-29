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
        #endregion
        public AddRecipes()
        {

            InitializeComponent();
            cbDifficulte.ItemsSource = GetDifficulty();
            cbCout.ItemsSource = GetCosts();
        }

        private void ButtonAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            AddIngredient addIngredient = new AddIngredient();
            addIngredient.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UCIngredients.xaml
    /// </summary>
    public partial class UCIngredients : System.Windows.Controls.UserControl
    {
        
        Recipes rcp = new Recipes();
        
        public UCIngredients()
        {
            InitializeComponent();
            List<Ingredient> listIngre = DataAccess.Dal.SelectAllIngredients();
            cbIngreSel.ItemsSource = listIngre;
        }

        public UCIngredients(Recipes recipes)
        {
            InitializeComponent();
            List<Ingredient> listIngre = DataAccess.Dal.SelectAllIngredients();
            cbIngreSel.ItemsSource = listIngre;
            rcp = recipes;
            
        }
    }
}

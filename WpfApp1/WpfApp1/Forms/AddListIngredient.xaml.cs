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
    /// Logique d'interaction pour AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        Recipes rcp = new Recipes();
        public AddIngredient(Recipes recipe)
        {
            InitializeComponent();        
            rcp = recipe;
          
           // UCIngredients uCIngredients = new UCIngredients(rcp);
        }
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string IngreName = cbSelIngre.Text;
            List<string> testList = new List<string>();
            foreach(UCIngredients item in pnl1.Children)
            {
                string test = item.cbIngreSel.SelectedItem.ToString();
                testList.Add(test);
            }
        }

        private void AddListIngre_Click(object sender, RoutedEventArgs e)
        {
            UCIngredients uCIngredients = new UCIngredients();         
            Size size = uCIngredients.RenderSize;
            pnl1.Children.Add(uCIngredients);
            pnl1.RenderSize = size;
        }
    }
}

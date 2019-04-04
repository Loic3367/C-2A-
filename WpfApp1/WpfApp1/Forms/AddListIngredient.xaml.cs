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
    
        public AddIngredient()
        {
            InitializeComponent();
            UCIngredients uCIngredients = new UCIngredients();
            
        }
        public AddIngredient(Recipes recipe)
        {
            InitializeComponent();        
            rcp = recipe;
          
           // UCIngredients uCIngredients = new UCIngredients(rcp);
        }
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            //Add Ingredients
            //Ingredients newIngredient = new Ingredients(NameIngredient.Text, ExpirationDate.DisplayDate, (MeasureIngredient)cbMeasure.SelectedIndex);
            //DataAccess.InsertIngredient(newIngredient);
            //this.Close();
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

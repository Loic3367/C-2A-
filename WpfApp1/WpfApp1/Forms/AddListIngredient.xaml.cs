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
        List<Ingredient> LI = new List<Ingredient>();
        List<Ingredient> IngreList { get; set; }
      
        public AddIngredient(Recipes recipe)
        {
            InitializeComponent();        
            rcp = recipe;
            IngreList = DataAccess.SelectAllIngredients();
            cbSelIngre.ItemsSource = DataAccess.SelectAllIngredients();
           
        }
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingr = new Ingredient();
            ingr = IngreList.Find(x => x.ToString() == cbSelIngre.Text);
            ingr.Quantite = Int32.Parse(tbQuantite.Text);
            LI.Add(ingr);
            
            foreach(UCIngredients item in pnl1.Children)
            {
                Ingredient ingre = new Ingredient();
                ingre = IngreList.Find(x => x.ToString() == item.cbIngreSel.SelectedItem.ToString());               
                ingre.Quantite = Int32.Parse(item.tbQuantite.Text);
                LI.Add(ingre);
            }
            rcp.ListIngredients = LI;
            AddSteps stepsForm = new AddSteps(rcp);
            this.Close();
            stepsForm.Show();
        }

        private void AddListIngre_Click(object sender, RoutedEventArgs e)
        {
            UCIngredients uCIngredients = new UCIngredients();         
            Size size = uCIngredients.RenderSize;
            ScrollViewer scroll = new ScrollViewer();
            pnl1.Children.Add(uCIngredients);
            pnl1.RenderSize = size;
            scroll.Content = pnl1;
        }
    }
}

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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour AddIngredient.xaml
    /// </summary>
    public partial class AddListIngredient : Window
    {
           
        private ObservableCollection<RecipeViewModel> listRecipes;
        RecipeViewModel rvm;
        AddIngredientsViewModel ivm;
        public AddListIngredient(RecipeViewModel vm, ObservableCollection<RecipeViewModel> listrvm)
        {
            rvm = vm;
            this.listRecipes = listrvm;
            this.ivm = new AddIngredientsViewModel(vm, listRecipes);
            this.DataContext = ivm;
            InitializeComponent();               
        }
        /*
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
            var stepsVm = new AddStepsViewModel(rcp, listRecipes);
            AddSteps stepsForm = new AddSteps(stepsVm);
            this.Close();
            stepsForm.Show();
        }
        */
        private void AddIngre_Click(object sender, RoutedEventArgs e)
         => this.ivm.AddEmpty();

        private void AddListIngres_Click(object sender, RoutedEventArgs e)
        {
            this.ivm.GetListIngre(rvm);
            var stepsVm = new AddStepsViewModel(rvm, listRecipes);
            AddSteps stepsForm = new AddSteps(stepsVm);
            this.Close();
            stepsForm.Show();
            
            
        }
        /*
UCIngredients uCIngredients = new UCIngredients();         
Size size = uCIngredients.RenderSize;
ScrollViewer scroll = new ScrollViewer();
pnl1.Children.Add(uCIngredients);
pnl1.RenderSize = size;
scroll.Content = pnl1;
*/

    }
}

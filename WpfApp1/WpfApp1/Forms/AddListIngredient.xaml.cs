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
 
        private void AddIngre_Click(object sender, RoutedEventArgs e)
         => this.ivm.AddEmpty();

        private void AddListIngres_Click(object sender, RoutedEventArgs e)
        {
            //Récuperer les ingrédients du View Model Ingredient dans le Recipe View Model puis ouvrir la fenêtre d'après
            this.ivm.GetListIngre(rvm);
            var stepsVm = new AddStepsViewModel(rvm, listRecipes);
            AddSteps stepsForm = new AddSteps(stepsVm);
            this.Close();
            stepsForm.ShowDialog();
            
            
        }
    }
}

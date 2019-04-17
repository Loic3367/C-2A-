using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour AddSteps.xaml
    /// </summary>
    public partial class AddSteps : Window
    {
        List<Steps> listSteps = new List<Steps>();
        Recipes rcp = new Recipes();
        int numStep = 2;
        private ObservableCollection<Recipes> listRecipes;
        public AddSteps(Recipes recipe,ObservableCollection<Recipes> r)
        {
            InitializeComponent();
            rcp = recipe;
            listRecipes = r;
            ObservableCollection<Steps> collStep = new ObservableCollection<Steps>();
        }
        private void AddListSteps_Click(object sender, RoutedEventArgs e)
        {

            UCSteps uCSteps = new UCSteps();
            uCSteps.lblNum.Content = numStep;
            numStep++;
            Size size = uCSteps.RenderSize;
            
            ScrollViewer scroll = new ScrollViewer();
            pnl1.Children.Add(uCSteps);
            pnl1.RenderSize = size;
            scroll.Content = pnl1;
        }

        private void addRecipesToBDD(object sender, RoutedEventArgs e)
        {
            listSteps.Add(new Steps { Number = 1, Description = tb1.Text });
            foreach (UCSteps item in pnl1.Children)
            {
                Steps steps = new Steps();
                steps.Number = (int)item.lblNum.Content;
                steps.Description = item.tbText.Text;
                listSteps.Add(steps);
            }
            rcp.ListSteps = listSteps;
            listRecipes.Add(rcp);
            long numRcp = DataAccess.Dal.InsertRecipe(rcp);
            foreach(Ingredient i in rcp.ListIngredients)
            {
                DataAccess.Dal.InsertListIngredients(numRcp, i);
            }
           
            foreach(Steps s in rcp.ListSteps)
            {
                DataAccess.Dal.InsertSteps(numRcp, s);
            }
        }

        private void AddListStep_Click(object sender, RoutedEventArgs e)
        {
            foreach(UCSteps item in pnl1.Children)
            {
                listSteps.RemoveAt(pnl1.Children.Count -1);
                
            }
        }
    }
}

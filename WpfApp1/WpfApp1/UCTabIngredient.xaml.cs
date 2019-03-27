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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UCTabIngredient.xaml
    /// </summary>
    public partial class UCTabIngredient : System.Windows.Controls.UserControl
    {
        public UCTabIngredient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddIngredient newIngredient = new AddIngredient();
            newIngredient.Show();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Récupèrer la liste des ingrédients en BDD et faire un ItemSource sur la datagrid
        }
    }
}

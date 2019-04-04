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
    /// Logique d'interaction pour UCIngredients.xaml
    /// </summary>
    public partial class UCIngredients : System.Windows.Controls.UserControl
    {
        static IReadOnlyList<IngredientMeasure> GetMeasure()
        {
            List<IngredientMeasure> ret = new List<IngredientMeasure>();
            foreach (MeasureIngredient cost in Enum.GetValues(typeof(MeasureIngredient)))
                ret.Add(new IngredientMeasure() { IngreType = cost });
            return ret;
        }
        Recipes rcp = new Recipes();
        public UCIngredients()
        {
            InitializeComponent();
            cbIngreSel.ItemsSource = GetMeasure();
        }

        public UCIngredients(Recipes recipes)
        {
            InitializeComponent();
            cbIngreSel.ItemsSource = GetMeasure();
            rcp = recipes;
        }
    }
}

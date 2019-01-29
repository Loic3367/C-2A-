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
        static IReadOnlyList<IngredientMeasure> GetMeasure()
        {
            List<IngredientMeasure> ret = new List<IngredientMeasure>();
            foreach (MeasureIngredient cost in Enum.GetValues(typeof(MeasureIngredient)))
                ret.Add(new IngredientMeasure() { IngreType = cost });
            return ret;
        }
        public AddIngredient()
        {
            InitializeComponent();
            cbMeasure.ItemsSource = GetMeasure();
        }

    }
}

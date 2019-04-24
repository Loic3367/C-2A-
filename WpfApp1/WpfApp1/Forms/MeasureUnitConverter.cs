using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1
{
    [ValueConversion(typeof(MeasureIngredient),typeof(IngredientMeasure))]
    class MeasureUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IngredientMeasure ingredientMeasure = new IngredientMeasure();
            ingredientMeasure.IngreType = (MeasureIngredient)value;
            return ingredientMeasure;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

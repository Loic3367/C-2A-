using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour AddIngredients.xaml
    /// </summary>
    public partial class AddIngredients : Window
    {
        static IReadOnlyList<IngredientMeasure> GetMeasure()
        {
            List<IngredientMeasure> ret = new List<IngredientMeasure>();
            foreach (MeasureIngredient cost in Enum.GetValues(typeof(MeasureIngredient)))
                ret.Add(new IngredientMeasure() { IngreType = cost });
            return ret;
        }
        public AddIngredients()
        {
            InitializeComponent();
            cbIngreUnite.ItemsSource = GetMeasure();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            DateTime dtt = (System.DateTime)dpDatePerem.SelectedDate;     
            DateTime dt = new DateTime(dtt.Year, dtt.Month, dtt.Day, 00, 00, 00, DateTimeKind.Local);
            Ingredient newIngredient = new Ingredient(tbNameIngre.Text, dt, (MeasureIngredient)cbIngreUnite.SelectedIndex);
            DataAccess.InsertIngredient(newIngredient);
            this.Close();
        }
    }
}

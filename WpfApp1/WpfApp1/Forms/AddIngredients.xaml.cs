using System;
using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour AddIngredients.xaml
    /// </summary>
    public partial class AddIngredients : Window
    {
        private ObservableCollection<Ingredient> listI;
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
        public AddIngredients(ObservableCollection<Ingredient> lI)
        {
            InitializeComponent();
            cbIngreUnite.ItemsSource = GetMeasure();
            listI = lI;
        }
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string dt = dpDatePerem.SelectedDate.ToString();
            listI.Add(new Ingredient(tbNameIngre.Text, dt, (MeasureIngredient)cbIngreUnite.SelectedIndex));
            Ingredient newIngredient = new Ingredient(tbNameIngre.Text, dt, (MeasureIngredient)cbIngreUnite.SelectedIndex);
            DataAccess.Dal.InsertIngredient(newIngredient);
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    public class IngredientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string str="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }

        private ObservableCollection<Ingredient> ingre;

        public ObservableCollection<Ingredient> Ingre
        {
            get { return ingre; }
            set
            {
                if (value !=ingre)
                {
                    ingre = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Ingredient ingreSel;

        public Ingredient IngreSel
        {
            get { return ingreSel; }
            set
            {
                if (value != ingreSel)
                {
                    ingreSel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public IngredientViewModel()
        {
            Ingre = new ObservableCollection<Ingredient>(DataAccess.Dal.SelectAllIngredients());
        }
    }
}

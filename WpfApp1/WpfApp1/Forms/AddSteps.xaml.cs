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
    /// Logique d'interaction pour AddSteps.xaml
    /// </summary>
    public partial class AddSteps : Window
    {
        List<Steps> listSteps = new List<Steps>();
        Recipes rcp = new Recipes();
        public AddSteps()
        {
            InitializeComponent();
        }
        public AddSteps(Recipes recipe)
        {
            InitializeComponent();

            rcp = recipe;
        }

        private void addUCSteps(object sender, RoutedEventArgs e)
        {

            listSteps.Add(new Steps { Number = 1, Description = tb1.Text });
            listSteps.Add(new Steps { Number = 2, Description = tb2.Text });
            listSteps.Add(new Steps { Number = 3, Description = tb3.Text });
            listSteps.Add(new Steps { Number = 4, Description = tb4.Text });
            listSteps.Add(new Steps { Number = 5, Description = tb5.Text });
            listSteps.Add(new Steps { Number = 6, Description = tb6.Text });
            listSteps.Add(new Steps { Number = 7, Description = tb7.Text });
            listSteps.Add(new Steps { Number = 8, Description = tb8.Text });
            listSteps.Add(new Steps { Number = 9, Description = tb9.Text });
            listSteps.Add(new Steps { Number = 10, Description = tb10.Text });
            rcp.ListSteps = listSteps;

        }
    }
}

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
    /// Logique d'interaction pour UCSteps.xaml
    /// </summary>
    public partial class UCSteps : System.Windows.Controls.UserControl
    {
        List<Steps> listSteps = new List<Steps>();
        int NumSteps;
        public UCSteps()
        {
            InitializeComponent();
            Steps steps = new Steps();
            NumSteps = 1;
            steps.Number = NumSteps;
            lbl1.Content = NumSteps;
            steps.Description = tb1.Text;
            NumSteps++;

            Image image = new Image();
            var dir = AppDomain.CurrentDomain.GetAssemblies();
            //image.Source = new BitmapImage(new Uri(@"file:///..\..\Images\arrowbas.png"));
            image.Source = new BitmapImage(new Uri(@"~..\..\Images\arrowbas.png"));
            btnArrow.Content = image;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

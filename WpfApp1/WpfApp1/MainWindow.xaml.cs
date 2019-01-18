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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string identifiantInput;
            string pwdInput;



            if (String.IsNullOrWhiteSpace(Identifiant.Text) == true)
            {
                MessageBox.Show("Veuillez entrer un identifiant");
                return;
            }
            else
            {
                identifiantInput = this.Identifiant.Text;
            }
            
            if (String.IsNullOrWhiteSpace(inputPwd.Text) == true)
            {
                MessageBox.Show("Veuillez entrer un mot de passe");
                return;
            }
            else {
                pwdInput = this.inputPwd.Text;
            }
            Window1 newWindow = new Window1();
            newWindow.Show();
            Application.Current.MainWindow = newWindow;
            this.Close();
        }
    }
}

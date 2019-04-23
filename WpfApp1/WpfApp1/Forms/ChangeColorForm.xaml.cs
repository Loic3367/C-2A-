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
using System.Configuration;
namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour ChangeColorForm.xaml
    /// </summary>
    public partial class ChangeColorForm : Window
    {
        public ChangeColorForm()
        {
            InitializeComponent();
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            string color = cbColor.Text;
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            settings["Color"].Value = color;
            configFile.Save(ConfigurationSaveMode.Modified);
            MessageBox.Show("Vous avez choisi la couleur " + color + ". Veuillez redémarrez l'application pour appliquer ces choix.");
            this.Close();
        }
    }
}

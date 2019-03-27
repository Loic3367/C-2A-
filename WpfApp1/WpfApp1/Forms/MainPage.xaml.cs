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
using System.Data.SQLite;
using System.Xml.Linq;
using System.Data.Linq;
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            //LoginWindow myLogWindow = new LoginWindow();
            //myLogWindow.Show();          
            //Function.DateTimeToSQLTime(new DateTime(2019, 01, 28,00,00,00, DateTimeKind.Local));
            //DataAccess.SelectInBDD();
            AddSteps addSteps = new AddSteps();
            addSteps.Show();
        }
        
    }
}

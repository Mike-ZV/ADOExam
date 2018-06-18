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

namespace ADOExam.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsMain.xaml
    /// </summary>
    public partial class SettingsMain : Page
    {
        public SettingsMain()
        {
            InitializeComponent();
        }

        private void SettingsDB_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SetFr.Source = new Uri(@"Pages\DBSettings.xaml", UriKind.RelativeOrAbsolute);
        }

        private void SettingsStatInfo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SetFr.Source = new Uri(@"Pages\Statistics.xaml", UriKind.RelativeOrAbsolute);
        }

    }
}

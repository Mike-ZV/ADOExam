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
    public partial class Statistics : Page
    {
        public Statistics()
        {
            InitializeComponent();
            AllCategories.Text = MainWindow.db.CategoriesSet.Count().ToString();
            AllVac.Text = MainWindow.db.VacanciesSet.Count().ToString();
        }

        private void BackFromStatInfo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SetFr.Source = new Uri(@"Pages\SettingsMain.xaml", UriKind.RelativeOrAbsolute);
        }

        private void ClearDBBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.db.Database.ExecuteSqlCommand("delete from VacanciesSet");
            MainWindow.db.Database.ExecuteSqlCommand("delete from CategoriesSet");
        }
    }
}

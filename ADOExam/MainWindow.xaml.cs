using ADOExam.Model;
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

namespace ADOExam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame SetFr;
        public static Frame SearchFr;
        public static Frame CatFr;
        public static ModelFContainer db = new ModelFContainer();
        //public static string URL = "http://vacancy.kharkov.ua/widgets/rssfeeds/";
        public MainWindow()
        {
            InitializeComponent();
            CategoriesFrame.Source = new Uri(@"Pages\VacancyCategories.xaml", UriKind.RelativeOrAbsolute);
            SettingsFrame.Source = new Uri(@"Pages\SettingsMain.xaml", UriKind.RelativeOrAbsolute);
            SearchFrame.Source = new Uri(@"Pages\Search.xaml", UriKind.RelativeOrAbsolute);
            SetFr = SettingsFrame;
            SearchFr = SearchFrame;
            CatFr = CategoriesFrame;
        }
    }
}

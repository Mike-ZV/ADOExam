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

namespace ADOExam.Pages
{
    public partial class Search : Page
    {
        public static ComboBox scat;

        public Search()
        {
            InitializeComponent();
            SearchCategory.ItemsSource = MainWindow.db.CategoriesSet.Select(s => s.CategoryName).ToList();
            scat = SearchCategory;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(SearchCategory.Text) || !String.IsNullOrEmpty(SearchDate.Text) || !String.IsNullOrEmpty(SearchEMail.Text) || !String.IsNullOrWhiteSpace(SearchPhrase.Text))
            {
                Categories cats = MainWindow.db.CategoriesSet.FirstOrDefault(fod => fod.CategoryName == SearchCategory.Text);
                List<Vacancies> lv = new List<Vacancies>();
                if (!String.IsNullOrEmpty(SearchCategory.Text))
                    lv = MainWindow.db.VacanciesSet.Where(w => w.CategoryID == cats.CategoryID).ToList();
                if (!String.IsNullOrEmpty(SearchDate.Text))
                    lv = MainWindow.db.VacanciesSet.ToList().Where(w => w.VacancyPublishingDate.Date >= SearchDate.SelectedDate.Value).ToList();
                if (!String.IsNullOrEmpty(SearchEMail.Text))
                    lv = MainWindow.db.VacanciesSet.Where(w => w.VacancyAuthorEMail == SearchEMail.Text).ToList();
                if (!String.IsNullOrWhiteSpace(SearchPhrase.Text))
                    lv = MainWindow.db.VacanciesSet.Where(w => w.VacancyDescription.Contains(SearchPhrase.Text)).ToList();
                if (lv.Count == 0)
                {
                    MessageBox.Show("There are no info by thees parameters", "Nothing founded", MessageBoxButton.OK);
                }
                else
                    DBLV.ItemsSource = lv;
            }
            else
            {
                MessageBox.Show("No data inserted, try again", "No data", MessageBoxButton.OK);
            }
        }
    }
}

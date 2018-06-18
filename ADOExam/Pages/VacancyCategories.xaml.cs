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
using System.Xml.Linq;

namespace ADOExam.Pages
{
    public partial class VacancyCategories : Page
    {
        public VacancyCategories()
        {
            InitializeComponent();
        }

        private void SaveCat_Click(object sender, RoutedEventArgs e)
        {
            Categories addCat = new Categories();
            try
            {
                addCat.CategoryName = CatName.Text;
                addCat.CategoryURL = RSSURL.Text;
                MainWindow.db.CategoriesSet.Add(addCat);
                MainWindow.db.SaveChanges();
                Load(addCat.CategoryURL, MainWindow.db.CategoriesSet.ToList().Last().CategoryID);
                MainWindow.db.SaveChanges();
                InfoBlock.Text = "New Category is Added succesfully";
                CatName.Text = "";
                RSSURL.Text = "";
                Search.scat.ItemsSource = MainWindow.db.CategoriesSet.Select(s => s.CategoryName).ToList();
            }
            catch (Exception ex)
            {
                InfoBlock.Text = ex.Message + " Error!";
            }
        }
        private void Load(string URL, int ID)
        {
            XDocument doc = new XDocument();
            try
            {
                doc = XDocument.Load(URL);
                List<Vacancies> vac = doc.Element("rss").Element("channel").Elements("item").
                    Select(s => new Vacancies
                    {
                        VacancyName = s.Element("title").Value,
                        VacancyURL = s.Element("link").Value,
                        VacancyDescription = s.Element("description").Value,
                        VacancyPublishingDate = DateTime.Parse(s.Element("pubDate").Value),
                        VacancyAuthorEMail = s.Element("author").Value,
                        CategoryID = ID
                    }).ToList();

                MainWindow.db.VacanciesSet.AddRange(vac);
            }
            catch (Exception ex)
            {
                InfoBlock.Text = ex.Message + " Error!";
            }
        }

    }
}

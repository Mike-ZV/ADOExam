using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
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
    public partial class DBSettings : Page
    {
        public DBSettings()
        {
            InitializeComponent();
            string connectionstring = ConfigurationManager.ConnectionStrings["ModelFContainer"].ConnectionString;
            if (connectionstring.ToLower().StartsWith("metadata="))
            {
                EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder(connectionstring);
                connectionstring = efBuilder.ProviderConnectionString;
            }
            SqlConnectionStringBuilder SQLCSbuilder = new SqlConnectionStringBuilder(connectionstring);
            ServerNow.Text = SQLCSbuilder.DataSource;
            DBNow.Text = SQLCSbuilder.InitialCatalog;
            LoginNow.Text = SQLCSbuilder.UserID;
            PasswordNow.Text = SQLCSbuilder.Password;
            if (ShowPass.IsChecked == true)
            {
                PasswordNow.Visibility = Visibility.Visible;
            }
        }

        private void BackFromDBSet_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SetFr.Source = new Uri(@"Pages\SettingsMain.xaml", UriKind.RelativeOrAbsolute);
        }

        private void SaveBD_Click(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder SCSBuilder = new SqlConnectionStringBuilder();
            SCSBuilder.DataSource = ServerName.Text;
            SCSBuilder.InitialCatalog = DBName.Text;
            SCSBuilder.IntegratedSecurity = true;
            string pcs = SCSBuilder.ToString();
            EntityConnectionStringBuilder ecsBuilder = new EntityConnectionStringBuilder();
            ecsBuilder.Provider = "System.Data.SqlClient";
            ecsBuilder.ProviderConnectionString = pcs;
            ecsBuilder.Metadata = @"metadata=res://*/Model.ModelF.csdl|res://*/Model.ModelF.ssdl|res://*/Model.ModelF.msl";
            MessageBox.Show(ecsBuilder.ToString());
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int cnc = ConfigurationManager.ConnectionStrings.Count;
            string cssName = "ModelFContainer" + cnc.ToString();
            ConnectionStringSettings csSettings = new ConnectionStringSettings(cssName, SCSBuilder.DataSource + SCSBuilder.InitialCatalog, ecsBuilder.Provider);
            ConnectionStringsSection csSection = config.ConnectionStrings;
            csSection.ConnectionStrings.Add(csSettings);
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}

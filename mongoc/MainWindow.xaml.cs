using MongoDB.Bson;
using MongoDB.Driver;
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

namespace mongoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MongoClient _client;
        public MainWindow()
        {
            InitializeComponent();
            var settings = new MongoClientSettings();
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
            
            _client = new MongoClient(settings);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = _client.GetDatabase("angular");
                var accounts = db.GetCollection<Account>("accounts");
                var all = accounts.Find<Account>(new BsonDocument()).ToList();
                lstAccounts.ItemsSource = all;
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show("Timed Out");
            }


        }
    }
}

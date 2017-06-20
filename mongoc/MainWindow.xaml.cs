using mongoc.Entities;
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
        MongoServerHelper _server;
        public MainWindow()
        {
            InitializeComponent();

            _server = new MongoServerHelper(@"c:\mongo\bin\mongod.exe", @"c:\projects\angularExample\data\db");
            var settings = new MongoClientSettings();
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
            if (_server.StartServer(settings) == false)
            {
                MessageBox.Show("Mongod server not started");
            };
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            if (_server.ProcessStarted)
            {
                try
                {
                    var db = _server.GetDatabase("angular");
                    var accounts = db.GetCollection<Account>("accounts");
                    var all = accounts.Find<Account>(new BsonDocument()).ToList();
                    lstAccounts.ItemsSource = all;
                }
                catch (TimeoutException)
                {
                    MessageBox.Show("Timed Out", "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("Mongod server process not started.", "Error");
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _server.StopServer();
        }
    }
}

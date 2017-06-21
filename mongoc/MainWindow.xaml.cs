using mongoc.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows;

namespace mongoc
{
    public partial class MainWindow : Window
    {
        MongoServerHelper _server;
        public MainWindow()
        {
            InitializeComponent();

            _server = new MongoServerHelper(@"C:\Program Files\MongoDB\Server\3.4\bin\mongod.exe", 
                                            @"c:\projects\mongoc\data");
            var settings = new MongoClientSettings();
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
            if (_server.StartServer(settings) == false)
            {
                MessageBox.Show("Mongod server not started");
            };
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _server.StopServer();
        }
    }
}

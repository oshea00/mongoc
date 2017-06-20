using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace mongoc
{
    public interface IServerHelper
    {
        bool StartServer(MongoClientSettings settings);
        void StopServer();
        bool ProcessStarted { get; set; }
        IMongoDatabase GetDatabase(string dbname);
    }

    public class MongoServerHelper : IServerHelper
    {
        Process _mongod;
        MongoClient _client;
        string _mongodExePath { get; set; }
        string _dbPath { get; set; }

        public bool ProcessStarted { get; set; }

        public MongoServerHelper(string mongodExePath, string dbPath)
        {
            _mongodExePath = mongodExePath;
            _dbPath = dbPath;
        }

        public void StopServer()
        {
            try
            {
                _mongod.Kill();
            }
            catch (Exception)
            {
            }
            finally
            {
                ProcessStarted = false;
            }
        }

        public bool StartServer(MongoClientSettings settings)
        {
            _mongod = Process.Start(new ProcessStartInfo {
                FileName = _mongodExePath,
                Arguments = $"--dbpath {_dbPath} --nojournal",
                WindowStyle = ProcessWindowStyle.Minimized,
            });
            if ( _mongod.Id > 0 )
            {
                ProcessStarted = true;
                _client = new MongoClient(settings);
            } 
            else
            {
                ProcessStarted = false;
                _client = null;
            }
            return ProcessStarted;
        }

        public IMongoDatabase GetDatabase(string dbname)
        {
            return _client.GetDatabase(dbname);
        }
    }
}

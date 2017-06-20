using MongoDB.Driver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mongoc.Tests
{
    [TestFixture]
    public class TestMongoServerHelper
    {
        [Test]
        public void CanStartMongoProcess()
        {
            var helper = new MongoServerHelper(@"c:\mongo\bin\mongod.exe", @"c:\projects\angularExample\data\db");
            var settings = new MongoClientSettings();
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
            helper.StartServer(settings);
            Assert.IsTrue(helper.ProcessStarted);
            Thread.Sleep(2000);
            helper.StopServer();
            Assert.IsFalse(helper.ProcessStarted);
        }
    
    }
}

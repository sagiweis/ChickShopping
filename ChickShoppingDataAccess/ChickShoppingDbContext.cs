using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickShoppingDataAccess
{
    public class ChickShoppingDbContext
    {
        private static ChickShoppingDbContext _instance;
        private MongoClient _client;
        private IMongoDatabase _database;

        private ChickShoppingDbContext(string ip, string port, string dbName)
        {
            _client = new MongoClient("mongodb://" + ip + ":" + port);
            _database = _client.GetDatabase(dbName);
        }

        public static ChickShoppingDbContext GetInstance()
        {
            string ip = System.Configuration.ConfigurationManager.AppSettings["DbServerIP"].ToString();
            string port = System.Configuration.ConfigurationManager.AppSettings["DbServerPort"].ToString();
            string dbName = System.Configuration.ConfigurationManager.AppSettings["DbName"].ToString();

            if (_instance == null)
            {
                _instance = new ChickShoppingDbContext(ip, port, dbName);
                return _instance;
            }
            else
            {
                return _instance;
            }
            
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}

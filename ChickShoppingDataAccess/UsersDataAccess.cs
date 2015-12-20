using ChickShoppingCommonResources;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickShoppingDataAccess
{
    public class UsersDataAccess
    {
        private const string COLLECTION_NAME = "Users";
        private static UsersDataAccess _instance;
        private IMongoCollection<User> _collection;

        public UsersDataAccess(){
            _collection = ChickShoppingDbContext.GetInstance().GetCollection<User>(COLLECTION_NAME);
        }

        public static UsersDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UsersDataAccess();
                return _instance;
            }
            else
            {
                return _instance;
            }

        }

        public User GetUser(string uuid)
        {
            return _collection.Find<User>(x => x.uuid.Equals(uuid)).FirstOrDefault<User>();
        }

        public void AddUser(User user)
        {
            _collection.InsertOne(user);
        }
    }
}

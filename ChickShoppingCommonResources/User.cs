using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickShoppingCommonResources
{
    public class User
    {
        [BsonId]
        public ObjectId _id;
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string uuid { get; set; }
        public string imageURI { get; set; }

        public User(string uuid, string firstName, string lastName, string imageURI)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.uuid = uuid;
            this.imageURI = imageURI;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickShoppingCommonResources
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string uuid { get; set; }

        public User(string firstName, string lastName, string uuid)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.uuid = uuid;
        }
    }
}

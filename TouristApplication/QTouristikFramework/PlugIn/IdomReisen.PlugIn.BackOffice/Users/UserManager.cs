using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using IdomOffice.Interface.BackOffice.Users;


namespace IdomOffice.PlugIn.BackOffice.Users
{
    public class UserManager : IUserManager
    {
        private IMongoDatabase mongoDatabase;

        private IMongoDatabase Db()
        {
            if (mongoDatabase != null)
                return mongoDatabase;

            var url = BackOfficePlugInConfig.MongoUrl;
            var client = new MongoClient(url);
            var database = BackOfficePlugInConfig.MongoDB;
            mongoDatabase = client.GetDatabase(database);
            return mongoDatabase;
        }
        private IMongoCollection<QApplikationUser> collectionQApplikationUsert { get { return Db().GetCollection<QApplikationUser>("ApplikationUser"); } }
        public void AddUser(QApplikationUser user)
        {
            collectionQApplikationUsert.InsertOne(user);
        }

        public QApplikationUser GetUser(string username)
        {
           return collectionQApplikationUsert.Find(m => m.Username == username).FirstOrDefault();
        }
    }
}

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDockerize
{
    public class MongoActions
    {
        MongoClient _client;

        public MongoActions(MongoClient client)
        {
            _client = client;

        }

        public List<string >getDatabaseList() 
        {
            return _client.ListDatabaseNames().ToList();

        }

        public IMongoDatabase GetDatabase(string dbname)
        {
            return _client.GetDatabase(dbname);
        }

        public bool DropDatabase(string dbname)
        {
            try
            {
                _client.DropDatabase(dbname);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }


    }
}

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDockerize
{
    public class MongoClientDBFactory
    {
        public MongoClient GetDefultConstructor()
        {
            return new MongoClient();
        }

        public MongoClient GetUrl(bool urlCtr = true)
        {
            return urlCtr ? new MongoClient(MongoUrl.Create("mongodb://localhost:27017"))
                :
                new MongoClient(new MongoUrl("mongodb://localhost:27017"));
        }
    }
}

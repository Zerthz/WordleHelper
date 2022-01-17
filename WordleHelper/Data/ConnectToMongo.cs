using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleHelper.Data
{
    public class ConnectToMongo
    {
        private readonly IConfiguration _configuration;

        public ConnectToMongo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        internal IMongoCollection<T> Connect<T>(in string collection)
        {
            var client = new MongoClient(_configuration.GetConnectionString("mongoDb"));
            var db = client.GetDatabase("Wordle");
            return db.GetCollection<T>(collection);
        }
    }
}

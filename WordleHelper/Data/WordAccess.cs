using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleHelper.Models;

namespace WordleHelper.Data
{
    public class WordAccess : IDataAccess<WordScore>
    {
        private const string WordCollection = "WordList";
        private readonly IConfiguration _configuration;
        ConnectToMongo _connection;

        public WordAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new ConnectToMongo(_configuration);
            
        }

        public Task Delete(string id)
        {
            var wordCollection = _connection.Connect<WordScore>(WordCollection);
            return wordCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<WordScore>> GetAll()
        {
            var wordCollection = _connection.Connect<WordScore>(WordCollection);
            var results = await wordCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<WordScore> GetByName(string name)
        {
            var wordCollection = _connection.Connect<WordScore>(WordCollection);
            var results = await wordCollection.FindAsync(x=> x.Word == name);
            return results.FirstOrDefault();

        }

        public Task Insert(WordScore wordScore)
        {
            var wordCollection = _connection.Connect<WordScore>(WordCollection);
            return wordCollection.InsertOneAsync(wordScore);
        }

        public Task InsertMany(IEnumerable<WordScore> entities)
        {
            var wordCollection = _connection.Connect<WordScore>(WordCollection);
            return wordCollection.InsertManyAsync(entities);
        }

        public Task Update(WordScore entity)
        {
            var wordCollection = _connection.Connect<WordScore>(WordCollection);
            var filter = Builders<WordScore>.Filter.Eq("Id", entity.Id);
            return wordCollection.ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true });

        }
    }
}

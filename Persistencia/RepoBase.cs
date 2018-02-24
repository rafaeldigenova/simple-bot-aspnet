using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace SimpleBot.Persistencia
{
    public class RepoBase<T> where T : AggregateRoot
    {
        private static MongoClient _client;

        public static MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new MongoClient(Configuracao.ConnectionString);
                }
                return _client;
            }
        }

        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<T> _collection;

        public RepoBase(string collectionName)
        {
            _database = Client.GetDatabase(Configuracao.DatabaseName);

            _collection = _database.GetCollection<T>(collectionName);
        }

        public Task InsertOne(T entity)
        {
            return _collection.InsertOneAsync(entity);
        }

        public IQueryable<T> GetLazy()
        {
            return _collection.AsQueryable();
        }

        public async Task<T> FindById(Guid id)
        {
            return _collection.Find(x => x.Id == id).FirstOrDefault();
        }

        public async Task Increment(
            Expression<Func<T, bool>> filter,
            string fieldName,
            int incValue)
        {
            var update = new BsonDocument("$inc", new BsonDocument(fieldName, incValue));

            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
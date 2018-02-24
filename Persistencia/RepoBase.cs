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
    public class RepoBase<T> : IRepoBase<T>
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
        
        public async Task ReplaceOne(Expression<Func<T, bool>> filter,
            T entity)
        {
            await _collection.ReplaceOneAsync(filter, entity, new UpdateOptions() { IsUpsert = true });
        }
    }
}
using MongoDB.Driver;
using SimpleBot.Infra;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleBot.Persistencia.MongoDB
{
    public abstract class RepoBase<T>
    {
        private static MongoClient _client;

        private static string _connectionString;

        public static MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new MongoClient(_connectionString);
                }
                return _client;
            }
        }

        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<T> _collection;

        public RepoBase(string collectionName, string connectionString)
        {
            _connectionString = connectionString;

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
using MongoDB.Driver;
using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleBot.Persistencia.Memoria
{
    public class MemoHelper<T> 
    {
        private static List<T> _collection;

        private static List<T> Collection
        {
            get
            {
                if(_collection == null)
                {
                    _collection = new List<T>();
                }

                return _collection;
            }
        }

        public Task InsertOneAsync(T entity)
        {
            return Task.Run(() =>
            {
                Collection.ToList().Add(entity);
            });
        }

        public IQueryable<T> GetLazy()
        {
            return Collection.AsQueryable();
        }

        public async Task ReplaceOneAsync(Expression<Func<T, bool>> filter,
            T entity)
        {
            var entidade = Collection.AsQueryable().Where(filter).FirstOrDefault();

            if (entidade != null)
            {
                Collection.ToList().Remove(entidade);
            }

            Collection.Add(entity);
        }
    }
}
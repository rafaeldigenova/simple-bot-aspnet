﻿using MongoDB.Driver;
using SimpleBot.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleBot.Persistencia.Memoria
{
    public abstract class RepoBase<T> : IRepoBase<T>
    {
        private static List<T> _collection;

        public RepoBase(string collectionName, string connectionString = null)
        {
            if(_collection == null)
            {
                _collection = new List<T>();
            }
        }

        public Task InsertOne(T entity)
        {
            return Task.Run(() =>
            {
                _collection.ToList().Add(entity);
            });
        }

        public IQueryable<T> GetLazy()
        {
            return _collection.AsQueryable();
        }

        public async Task ReplaceOne(Expression<Func<T, bool>> filter,
            T entity)
        {
            var entidade = _collection.AsQueryable().Where(filter).FirstOrDefault();

            if (entidade != null)
            {
                _collection.ToList().Remove(entidade);
            }

            _collection.Add(entity);
        }
    }
}
using SimpleBot.Infra;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleBot.Persistencia.SQL
{
    public abstract class RepoBase<T> : IRepoBase<T>
    {
        public abstract Task InsertOne(T entity);

        public abstract IQueryable<T> GetLazy();

        public abstract Task ReplaceOne(Expression<Func<T, bool>> filter, T entity);
    }
}
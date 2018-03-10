using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SimpleBot.Infra
{
    public interface IRepoBase<T> 
    {
        Task InsertOne(T entity);
        IQueryable<T> GetLazy();
        Task ReplaceOne(Expression<Func<T, bool>> filter, T entity);
    }
}
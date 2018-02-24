//using MongoDB.Bson;
//using MongoDB.Driver;
//using SimpleBot.Infra;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;
//using System.Web;

//namespace SimpleBot.Persistencia.SQL
//{
//    public class RepoBase<T> : IRepoBase<T>
//    {
//        public Task InsertOne(T entity)
//        {
//            throw new NotImplementedException();
//        }

//        public IQueryable<T> GetLazy()
//        {
//            throw new NotImplementedException();
//        }

//        public async Task ReplaceOne(Expression<Func<T, bool>> filter,
//            T entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
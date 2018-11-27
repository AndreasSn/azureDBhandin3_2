using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using azureDBhandin3_2.Models;
using Microsoft.Azure.Documents;

namespace azureDBhandin3_2.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Initialize();

        Task<Document> CreatePersonAsync(Person person);

        Person getPerson(string Id);
        //
        // TEntity Get(long id);
        // IEnumerable<TEntity> GetAll();
        // IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //
        // // This method was not in the videos, but I thought it would be useful to add.
        // TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        //
        // void Add(TEntity entity);
        // void AddRange(IEnumerable<TEntity> entities);
        //
        // void Remove(TEntity entity);
        // void RemoveRange(IEnumerable<TEntity> entities);
        // void Put(TEntity entity);
    }
}

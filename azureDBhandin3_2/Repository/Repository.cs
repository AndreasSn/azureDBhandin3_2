using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using azureDBhandin3_2.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.EntityFrameworkCore;

namespace azureDBhandin3_2.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //protected readonly DbContext Context;
        private  readonly string DatabaseId = "PersonDB";
        private  readonly string CollectionId = "persons";
        private const string EndpointUri = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private DocumentClient client => new DocumentClient(new Uri(EndpointUri), PrimaryKey);

        public async void Initialize()
        {   
            //client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            var database = await client.CreateDatabaseIfNotExistsAsync(new Database { Id = "PersonDB" });
            CreateCollectionIfNotExist();
        }

        private async void CreateCollectionIfNotExist()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId });
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Document> CreatePersonAsync(Person person)
        {
            return await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), person);
        }



      //  public TEntity Get(long id)
      //  {
      //      // Here we are working with a DbContext, not PlutoContext. So we don't have DbSets 
      //      // such as Courses or Authors, and we need to use the generic Set() method to access them.
      //      return Context.Set<TEntity>().Find(id);
      //  }
      //
      //  public IEnumerable<TEntity> GetAll()
      //  {
      //      // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
      //      // too much noise. I could get a reference to the DbSet returned from this method in the 
      //      // constructor and store it in a private field like _entities. This way, the implementation
      //      // of our methods would be cleaner:
      //      // 
      //      // _entities.ToList();
      //      // _entities.Where();
      //      // _entities.SingleOrDefault();
      //      // 
      //      // I didn't change it because I wanted the code to look like the videos. But feel free to change
      //      // this on your own.
      //      return Context.Set<TEntity>().ToList();
      //  }
      //
      //  public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
      //  {
      //      return Context.Set<TEntity>().Where(predicate);
      //  }
      //
      //  public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
      //  {
      //      return Context.Set<TEntity>().SingleOrDefault(predicate);
      //  }
      //
      //  public void Add(TEntity entity)
      //  {
      //      Context.Set<TEntity>().Add(entity);
      //  }
      //
      //  public void AddRange(IEnumerable<TEntity> entities)
      //  {
      //      Context.Set<TEntity>().AddRange(entities);
      //  }
      //
      //  public void Remove(TEntity entity)
      //  {
      //      Context.Set<TEntity>().Remove(entity);
      //  }
      //
      //  public void RemoveRange(IEnumerable<TEntity> entities)
      //  {
      //      Context.Set<TEntity>().RemoveRange(entities);
      //  }
      //
      //  public void Put(TEntity entity)
      //  {
      //
      //      Context.Entry(entity).State = EntityState.Modified;
      //  }
    }
}

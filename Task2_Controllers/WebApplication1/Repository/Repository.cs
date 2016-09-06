using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication_CustomFactory.Models;

namespace WebApplication_CustomFactory.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }
        public async Task Add(T item)
        {
            context.Set<T>().Add(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = context.Set<T>().FirstOrDefault(e => e.Id == id);
            context.Set<T>().Remove(item);
            await context.SaveChangesAsync();
        }

        public Task<T> Get(int id)
        {
            return Task.FromResult(context.Set<T>().FirstOrDefault(e => e.Id == id));
        }

        public async Task<IEnumerable<T>> List()
        {
            return await Task.FromResult(context.Set<T>().ToList());
        }

        public async Task Update(T item)
        {
            var entry = context.Entry(item);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
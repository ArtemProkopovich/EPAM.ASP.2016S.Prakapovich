using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_CustomFactory.Models;

namespace WebApplication_CustomFactory.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task Add(T item);
        Task<T> Get(int id);
        Task<IEnumerable<T>> List();
        Task Delete(int id);
        Task Update(T item);
    }
}

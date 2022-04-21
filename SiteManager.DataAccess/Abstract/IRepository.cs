using SiteManager.Domain.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        T Update(T entity);
    }
}

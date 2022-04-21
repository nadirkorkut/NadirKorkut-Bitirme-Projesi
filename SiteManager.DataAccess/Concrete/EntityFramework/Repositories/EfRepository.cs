using Microsoft.EntityFrameworkCore;
using SiteManager.DataAccess.Abstract;
using SiteManager.DataAccess.Concrete.EntityFramework.Contexts;
using SiteManager.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManager.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly SiteManagerDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public EfRepository(SiteManagerDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}

using System.Collections.Generic;
using DXCoreSampleApp.Common.Data;
using DXCoreSampleApp.Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DXCoreSampleApp.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context;
        private DbSet<T> _entities;
        public IEnumerable<T> Table => this.Entities;

        public EfRepository(DatabaseContext context)
        {
            _context = context;
        }

        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }

        public async Task<T> GatByIdAync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public async Task InsertAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}

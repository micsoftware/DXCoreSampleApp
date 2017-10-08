using DXCoreSampleApp.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DXCoreSampleApp.Common.Data
{
    public interface IRepository<T> where T: BaseEntity
    {
        IEnumerable<T> Table { get; }
        T GetById(object id);
        Task<T> GatByIdAync(object id);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}

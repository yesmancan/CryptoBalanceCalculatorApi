using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public interface IBaseServices<T> where T : class
    {
        Task<T> Create(T item);
        Task<T> Delete(Guid id);
        Task<IEnumerable<T>> GetAsync();
        T Get(Guid id);
        Task<T> GetAsync(Guid id);
        Task Update(Guid id, T item);
    }
}

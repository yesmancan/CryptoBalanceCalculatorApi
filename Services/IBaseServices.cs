using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoBalanceCalculatorApi.Data.Entities;

namespace CryptoBalanceCalculatorApi.Services
{
    public interface IBaseServices<T> where T : class
    {
        Task<T> Create(T item);
        Task<T> Delete(long id);
        Task<IEnumerable<T>> Get();
        Task<T> Get(long id);
        Task Update(long id, T item);
    }
}
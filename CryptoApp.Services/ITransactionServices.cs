using CryptoApp.Data.Entities;
using CryptoApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public interface ITransactionServices
    {
        Task<Transaction> Create(Transaction item);
        Task<Transaction> Delete(Guid id);
        Transaction Get(Guid id);
        Task<IEnumerable<Transaction>> GetByUserIdAsync(Guid userId);
        Task<Transaction> GetAsync(Guid id);
        Task<IEnumerable<Currency>> GetCoinsByMarket(Guid companyId);
        Task<List<Companies>> GetMarkets();
        Task<UserTransactionOverview> TransactionCalculate(Guid userId);
    }
}
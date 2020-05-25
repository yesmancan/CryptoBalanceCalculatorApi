using CryptoApp.Commons;
using CryptoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public interface IPairServices
    {
        Task<Pair> CreatePairsAsync(Pair pair);
        Task<Pair> GetPairAsync(string normalized);
        Task<Pair> GetPairAsync(Guid id);
        Task<List<Pair>> GetPairsAsync();
    }
}

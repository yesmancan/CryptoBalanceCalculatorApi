using CryptoApp.Commons;
using CryptoApp.Data;
using CryptoApp.Data.Entities;
using CryptoApp.Services.CurrencyServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public class PairServices : IPairServices
    {
        private readonly IRetrieverRepository _retrieverRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _context;
        public PairServices(IRetrieverRepository retrieverRepository, IMemoryCache memoryCache, ApplicationDbContext context)
        {
            _retrieverRepository = retrieverRepository;
            _memoryCache = memoryCache;
            _context = context;
        }
        public async Task<Pair> GetPairAsync(string normalized)
        {
            Pair pair = await _memoryCache.GetOrCreateAsync<Pair>(normalized, async entry =>
              {
                  entry.SlidingExpiration = TimeSpan.FromDays(30);
                  return await _retrieverRepository.GetFirstAsync<Pair>(x => x.Normalized == normalized);
              });
            if (pair == null)
                _memoryCache.Remove(normalized);

            return pair;
        }
        public async Task<Pair> GetPairAsync(Guid id)
        {
            Pair _companies = await _memoryCache.GetOrCreateAsync<Pair>(id, async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(30);
                return await _retrieverRepository.GetByIdAsync<Pair>(id);
            });

            return _companies;
        }
        public async Task<List<Pair>> GetPairsAsync()
        {
            List<Pair> pairs = await _memoryCache.GetOrCreateAsync<List<Pair>>("AllPairs", async entry =>
           {
               entry.SlidingExpiration = TimeSpan.FromDays(30);
               return (List<Pair>)await _retrieverRepository.GetAsync<Pair>(x => x.Status == (short)Enums.EntityStatus.Active);
           });

            return pairs;
        }

        public async Task<Pair> CreatePairsAsync(Pair pair)
        {
            if (await GetPairAsync(pair.Normalized) == null)
            {
                await _context.AddAsync<Pair>(pair);
                _context.Entry<Pair>(pair).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }

            return pair;
        }
    }
}

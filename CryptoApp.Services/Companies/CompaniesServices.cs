using CryptoApp.Commons;
using CryptoApp.Data;
using CryptoApp.Data.Entities;
using CryptoApp.Services.CurrencyServices;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public class CompaniesServices : ICompaniesServices
    {
        private readonly IRetrieverRepository _retrieverRepository;
        private readonly IMemoryCache _memoryCache;
        public CompaniesServices(IRetrieverRepository retrieverRepository, IMemoryCache memoryCache)
        {
            _retrieverRepository = retrieverRepository;
            _memoryCache = memoryCache;
        }
        public async Task<Companies> GetCompanyAsync(Enums.Companies companies)
        {
            Companies _companies = await _memoryCache.GetOrCreateAsync<Companies>(companies.ToString(), async entry =>
              {
                  entry.SlidingExpiration = TimeSpan.FromDays(30);
                  return await _retrieverRepository.GetFirstAsync<Companies>(x => x.Name == companies.ToString());
              });

            return _companies;
        }
        public async Task<Companies> GetCompanyAsync(Guid id)
        {
            Companies _companies = await _memoryCache.GetOrCreateAsync<Companies>(id, async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(30);
                return await _retrieverRepository.GetByIdAsync<Companies>(id);
            });

            return _companies;
        }
        public async Task<List<Companies>> GetCompaniesAsync()
        {
            List<Companies> _companies = await _memoryCache.GetOrCreateAsync<List<Companies>>("AllCompanies", async entry =>
           {
               entry.SlidingExpiration = TimeSpan.FromDays(30);
               return (List<Companies>)await _retrieverRepository.GetAsync<Companies>(x => x.Status == (short)Enums.EntityStatus.Active);
           });

            return _companies;
        }
    }
}

using CryptoApp.Data;
using CryptoApp.Data.Entities;
using CryptoApp.Models;
using CryptoApp.Models.DTO;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoApp.Services.CurrencyServices
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly IRetrieverRepository _retrieverRepository;
        private readonly ICompaniesServices _companiesServices;
        private readonly IPairServices _pairServices;

        private readonly IMemoryCache _memoryCache;

        private readonly ApplicationDbContext _context;

        public CurrencyServices(IRetrieverRepository retrieverRepository, ICompaniesServices companiesServices, IPairServices pairServices, IMemoryCache memoryCache, ApplicationDbContext context)
        {
            _context = context;
            _memoryCache = memoryCache;
            _pairServices = pairServices;
            _companiesServices = companiesServices;
            _retrieverRepository = retrieverRepository;
        }
        public async Task<Currency> GetCurrencyAsync(Guid id)
        {
            Currency currency = await _memoryCache.GetOrCreateAsync<Currency>(id, async entry =>
              {
                  entry.SlidingExpiration = TimeSpan.FromMinutes(1);
                  return await _retrieverRepository.GetByIdAsync<Currency>(id);
              });
            if (currency == null)
                _memoryCache.Remove(id);

            return currency;
        }
        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            List<Currency> currencies = await _memoryCache.GetOrCreateAsync<List<Currency>>("AllCurrencies", async entry =>
           {
               entry.SlidingExpiration = TimeSpan.FromMinutes(2);
               return (List<Currency>)await _retrieverRepository.GetAsync<Currency>();
           });

            return currencies;
        }
        public async Task<ApiResultModel<List<CurrencyDTO>>> GetCurrenciesDTOAsync()
        {
            try
            {
                return await _memoryCache.GetOrCreateAsync<ApiResultModel<List<CurrencyDTO>>>("AllCurrenciesDTO", async entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromMinutes(2);

                    List<CurrencyDTO> returnData = new List<CurrencyDTO>();
                    var data = await GetCurrenciesAsync();

                    var pairs = await _pairServices.GetPairsAsync();
                    var markets = await _companiesServices.GetCompaniesAsync();
                    foreach (Currency currency in data)
                    {
                        var _pair = pairs.FirstOrDefault(x => x.Id == currency.Pairs);
                        var _market = markets.FirstOrDefault(x => x.Id == currency.Companies);
                        returnData.Add(new CurrencyDTO()
                        {
                            Id = currency.Id,
                            Pair = _pair,
                            PairId = currency.Pairs,
                            Company = _market,
                            CompanyId = _market.Id,
                            Ask = currency.Ask,
                            Average = currency.Average,
                            Bid = currency.Bid,
                            Daily = currency.Daily,
                            DailyPercent = currency.DailyPercent,
                            High = currency.High,
                            Low = currency.Low,
                            Last = currency.Last,
                            Open = currency.Open,
                            Order = currency.Order,
                            TimeStamp = currency.TimeStamp,
                            Unit = currency.Unit,
                            Volume = currency.Volume
                        });
                    }

                    return new ApiResultModel<List<CurrencyDTO>>()
                    {
                        Data = returnData,
                        Success = true,
                        Message = "Success",
                        Code = 200
                    };
                });

            }
            catch (Exception ex)
            {
                return new ApiResultModel<List<CurrencyDTO>>()
                {
                    Data = new List<CurrencyDTO>(),
                    Success = false,
                    Message = ex.Message,
                    Code = ex.HResult
                };
            }
        }
    }
}

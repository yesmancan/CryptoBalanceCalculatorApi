using CryptoApp.Commons;
using CryptoApp.Data;
using CryptoApp.Data.Entities;
using CryptoApp.Models;
using CryptoApp.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApp.Services.CurrencyServices.CompaniesData
{
    public class BTCTurkProServices : ICompaniesDataService
    {
        private static readonly string uri = "https://api.btcturk.com";
        private readonly string coinsPath = $"{uri}/api/v2/ticker";
        private readonly string coinPath = $"{uri}/api/v2/ticker?pairSymbol=";
        private readonly string coinsOtherCurrencyPath = $"{uri}/api/v2/ticker/currency?symbol=";

        private readonly ApplicationDbContext _context;
        private readonly ICompaniesServices _companiesServices;
        private readonly IPairServices _pairServices;

        public BTCTurkProServices(ApplicationDbContext context, ICompaniesServices companiesServices, IPairServices pairServices)
        {
            _context = context;
            _companiesServices = companiesServices;
            _pairServices = pairServices;
        }
        public async System.Threading.Tasks.Task GetCoinsAsync()
        {
            ApiResultModel<List<BtcTurkCurrencyDTO>> result = JsonConvert.DeserializeObject<ApiResultModel<List<BtcTurkCurrencyDTO>>>(await Helpers.CreateWebRequest(coinsPath));

            if (result.Success && result.Data != null && result.Data.Count > 0)
            {
                Companies companies = await _companiesServices.GetCompanyAsync(Enums.Companies.BtcTurk);
                Guid companiesId = companies.Id;
                List<Pair> pairs = await _pairServices.GetPairsAsync();

                await _context.Database.ExecuteSqlRawAsync($"DELETE [Application].[Currency] WHERE Companies = '{companiesId}'");
                List<Currency> curs = new List<Currency>();
                foreach (BtcTurkCurrencyDTO x in result.Data)
                {
                    Guid pairId = pairs.FirstOrDefault(p => p.Normalized == x.PairNormalized).Id;
                    curs.Add(new Currency()
                    {
                        Id = Guid.NewGuid(),
                        Companies = companiesId,
                        Pairs = pairId,
                        Ask = x.Ask,
                        Average = x.Average,
                        Bid = x.Bid,
                        Daily = x.Daily,
                        DailyPercent = x.DailyPercent,
                        High = x.High,
                        Last = x.Last,
                        Low = x.Low,
                        Open = x.Open,
                        Order = x.Order,
                        TimeStamp = x.TimeStamp,
                        Volume = x.Volume
                    });
                }


                try
                {
                    await _context.Currencies.AddRangeAsync(curs);
                    await _context.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                }
            }

        }
    }
}

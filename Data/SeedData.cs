using System;
using CryptoBalanceCalculatorApi.Commons;
using CryptoBalanceCalculatorApi.Data.Entities;
using CryptoBalanceCalculatorApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CryptoBalanceCalculatorApi.Data
{
    public static class SeedData
    {
        public static async System.Threading.Tasks.Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new CryptoContext(serviceProvider.GetRequiredService<DbContextOptions<CryptoContext>>()))
            {
                context.Database.EnsureCreated();

                // Look for any Currencies.
                if (await context.Currencies.AnyAsync())
                {
                    return;   // DB has been seeded
                }
                context.Currencies.AddRange(new Currency()
                {
                    LongName = "BITCOIN",
                    ShortName = "BTC",
                    Symbol = "BTC",
                    CreatedBy = "HASH",
                    CreateDt = DateTime.Now,
                    Status = (int)Enums.EntityStatus.Confirm
                },
               new Currency()
               {
                   LongName = "DOGECOIN",
                   ShortName = "DOGE",
                   Symbol = "DOGE",
                   CreatedBy = "HASH",
                   CreateDt = DateTime.Now,
                   Status = (int)Enums.EntityStatus.Confirm
               });
                context.SaveChanges();

                // Look for any CryptoHistoryItems.
                if (await context.CryptoHistoryItems.AnyAsync())
                {
                    return;   // DB has been seeded
                }

                context.CryptoHistoryItems.AddRange(
                    new CryptoHistoryItem
                    {
                        Name = "",
                        Amount = 5,
                        CoinName = (await context.Currencies.FirstOrDefaultAsync()).ShortName,
                        Company = "BTCTURK",
                        Order = 0,
                        CreatedBy = "HASH",
                        CreateDt = DateTime.Now,
                        PaymentType = Enums.PaymentType.Buying.ToString(),
                        Status = 1,
                        Rates = JsonConvert.SerializeObject(new System.Collections.Generic.List<RateDTO>(){
                           new RateDTO(){
                               Name ="USD",
                               price="5"
                           },
                           new RateDTO(){
                               Name ="BTC",
                               price="67,000"
                           }
                       })
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
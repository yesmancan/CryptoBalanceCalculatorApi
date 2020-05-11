using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoBalanceCalculatorApi.Models
{
    public static class SeedData
    {
        public static async System.Threading.Tasks.Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new CryptoContext(serviceProvider.GetRequiredService<DbContextOptions<CryptoContext>>()))
            {
                context.Database.EnsureCreated();

                // Look for any movies.
                if (await context.CryptoHistoryItems.AnyAsync())
                {
                    return;   // DB has been seeded
                }

                context.CryptoHistoryItems.AddRange(
                    new CryptoHistoryItem
                    {
                        Name = "",
                        Amount = 5,
                        CoinName = "BTC",
                        Company = "BTCTURK",
                        Order = 0,
                        CreateBy = 1,
                        CreateDt = DateTime.Now,
                        PaymentType = "ALIS",
                        Status = 1,
                        Rates = new System.Collections.Generic.List<Rate>(){
                           new Rate(){
                               Name ="USD",
                               price="5"
                           },
                           new Rate(){
                               Name ="BTC",
                               price="67,000"
                           }
                       }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
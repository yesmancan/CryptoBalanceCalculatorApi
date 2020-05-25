using System;
using CryptoApp.Commons;
using CryptoApp.Data;
using CryptoApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoBalanceCalculatorApi.Data
{
    public static class SeedData
    {
        public static async System.Threading.Tasks.Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();

                // Look for any Companies
                if (!await context.Companies.AnyAsync())
                {
                    await context.Companies.AddRangeAsync(new Companies()
                    {
                        Id = Guid.NewGuid(),
                        Name = Enums.Companies.BtcTurk.ToString(),
                        Order = 1,
                        Status = (short)Enums.EntityStatus.Active,
                        CreateDt = DateTime.Now,
                        CreatedBy = "SYSTEM",
                    }, new Companies()
                    {
                        Id = Guid.NewGuid(),
                        Name = Enums.Companies.Koinim.ToString(),
                        Order = 2,
                        Status = (short)Enums.EntityStatus.Active,
                        CreateDt = DateTime.Now,
                        CreatedBy = "SYSTEM",
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
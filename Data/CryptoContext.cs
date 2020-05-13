using CryptoBalanceCalculatorApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoBalanceCalculatorApi.Data
{
    public class CryptoContext : DbContext
    {
        public CryptoContext(DbContextOptions<CryptoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<CryptoHistoryItem> CryptoHistoryItems { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("TodoItem");
            modelBuilder.Entity<CryptoHistoryItem>().ToTable("CryptoHistoryItem");
            modelBuilder.Entity<Currency>().ToTable("Currency");
            modelBuilder.Entity<PaymentType>().ToTable("PaymentType");

        }
    }
}
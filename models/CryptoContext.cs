using Microsoft.EntityFrameworkCore;

namespace CryptoBalanceCalculatorApi.Models
{
    public class CryptoContext : DbContext
    {
        public CryptoContext(DbContextOptions<CryptoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<CryptoHistoryItem> CryptoHistoryItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("TodoItem");
            modelBuilder.Entity<CryptoHistoryItem>().ToTable("CryptoHistoryItem");
        }
    }
}
using System.Reflection;
using CryptoApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Pair> Pairs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency", "Application");

                entity.HasKey(x => x.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("UniqueIdentifier")
                    .HasDefaultValueSql("(newid())");

                entity.HasKey(x => x.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedNever();

                entity.Property(e => e.Ask)
                .HasColumnType("decimal(16,8)");

                entity.Property(e => e.Average)
                .HasColumnType("decimal(16,8)");

                entity.Property(e => e.Bid)
                .HasColumnType("decimal(16,8)");

                entity.Property(e => e.Daily)
                .HasColumnType("decimal(16,8)");

                entity.Property(e => e.DailyPercent)
                .HasColumnType("decimal(16,8)");

                entity.Property(e => e.High)
                .HasColumnType("decimal(16,8)");

                entity.Property(e => e.Last)
                .HasColumnType("decimal(16,8)");

                entity.Property(e => e.Low)
                .HasColumnType("decimal(16,8)");

                entity.Property(e => e.Open)
                .HasColumnType("decimal(16,8)");

                entity.Property(e => e.Volume)
                .HasColumnType("decimal(16,8)");
            });
            modelBuilder.Entity<Companies>(entity =>
            {
                entity.ToTable("Companies", "Application");

                entity.HasKey(x => x.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                .HasColumnType("nvarchar(250)")
                .HasMaxLength(250)
                .IsRequired();
            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions", "Application");

                entity.HasKey(x => x.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Market)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

                entity.Property(e => e.Coin)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

                entity.Property(e => e.UserId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();
            });
            modelBuilder.Entity<Pair>(entity =>
            {
                entity.ToTable("Pairs", "Application");

                entity.HasKey(x => x.Id);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Normalized)
                   .HasColumnType("nvarchar(25)")
                   .HasMaxLength(250)
                   .IsRequired();

                entity.Property(e => e.Numerator)
                 .HasColumnType("nvarchar(25)")
                 .HasMaxLength(250)
                 .IsRequired();

                entity.Property(e => e.Denominator)
                 .HasColumnType("nvarchar(25)")
                 .HasMaxLength(250)
                 .IsRequired();
            });

        }
    }
}

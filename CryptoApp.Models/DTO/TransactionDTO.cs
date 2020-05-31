using CryptoApp.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApp.Models.DTO
{
    public class TransactionDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public Guid MarketId { get; set; }
        public Companies Market { get; set; }

        public Guid CoinId { get; set; }
        public Pair Coin { get; set; }

        [Column(TypeName = "decimal(27,8)")]
        public decimal Unit { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BuyingPrice { get; set; }
        public bool IsSold { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SellPrice { get; set; }
        public int Status { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDt { get; set; }
    }
}

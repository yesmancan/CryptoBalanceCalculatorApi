using CryptoApp.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApp.Models.DTO
{
    public class CurrencyDTO
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Companies Company { get; set; }
        public Guid PairId { get; set; }
        public Pair Pair { get; set; }

        public int Unit { get; set; }
        public string TimeStamp { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Last { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal High { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Low { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Bid { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ask { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Open { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Volume { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Average { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Daily { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DailyPercent { get; set; }
        public int Order { get; set; }
    }
}

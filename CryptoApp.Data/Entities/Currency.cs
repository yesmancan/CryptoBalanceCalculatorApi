using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CryptoApp.Data.Entities
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid Companies { get; set; }
        public Guid Pairs { get; set; }
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

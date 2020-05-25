using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApp.Data.Entities
{
    public class Currency
    {
        //public Currency()
        //{
        //    Companies = new Companies();
        //    Pair = new Pair();
        //}

        public Guid Id { get; set; }
        public virtual Companies Companies { get; set; }
        public virtual Pair Pairs { get; set; }
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

using CryptoApp.Data.EntityAbstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApp.Data.Entities
{
    public class Transaction : Entity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid Market { get; set; }
        public Guid Coin { get; set; }
        [Column(TypeName = "decimal(27,8)")]
        public decimal Unit { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BuyingPrice { get; set; }
        public bool IsSold { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SellPrice { get; set; }


    }
}

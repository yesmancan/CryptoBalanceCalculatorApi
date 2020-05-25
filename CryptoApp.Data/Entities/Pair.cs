using CryptoApp.Data.EntityAbstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoApp.Data.Entities
{
    public class Pair : Entity
    {
        public Guid Id { get; set; }
        public string Normalized { get; set; } //BTC_TRY
        public string Denominator { get; set; } //TRY
        public string Numerator { get; set; }  //BTC
        public int Order { get; set; }
    }
}

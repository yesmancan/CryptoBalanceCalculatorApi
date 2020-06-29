using CryptoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoApp.Models.DTO
{
    public class UserTransactionOverview
    {
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Profit { get; set; }
        public decimal ProfitRatio { get; set; }

        public List<CoinByCoinOverview> CoinByCoin { get; set; } = new List<CoinByCoinOverview>();
    }
    public class CoinByCoinOverview
    {
        public Pair Coin { get; set; }
        public Companies Market { get; set; }

        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public decimal Profit { get; set; }
        public decimal ProfitRatio { get; set; }
        public decimal Unit { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoBalanceCalculatorApi.Models
{
    public class CryptoHistoryItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CoinName { get; set; } //LTC ,TRY

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; } // 0.10, 150
        public string PaymentType { get; set; } //Çekme Yatırma
        public string Company { get; set; } //BTCTURK, Koinim

        public List<Rate> Rates { get; set; } //[{"name":"USD","price":7.15},{"name":"BTC","price":60,095.854}]
        public int Order { get; set; }
        public DateTime CreateDt { get; set; }
        public int CreateBy { get; set; }
        public int Status { get; set; }

    }
}
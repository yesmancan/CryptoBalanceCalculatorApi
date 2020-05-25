using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoApp.Models.DTO
{
    public class BtcTurkCurrencyDTO
    {
        public string Pair { get; set; }
        public string PairNormalized { get; set; }
        public string TimeStamp { get; set; }
        public decimal Last { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Open { get; set; }
        public decimal Volume { get; set; }
        public decimal Average { get; set; }
        public decimal Daily { get; set; }
        public decimal DailyPercent { get; set; }
        public string DenominatorSymbol { get; set; }
        public string NumeratorSymbol { get; set; }
        public int Order { get; set; }
    }
}

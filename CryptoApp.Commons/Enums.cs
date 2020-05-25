using System;

namespace CryptoApp.Commons
{
    public class Enums
    {
        public enum Companies
        {
            BtcTurk,
            Koinim
        }

        public enum CurrencyServiceTypes
        {
            BtcTurk = 1,
            Koinim = 2
        }
        public enum EntityStatus
        {
            Active = 1,
            Passive = 0,
            Delete = -1
        }
        public enum Pair
        {
            BTC,
            TRY,
            USDT,
            LINK,
            ETH,
            ATOM,
            EOS,
            DASH,
            LTC,
            XTZ,
            NEO,
            XRP,
            XLM
        }
    }
}

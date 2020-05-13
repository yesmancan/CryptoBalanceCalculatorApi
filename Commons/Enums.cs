
using System;

namespace CryptoBalanceCalculatorApi.Commons
{
    public class Enums
    {
        public enum PaymentType
        {
            Buying = 1,
            Selling = 2
        }

        public enum EntityStatus
        {
            Deleted = -1,
            Passive = 0,
            Confirm = 1
        }
    }
}
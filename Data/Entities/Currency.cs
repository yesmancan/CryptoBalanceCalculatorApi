using CryptoBalanceCalculatorApi.Data.EntityAbstract;

namespace CryptoBalanceCalculatorApi.Data.Entities
{
    public class Currency : Entity
    {
        public long Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Symbol { get; set; }
    }
}
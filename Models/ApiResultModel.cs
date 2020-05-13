
namespace CryptoBalanceCalculatorApi.Models
{
    public class ApiResultModel<T> where T : class
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}
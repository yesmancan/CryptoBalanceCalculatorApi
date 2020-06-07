using CryptoApp.Commons;
using CryptoApp.Services.CurrencyServices.CompaniesData;

namespace CryptoApp.Services.CurrencyServices
{
    public interface ICurrencyObjectManager
    {
        ICompaniesDataService GetServices(Enums.CurrencyServiceTypes type);
    }
}

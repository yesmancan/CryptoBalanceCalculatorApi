using CryptoApp.Commons;
using CryptoApp.Data;
using CryptoApp.Services.CurrencyServices.CompaniesData;

namespace CryptoApp.Services.CurrencyServices
{
    public class CurrencyObjectManager : ICurrencyObjectManager
    {
        private readonly ApplicationDbContext _context;
        private readonly ICompaniesServices _companiesServices;
        private readonly IPairServices _pairServices;

        public CurrencyObjectManager(ApplicationDbContext context, ICompaniesServices companiesServices, IPairServices pairServices)
        {
            _context = context;
            _companiesServices = companiesServices;
            _pairServices = pairServices;
        }
        public ICompaniesDataService GetServices(Enums.CurrencyServiceTypes type) => GetCurrencyService(type);

        private ICompaniesDataService GetCurrencyService(Enums.CurrencyServiceTypes type)
        {
            return type switch
            {
                Enums.CurrencyServiceTypes.BtcTurk => new BTCTurkProServices(_context, _companiesServices, _pairServices),
                Enums.CurrencyServiceTypes.Koinim => new BTCTurkProServices(_context, _companiesServices, _pairServices),
                _ => new BTCTurkProServices(_context, _companiesServices, _pairServices),
            };
        }

    }
}

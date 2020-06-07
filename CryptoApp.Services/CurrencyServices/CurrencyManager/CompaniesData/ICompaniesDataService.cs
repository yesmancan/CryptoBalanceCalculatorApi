using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.CurrencyServices.CompaniesData
{
    public interface ICompaniesDataService
    {
        Task GetCoinsAsync();
    }
}

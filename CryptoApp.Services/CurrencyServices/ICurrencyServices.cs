using CryptoApp.Data.Entities;
using CryptoApp.Models;
using CryptoApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoApp.Services.CurrencyServices
{
    public interface ICurrencyServices
    {
        Task<List<Currency>> GetCurrenciesAsync();
        Task<ApiResultModel<List<CurrencyDTO>>> GetCurrenciesDTOAsync();
        Task<Currency> GetCurrencyAsync(Guid id);
    }
}

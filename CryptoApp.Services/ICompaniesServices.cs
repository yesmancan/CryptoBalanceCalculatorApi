using CryptoApp.Commons;
using CryptoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public interface ICompaniesServices
    {
        Task<List<Companies>> GetCompaniesAsync();
        Task<Companies> GetCompanyAsync(Enums.Companies companies);
        Task<Companies> GetCompanyAsync(Guid id);
    }
}

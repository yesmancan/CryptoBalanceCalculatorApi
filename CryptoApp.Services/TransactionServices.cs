using CryptoApp.Commons;
using CryptoApp.Data;
using CryptoApp.Data.Entities;
using CryptoApp.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoApp.Services
{
    public class TransactionServices : ITransactionServices
    {
        #region Constructor
        private readonly IRetrieverRepository _retrieverRepository;
        private readonly ICompaniesServices _companiesServices;
        private readonly IPairServices _pairServices;

        private readonly IMemoryCache _memoryCache;

        private readonly ApplicationDbContext _context;
        public TransactionServices(IRetrieverRepository retrieverRepository,
            ICompaniesServices companiesServices,
            IPairServices pairServices,
            IMemoryCache memoryCache,
            ApplicationDbContext context)
        {
            _retrieverRepository = retrieverRepository;
            _companiesServices = companiesServices;
            _pairServices = pairServices;
            _memoryCache = memoryCache;
            _context = context;
        }
        #endregion

        #region Base Method
        public async Task<IEnumerable<Transaction>> GetByUserIdAsync(Guid userId)
        {
            return await _retrieverRepository.GetAsync<Transaction>(x => x.UserId == userId);
        }
        public async Task<Transaction> GetAsync(Guid id)
        {
            return await _retrieverRepository.GetByIdAsync<Transaction>(id);
        }
        public Transaction Get(Guid id)
        {
            return _retrieverRepository.GetById<Transaction>(id);
        }
        public async Task Update(Guid id, Transaction item)
        {
            var _item = await GetAsync(id);
            if (_item == null)
            {
                throw new ArgumentException("Item not found");
            }

            try
            {
                _context.Update<Transaction>(item);
                _context.Entry<Transaction>(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex) when (!ItemExistsAsync(id))
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Transaction> Create(Transaction item)
        {
            await _context.AddAsync<Transaction>(item);
            _context.Entry<Transaction>(item).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return item;
        }
        public async Task<Transaction> Delete(Guid id)
        {
            var item = await GetAsync(id);
            if (item == null)
            {
                throw new ArgumentException("Item not found");
            }

            _context.Remove<Transaction>(item);
            _context.Entry<Transaction>(item).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return item;
        }
        private bool ItemExistsAsync(Guid id) => (Get(id)) != null;
        #endregion

        #region Calculate

        public async Task<UserTransactionOverview> TransactionCalculate(Guid userId)
        {
            IEnumerable<Transaction> transactions = await GetByUserIdAsync(userId);

            UserTransactionOverview overview = new UserTransactionOverview();

            var companies = await _companiesServices.GetCompaniesAsync();
            var pairs = await _pairServices.GetPairsAsync();

            foreach (Transaction transaction in transactions)
            {
                Currency currency = await _retrieverRepository.GetFirstAsync<Currency>(x => x.Companies.Id == transaction.Market && x.Pairs.Id == transaction.Coin);


                overview.NewPrice += currency.Last * transaction.Unit;
                overview.OldPrice += transaction.BuyingPrice * transaction.Unit;

                overview.CoinByCoin.Add(new CoinByCoinOverview()
                {
                    Coin = pairs.FirstOrDefault(x => x.Id == transaction.Coin),
                    Market = companies.FirstOrDefault(x => x.Id == transaction.Market),
                    NewPrice = currency.Last * transaction.Unit,
                    OldPrice = transaction.BuyingPrice * transaction.Unit,
                    Profit = (transaction.BuyingPrice * transaction.Unit) - (currency.Last * transaction.Unit),
                    ProfitRatio = (transaction.BuyingPrice * transaction.Unit) % (currency.Last * transaction.Unit)
                });

            }

            overview.Profit = overview.NewPrice - overview.OldPrice;

            return overview;
        }

        #endregion

        public async Task<List<Companies>> GetMarkets()
        {
            List<Companies> companies = await _memoryCache.GetOrCreateAsync<List<Companies>>("AllCompanies", async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(30);
                return (List<Companies>)await _retrieverRepository.GetAsync<Companies>(x => x.Status == (short)Enums.EntityStatus.Active);
            });

            return companies;
        }
        public async Task<IEnumerable<Currency>> GetCoinsByMarket(Guid companyId)
        {
            return await _retrieverRepository.GetAsync<Currency>(x => x.Companies.Id == companyId);
        }
    }
}

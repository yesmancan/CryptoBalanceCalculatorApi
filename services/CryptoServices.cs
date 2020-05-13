using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoBalanceCalculatorApi.Commons;
using CryptoBalanceCalculatorApi.Data;
using CryptoBalanceCalculatorApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoBalanceCalculatorApi.Services
{
    public class CryptoServices : IBaseServices<CryptoHistoryItem>
    {
        #region Constructor
        private readonly CryptoContext _context;

        public CryptoServices(CryptoContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IEnumerable<CryptoHistoryItem>> Get()
        {
            return await _context.CryptoHistoryItems.ToListAsync();
        }
        public async Task<CryptoHistoryItem> Get(long id)
        {
            return await _context.CryptoHistoryItems.FindAsync(id);
        }
        public async Task Update(long id, CryptoHistoryItem item)
        {
            var _item = await Get(id);
            if (_item == null)
            {
                throw new System.ArgumentException("Item not found");
            }

            _item.Name = item.Name;
            _item.Amount = item.Amount;
            _item.CoinName = item.CoinName;
            _item.Company = item.Company;
            _item.UpdatedBy = "HASH";
            _item.UpdateDt = item.UpdateDt;
            _item.Order = item.Order;
            _item.PaymentType = item.PaymentType;
            _item.Rates = item.Rates;
            _item.Status = (int)Enums.EntityStatus.Confirm;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex) when (!ItemExists(id))
            {
                throw new System.ArgumentException(ex.Message);
            }
        }
        public async Task<CryptoHistoryItem> Create(CryptoHistoryItem item)
        {
            CryptoHistoryItem _item = new CryptoHistoryItem
            {
                Name = item.Name,
                CoinName = item.CoinName,
                Company = item.Company,
                Order = item.Order,
                Rates = item.Rates,
                Amount = item.Amount,
                PaymentType = item.PaymentType,
                Status = (int)Enums.EntityStatus.Confirm,
                CreatedBy = "HASH",
                CreateDt = DateTime.Now
            };

            _context.CryptoHistoryItems.Add(_item);
            await _context.SaveChangesAsync();

            return _item;
        }

        public async Task<CryptoHistoryItem> Delete(long id)
        {
            var item = await _context.CryptoHistoryItems.FindAsync(id);
            if (item == null)
            {
                throw new System.ArgumentException("Item not found");
            }

            _context.CryptoHistoryItems.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }
        private bool ItemExists(long id) => _context.CryptoHistoryItems.Any(e => e.Id == id);
    }
}
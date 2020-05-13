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
    public class CurrencyServices : IBaseServices<Currency>
    {
        #region Constructor
        private readonly CryptoContext _context;

        public CurrencyServices(CryptoContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IEnumerable<Currency>> Get()
        {
            return await _context.Currencies.ToListAsync();
        }
        public async Task<Currency> Get(long id)
        {
            return await _context.Currencies.FindAsync(id);
        }
        public async Task Update(long id, Currency item)
        {
            var _item = await Get(id);
            if (_item == null)
            {
                throw new System.ArgumentException("Item not found");
            }
            _item.LongName = item.LongName;
            _item.ShortName = item.ShortName;
            _item.Symbol = item.Symbol;
            _item.UpdatedBy = "HASH";
            _item.UpdateDt = item.UpdateDt;
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
        public async Task<Currency> Create(Currency item)
        {
            Currency _item = new Currency
            {
                LongName = item.LongName,
                ShortName = item.ShortName,
                Symbol = item.ShortName,
                Status = (int)Enums.EntityStatus.Confirm,
                CreatedBy = "HASH",
                CreateDt = DateTime.Now
            };

            _context.Currencies.Add(_item);
            await _context.SaveChangesAsync();

            return _item;
        }

        public async Task<Currency> Delete(long id)
        {
            var item = await _context.Currencies.FindAsync(id);
            if (item == null)
            {
                throw new System.ArgumentException("Item not found");
            }

            _context.Currencies.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }
        private bool ItemExists(long id) => _context.Currencies.Any(e => e.Id == id);
    }
}
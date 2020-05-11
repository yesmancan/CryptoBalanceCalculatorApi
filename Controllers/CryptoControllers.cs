using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CryptoBalanceCalculatorApi.Models;
using CryptoBalanceCalculatorApi.Models.DTO;

namespace CryptoBalanceCalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly CryptoContext _context;

        public CryptoController(CryptoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CryptoHistoryItem>>> Get()
        {
            return await _context.CryptoHistoryItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CryptoHistoryItem>> GetItems(long id)
        {
            var item = await _context.CryptoHistoryItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(long id, CryptoHistoryItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            var _item = await _context.CryptoHistoryItems.FindAsync(id);
            if (_item == null)
            {
                return NotFound();
            }

            _item.Name = item.Name;
            _item.Amount = item.Amount;
            _item.CoinName = item.CoinName;
            _item.Company = item.Company;
            _item.CreateBy = item.CreateBy;
            _item.CreateDt = item.CreateDt;
            _item.Order = item.Order;
            _item.PaymentType = item.PaymentType;
            _item.Rates = item.Rates;
            _item.Status = item.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CryptoHistoryItem>> CreateItem(CryptoHistoryItem item)
        {
            var _item = new CryptoHistoryItem
            {
                Name = item.Name,
                CoinName = item.CoinName,
                Company = item.Company,
                Order = item.Order,
                Rates = item.Rates,
                Amount = item.Amount,
                PaymentType = item.PaymentType,
                Status = item.Status,
                CreateBy = 1,
                CreateDt = DateTime.Now
            };

            _context.CryptoHistoryItems.Add(_item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItems), new { id = _item.Id }, _item);
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>  
        [HttpDelete("{id}")]
        public async Task<ActionResult<CryptoHistoryItem>> DeleteTodoItem(long id)
        {
            var item = await _context.CryptoHistoryItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.CryptoHistoryItems.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }

        private bool ItemExists(long id) => _context.CryptoHistoryItems.Any(e => e.Id == id);
    }
}

using CryptoApp.Commons;
using CryptoApp.Data.Entities;
using CryptoApp.Models;
using CryptoApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoApp.Controllers
{
    public class TransactionController : Controller
    {
        #region Constructor
        private readonly ITransactionServices _transactionServices;
        private readonly IPairServices _pairServices;

        public TransactionController(ITransactionServices transactionServices, IPairServices pairServices)
        {
            _transactionServices = transactionServices;
            _pairServices = pairServices;
        }
        #endregion

        [Route("transactions")]
        public async Task<IActionResult> Get()
        {
            try
            {

                IEnumerable<Transaction> data = await _transactionServices.GetByUserIdAsync(User.GetLoggedInUserId<Guid>());
                ViewBag.Pairs = await _pairServices.GetPairsAsync();
                ViewBag.Markets = await _transactionServices.GetMarkets();
                return View(data);
            }
            catch (System.Exception ex)
            {
                return View(ex);
            }
        }
        [Route("transaction/create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Markets = await _transactionServices.GetMarkets();
            ViewBag.Coins = await _pairServices.GetPairsAsync();


            return View();
        }
        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("transaction/create")]
        public async Task<IActionResult> Create([Bind("Market,Coin,Unit,BuyingPrice,IsSold,SellPrice")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.Id = Guid.NewGuid();
                transaction.UserId = User.GetLoggedInUserId<Guid>();
                transaction.CreatedBy = transaction.UserId.ToString();
                transaction.CreateDt = DateTime.Now;
                transaction.Status = (short)Enums.EntityStatus.Active;

                await _transactionServices.Create(transaction);
                return Redirect("/transactions");
            }
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("transaction/delete/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _transactionServices.Delete(id);
            return Redirect("/transactions");
        }
        [Route("transaction/calculate")]
        public async Task<IActionResult> Calculate()
        {
            try
            {
                var data = await _transactionServices.TransactionCalculate(User.GetLoggedInUserId<Guid>());

                return View(data);
            }
            catch (System.Exception ex)
            {
                return View(ex);
            }
        }
    }
}

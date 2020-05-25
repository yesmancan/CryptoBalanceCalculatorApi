using CryptoApp.Commons;
using CryptoApp.Data.Entities;
using CryptoApp.Models;
using CryptoApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Transaction> data = await _transactionServices.GetByUserIdAsync(User.GetLoggedInUserId<Guid>());

                return View(data);
            }
            catch (System.Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Markets = await _transactionServices.GetMarkets();
            ViewBag.Coins = await _pairServices.GetPairsAsync();


            return View();
        }
        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                return RedirectToAction("Index");
            }
            return View(transaction);
        }
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

using CryptoApp.Commons;
using CryptoApp.Data.Entities;
using CryptoApp.Models;
using CryptoApp.Models.DTO;
using CryptoApp.Services;
using CryptoApp.Services.CurrencyServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class TransactionApiController : ControllerBase
    {
        #region Constructor
        private readonly ITransactionServices _transactionServices;
        private readonly ICurrencyServices _currencyServices;
        private readonly IPairServices _pairServices;

        public TransactionApiController(ITransactionServices transactionServices, IPairServices pairServices, ICurrencyServices currencyServices)
        {
            _transactionServices = transactionServices;
            _currencyServices = currencyServices;
            _pairServices = pairServices;
        }
        #endregion

        #region transactions
        [Route("transactions")]
        public async Task<ApiResultModel<List<TransactionDTO>>> GetTransactions(Guid userId)
        {
            try
            {
                IEnumerable<Transaction> data = await _transactionServices.GetByUserIdAsync(userId);
                var pairs = await _pairServices.GetPairsAsync();
                var markets = await _transactionServices.GetMarkets();
                List<TransactionDTO> returnData = new List<TransactionDTO>();
                foreach (Transaction transaction in data)
                {
                    var _coin = pairs.FirstOrDefault(x => x.Id == transaction.Coin);
                    var _market = markets.FirstOrDefault(x => x.Id == transaction.Market);
                    returnData.Add(new TransactionDTO()
                    {
                        Id = transaction.Id,
                        BuyingPrice = transaction.BuyingPrice,
                        SellPrice = transaction.SellPrice,
                        IsSold = transaction.IsSold,
                        Unit = transaction.Unit,
                        Coin = _coin,
                        CoinId = _coin.Id,
                        Market = _market,
                        MarketId = _market.Id,
                        UserId = transaction.UserId,
                        Status = transaction.Status,
                        CreateDt = transaction.CreateDt
                    });
                }

                return new ApiResultModel<List<TransactionDTO>>()
                {
                    Data = returnData,
                    Success = true,
                    Message = "Success",
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new ApiResultModel<List<TransactionDTO>>()
                {
                    Data = new List<TransactionDTO>(),
                    Success = false,
                    Message = ex.Message,
                    Code = ex.HResult
                };
            }
        }

        [Route("transaction/markets")]
        public async Task<ApiResultModel<List<Companies>>> GetMarkets()
        {
            try
            {
                var market = await _transactionServices.GetMarkets();
                return new ApiResultModel<List<Companies>>()
                {
                    Data = market,
                    Success = false,
                    Message = "Success",
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new ApiResultModel<List<Companies>>()
                {
                    Data = new List<Companies>(),
                    Success = false,
                    Message = ex.Message,
                    Code = ex.HResult
                };
            }
        }
        [Route("transaction/pairs")]
        public async Task<ApiResultModel<List<Pair>>> GetPairs()
        {
            try
            {
                var pairs = await _pairServices.GetPairsAsync();
                return new ApiResultModel<List<Pair>>()
                {
                    Data = pairs,
                    Success = false,
                    Message = "Success",
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new ApiResultModel<List<Pair>>()
                {
                    Data = new List<Pair>(),
                    Success = false,
                    Message = ex.Message,
                    Code = ex.HResult
                };
            }
        }
        // POST: Movies/Create
        [HttpPost]
        [Route("transaction/create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ApiResultModel<Transaction>> Create([FromBody]Transaction transaction, Guid userId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    transaction.Id = Guid.NewGuid();
                    transaction.UserId = userId;
                    transaction.CreatedBy = transaction.UserId.ToString();
                    transaction.CreateDt = DateTime.Now;
                    transaction.Status = (short)Enums.EntityStatus.Active;

                    await _transactionServices.Create(transaction);
                    return new ApiResultModel<Transaction>()
                    {
                        Data = transaction,
                        Success = true,
                        Message = "Success",
                        Code = 200
                    };
                }

                return new ApiResultModel<Transaction>()
                {
                    Data = transaction,
                    Success = false,
                    Message = JsonConvert.SerializeObject(ModelState.Values),
                    Code = 500
                };
            }
            catch (Exception ex)
            {
                return new ApiResultModel<Transaction>()
                {
                    Data = new Transaction(),
                    Success = false,
                    Message = ex.Message,
                    Code = ex.HResult
                };
            }
        }

        [HttpPost]
        [Route("transaction/delete/{id:Guid}")]
        public async Task<ApiResultModel<dynamic>> Delete(Guid id)
        {
            try
            {
                await _transactionServices.Delete(id);

                return new ApiResultModel<dynamic>()
                {
                    Data = 1,
                    Success = true,
                    Message = "Success",
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new ApiResultModel<dynamic>()
                {
                    Data = -1,
                    Success = false,
                    Message = ex.Message,
                    Code = ex.HResult
                };
            }
        }
        [Route("transaction/calculate")]
        public async Task<ApiResultModel<UserTransactionOverview>> Calculate(Guid userId)
        {
            try
            {
                var data = await _transactionServices.TransactionCalculate(userId);

                return new ApiResultModel<UserTransactionOverview>()
                {
                    Data = data,
                    Success = true,
                    Message = "Success",
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new ApiResultModel<UserTransactionOverview>()
                {
                    Data = new UserTransactionOverview(),
                    Success = false,
                    Message = ex.Message,
                    Code = ex.HResult
                };
            }
        }
        #endregion

        #region Currencies
        [Route("currencies")]
        public async Task<ApiResultModel<List<CurrencyDTO>>> GetAllCurrencies() => await _currencyServices.GetCurrenciesDTOAsync();
        #endregion
    }
}

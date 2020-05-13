using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CryptoBalanceCalculatorApi.Models;
using Newtonsoft.Json;
using System.Net;
using CryptoBalanceCalculatorApi.Data;
using CryptoBalanceCalculatorApi.Data.Entities;
using CryptoBalanceCalculatorApi.Commons;
using CryptoBalanceCalculatorApi.Services;

namespace CryptoBalanceCalculatorApi.Controllers
{
    [Route("api/currency")]
    [ApiController]
    public class CurrencyControllers : ControllerBase
    {
        #region Constructor
        private readonly CurrencyServices _currencyServices;

        public CurrencyControllers(CurrencyServices currencyServices)
        {
            _currencyServices = currencyServices;
        }
        #endregion

        [HttpGet]
        public async Task<ApiResultModel<IEnumerable<Currency>>> Get()
        {
            try
            {
                IEnumerable<Currency> data = await _currencyServices.Get();

                return new ApiResultModel<IEnumerable<Currency>>()
                {
                    Succeed = true,
                    Message = "Succeed",
                    Data = data
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<IEnumerable<Currency>>()
                {
                    Succeed = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<ApiResultModel<Currency>> GetItems(long id)
        {
            try
            {
                Currency item = await _currencyServices.Get(id);
                if (item == null)
                {
                    return new ApiResultModel<Currency>()
                    {
                        Succeed = true,
                        Message = "Empty",
                        Data = null
                    };
                }

                return new ApiResultModel<Currency>()
                {
                    Succeed = true,
                    Message = "Succeed",
                    Data = item
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<Currency>()
                {
                    Succeed = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        [HttpPut("{id}")]
        public async Task<ApiResultModel<Currency>> UpdateItem(long id, Currency item)
        {
            if (id != item.Id)
            {
                return new ApiResultModel<Currency>()
                {
                    Message = "Id not equal item id",
                    Succeed = false,
                    Data = item
                };
            }
            try
            {
                await _currencyServices.Update(id, item);
                return new ApiResultModel<Currency>()
                {
                    Message = "Succeed",
                    Succeed = true,
                    Data = item
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<Currency>()
                {
                    Message = ex.Message,
                    Succeed = false,
                    Data = item
                };
            }
        }

        /// <summary>
        /// Creates a Currency.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CreateItem
        ///     {
        ///       
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created Currency</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ApiResultModel<Currency>> CreateItem(Currency item)
        {
            try
            {
                Currency _item = await _currencyServices.Create(item);
                return new ApiResultModel<Currency>()
                {
                    Message = "Succeed",
                    Succeed = true,
                    Data = _item
                };

            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<Currency>()
                {
                    Message = ex.Message,
                    Succeed = false,
                    Data = item
                };
            }
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>  
        [HttpDelete("{id}")]
        public async Task<ApiResultModel<Currency>> DeleteTodoItem(long id)
        {
            try
            {
                Currency item = await _currencyServices.Delete(id);
                return new ApiResultModel<Currency>()
                {
                    Message = "Succeed",
                    Succeed = true,
                    Data = item
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<Currency>()
                {
                    Message = ex.Message,
                    Succeed = false,
                    Data = null
                };
            }
        }

    }
}

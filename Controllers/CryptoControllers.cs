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
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        #region Constructor
        private readonly CryptoServices _cryptoServices;

        public CryptoController(CryptoServices cryptoServices)
        {
            _cryptoServices = cryptoServices;
        }
        #endregion

        [HttpGet]
        public async Task<ApiResultModel<IEnumerable<CryptoHistoryItem>>> Get()
        {
            try
            {
                IEnumerable<CryptoHistoryItem> data = await _cryptoServices.Get();

                return new ApiResultModel<IEnumerable<CryptoHistoryItem>>()
                {
                    Succeed = true,
                    Message = "Succeed",
                    Data = data
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<IEnumerable<CryptoHistoryItem>>()
                {
                    Succeed = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<ApiResultModel<CryptoHistoryItem>> GetItems(long id)
        {
            try
            {
                CryptoHistoryItem item = await _cryptoServices.Get(id);
                if (item == null)
                {
                    return new ApiResultModel<CryptoHistoryItem>()
                    {
                        Succeed = true,
                        Message = "Empty",
                        Data = null
                    };
                }

                return new ApiResultModel<CryptoHistoryItem>()
                {
                    Succeed = true,
                    Message = "Succeed",
                    Data = item
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<CryptoHistoryItem>()
                {
                    Succeed = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        [HttpPut("{id}")]
        public async Task<ApiResultModel<CryptoHistoryItem>> UpdateItem(long id, CryptoHistoryItem item)
        {
            if (id != item.Id)
            {
                return new ApiResultModel<CryptoHistoryItem>()
                {
                    Message = "Id not equal item id",
                    Succeed = false,
                    Data = item
                };
            }
            try
            {
                await _cryptoServices.Update(id, item);
                return new ApiResultModel<CryptoHistoryItem>()
                {
                    Message = "Succeed",
                    Succeed = true,
                    Data = item
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<CryptoHistoryItem>()
                {
                    Message = ex.Message,
                    Succeed = false,
                    Data = item
                };
            }
        }

        /// <summary>
        /// Creates a CryptoHistoryItem.
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
        /// <returns>A newly created CryptoHistoryItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ApiResultModel<CryptoHistoryItem>> CreateItem(CryptoHistoryItem item)
        {
            try
            {
                CryptoHistoryItem _item = await _cryptoServices.Create(item);
                return new ApiResultModel<CryptoHistoryItem>()
                {
                    Message = "Succeed",
                    Succeed = true,
                    Data = _item
                };

            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<CryptoHistoryItem>()
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
        public async Task<ApiResultModel<CryptoHistoryItem>> DeleteItem(long id)
        {
            try
            {
                CryptoHistoryItem item = await _cryptoServices.Delete(id);
                return new ApiResultModel<CryptoHistoryItem>()
                {
                    Message = "Succeed",
                    Succeed = true,
                    Data = item
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResultModel<CryptoHistoryItem>()
                {
                    Message = ex.Message,
                    Succeed = false,
                    Data = null
                };
            }
        }

    }
}

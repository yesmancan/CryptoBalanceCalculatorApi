using CryptoApp.Services.CurrencyServices;
using CryptoApp.Services.CurrencyServices.CompaniesData;
using Hangfire;
using Hangfire.Common;
using Hangfire.States;
using System;
using System.Collections.Generic;
using System.Text;
using static CryptoApp.Commons.Enums;

namespace CryptoApp.Services
{
    public class HangfireServices : IHangfireServices
    {
        private readonly IBackgroundJobClient _backgroundJobs;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly ICurrencyObjectManager _currencyObjectManager;
        private readonly ICompaniesDataService _btcTurkServices;


        public HangfireServices(IBackgroundJobClient backgroundJobs, IRecurringJobManager recurringJobManager, ICurrencyObjectManager currencyObjectManager)
        {
            _backgroundJobs = backgroundJobs;
            _recurringJobManager = recurringJobManager;
            _currencyObjectManager = currencyObjectManager;

            _btcTurkServices = _currencyObjectManager.GetServices(CurrencyServiceTypes.BtcTurk);
        }
        public void FireJob()
        {
            _recurringJobManager.AddOrUpdate("Hello World", () => Console.WriteLine("Hello world from Hangfire!"), Cron.Hourly);

            _recurringJobManager.AddOrUpdate("BtcTurk Data Async", () => _btcTurkServices.GetCoinsAsync(), "1 * * * *");

            //_backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
        }
    }
}

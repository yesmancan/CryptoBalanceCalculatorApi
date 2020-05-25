using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoApp.Services
{
    public interface IHangfireServices
    {
        void FireJob();
    }
}

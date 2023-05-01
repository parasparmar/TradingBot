﻿using Binance.Net.Objects;
using Bybit.Net.Objects;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Okex.Net.Objects.Core;

namespace TradingBot.HttpClients.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OkexClientOptions.Default.ApiCredentials = new OkexApiCredentials("API-KEY", "API-SECRET", "API-PASS-PHRASE");

            BybitClientOptions.Default.ApiCredentials = new ApiCredentials("API-KEY", "API-SECRET");

            BinanceClientOptions.Default.ApiCredentials = new BinanceApiCredentials("API-KEY", "API-SECRET");

            services.AddHttpClients();
        }
    }
}

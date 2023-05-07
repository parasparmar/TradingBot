﻿using Okex.Net;
using Okex.Net.Enums;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.HttpClients.Okx.Extensions;

namespace TradingBot.TradeAdapters
{
    public class OkxTradeAdapter : ITradeAdapter
    {
        private readonly OkexClient _client;

        public OkxTradeAdapter(OkexClient client)
        {
            _client = client;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot, instrumentId: code);
            var ticker = response?.Data?.SingleOrDefault();

            return ticker != null ? ticker.ToStockTicker() : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot);

            return response?.Data?.Select(instrument => instrument.ToStockTicker()) ?? Enumerable.Empty<StockTicker>();
        }

        public Task<IEnumerable<IQuote>> GetQuotes(string code, Interval interval, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}

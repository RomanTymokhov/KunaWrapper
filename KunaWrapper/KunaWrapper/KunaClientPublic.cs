using System.Threading.Tasks;
using System.Collections.Generic;
using KunaWrapper.DataLayer.ReciveData;
using KunaWrapper.DataLayer.RequestData;

namespace KunaWrapper
{
    public class KunaClientPublic : BaseClient
    {
        public KunaClientPublic() : base() { }

        public async Task<long> ReturnTimestampAsync() => 
                await GetJsonAsync<long>(new RequestTimestamp());

        public async Task<TickerLine> ReturnTickerLineAsync(string pairId) =>
                await GetJsonAsync<TickerLine>(new RequestTickerline(pairId));

        /// <summary>
        /// Returns detailed information about the depth
        /// </summary>
        /// <param name="pairId">Currency Pair Identifikator</param>
        /// <returns>OrderBook</returns>
        public async Task<OrderBook> ReturnOrderBookAsync(string pairId) =>
                await GetJsonAsync<OrderBook>(new RequestOrderbook(pairId));

        /// <summary>
        /// Returns simplified information about the depth: price & volume
        /// </summary>
        /// <param name="pairId"></param>
        /// <returns>Depthreturns>
        public async Task<Depth> ReturnDepthAsync(string pairId) =>
                await GetJsonAsync<Depth>(new RequestDepth(pairId));

        /// <summary>
        /// Return Trade History
        /// </summary>
        /// <param name="pairId">Currency Pair Identifikator</param>
        /// <param name="limit">Limit Trades in History max = 1000</param>
        /// <returns>List of Trade</returns>
        public async Task<List<Trade>> ReturnTradeHistoryAsync(string pairId, ushort limit = 10) =>
                await GetJsonAsync<List<Trade>>(new RequestTradeHistory(pairId, limit));

        /// <summary>
        /// Return Candle Charte, setuping paremetrs
        /// </summary>
        /// <param name="pairId">Currency Pair Identifikator</param>
        /// <param name="period">Candle Period: _15_min, _3-_min, _1_hour, _4_hour, _1_day, _1_week</param>
        /// <param name="limit">Candle Quantity</param>
        /// <returns>Chart</returns>
        public async Task<Chart> ReturnChartDataAsync(string pairId, string period, ushort limit) =>
                await GetJsonAsync<Chart>(new RequestChartData(pairId, period, limit));
    }
}

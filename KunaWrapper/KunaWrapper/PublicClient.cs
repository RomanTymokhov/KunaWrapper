using System.Threading.Tasks;
using System.Collections.Generic;
using KunaWrapper.DataLayer.ReciveData;
using KunaWrapper.DataLayer.RequestData;

namespace KunaWrapper
{
    public class PublicClient : BaseClient
    {
        public PublicClient() : base() { }


        public async Task<long> ReturnTimestampAsync() => 
                await GetJsonAsync<long>(new RequestTimestamp());

        public async Task<TickerLine> ReturnTickerLineAsync(string pairId) =>
                await GetJsonAsync<TickerLine>(new RequestTickerline(pairId));

        public async Task<OrderBook> ReturnOrderBookAsync(string pairId) =>
                await GetJsonAsync<OrderBook>(new RequestOrderbook(pairId));

        public async Task<Depth> ReturnDepthAsync(string pairId) =>
                await GetJsonAsync<Depth>(new RequestDepth(pairId));

        /// <summary>
        /// Return Trade History
        /// </summary>
        /// <param name="pairId">Currency Pair Identifikator</param>
        /// <param name="limit">Limit Trades in History</param>
        /// <returns>List of Trade</returns>
        public async Task<List<Trade>> ReturnTradeHistoryAsync(string pairId, ushort limit = 1000) =>
                await GetJsonAsync<List<Trade>>(new RequestTradeHistory(pairId, limit));

        public async Task<List<List<float>>> ReturnChartDataAsync(string pairId, string period, ushort limit) =>
                await GetJsonAsync<List<List<float>>>(new RequestChartData(pairId, period, limit));
    }
}

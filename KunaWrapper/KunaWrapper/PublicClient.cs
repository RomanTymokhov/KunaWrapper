using System.Threading.Tasks;
using System.Collections.Generic;
using KunaWrapper.DataLayer.Enums;
using KunaWrapper.DataLayer.ReciveData;
using KunaWrapper.DataLayer.RequestData;
using KunaWrapper.DataLayer.RequestData.FrameData;

namespace KunaWrapper
{
    public class PublicClient : BaseClient
    {
        public PublicClient() : base() { }


        public async Task<long> GetTimestampAsync() => 
                await GetJsonAsync<long>(new RequestTimestamp());

        public async Task<TickerLine> GetTickerLineAsync(MarketPair pair) =>
                await GetJsonAsync<TickerLine>(new RequestTickerline(pair));

        public async Task<OrderBook> GetOrderBookAsync(MarketPair pair) =>
                await GetJsonAsync<OrderBook>(new RequestOrderbook(pair));

        public async Task<Depth> GetDepthAsync(MarketPair pair) =>
                await GetJsonAsync<Depth>(new RequestDepth(pair));

        public async Task<List<Trade>> GetTradesAsync(MarketPair pair, ushort limit = 1000) =>
                await GetJsonAsync<List<Trade>>(new RequestTrades(pair, limit));

        public async Task<List<List<float>>> GetChartDataAsync(ChartFrame frame, MarketPair pair) =>
                await GetJsonAsync<List<List<float>>>(new RequestChartData(pair, frame));
    }
}

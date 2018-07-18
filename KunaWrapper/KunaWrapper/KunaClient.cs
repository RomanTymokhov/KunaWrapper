﻿using KunaWrapper.DataLayer.Enums;
using KunaWrapper.DataLayer.ReciveData;
using KunaWrapper.DataLayer.RequestData;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;
using System.Linq;
using System.Web;

namespace KunaWrapper
{
    public class KunaClient
    {
        private readonly HttpClient httpClient;

        private const string baseAddress = "https://kuna.io";

        private readonly string publicKey;
        private readonly string secretKey;

        public KunaClient(string pubKey, string secKey)
        {
            publicKey = pubKey;
            secretKey = secKey;

            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress)};
        }

        protected async Task<T> GetJsonAsync<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed
            
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        protected async Task<T> PostJsonAsync<T>(string requestUri, string requestData)
        {
            var req = baseAddress + requestUri + "?" + requestData; //для отлади

            var response = await httpClient.PostAsync(requestUri,
                new StringContent(requestData, Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed
            
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        #region Private Methods

        public async Task<KunaPerson> GetKunaPersonInfoAsync()
        {
            var args = new RequestObjectKunaPerson(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds());

            var url = new StringBuilder(KunaMethod.KunaPerson);
            url.AppendFormat("?{0}", args.ToString());

            return await GetJsonAsync<KunaPerson>(url.ToString());
        }

        public async Task<List<Order>> GetKunaPersonActiveOrdersAsync(MarketPair pair)
        {
            var args = new RequestObjectKunaPersonOrders(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds(), pair);

            var url = new StringBuilder(KunaMethod.KunaPersonOrders);
            url.AppendFormat("?{0}", args.ToString());

            return await GetJsonAsync<List<Order>>(url.ToString());
        }

        public async Task<List<Trade>> GetKunaPersonTradesAsync(MarketPair pair)
        {
            var args = new RequestObjectKunaPersonTrades(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds(), pair);

            var url = new StringBuilder(KunaMethod.KunaPersonTrades);
            url.AppendFormat("?{0}", args.ToString());

            return await GetJsonAsync<List<Trade>>(url.ToString());
        }

        public async Task<Order> PlaceOrderAsync(OrderSide orderSide, decimal volume, MarketPair pair, decimal coinPrice)
        {
            var args = new RequestObjectPlaceOrder(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds(), orderSide, volume, pair, coinPrice);
            
            return await PostJsonAsync<Order>(KunaMethod.PlaceOrder, args.ToString());
        }

        public async Task<Order> CancelOrderAsync(uint orderId)
        {
            var args = new RequestObjectCancelOrder(publicKey, secretKey, DateTimeOffset.Now.ToUnixTimeMilliseconds(), orderId);

            return await PostJsonAsync<Order>(KunaMethod.CancelOrder, args.ToString());
        }

        #endregion

        #region Public Methods

        private  async Task<long> GetTimestampAsync()
        {
            return await GetJsonAsync<long>(KunaMethod.Timestamp);
        }

        public async Task<TickerLine> GetTickerLineAsync(MarketPair pair)
        {
            // get request uri
            var url = new StringBuilder();
            url.AppendFormat(KunaMethod.Tickerline, pair.ToString());

            return await GetJsonAsync<TickerLine>(url.ToString());
        }

        public async Task<OrderBook> GetOrderBookAsync(MarketPair pair)
        {
            var url = new StringBuilder();
            url.AppendFormat(KunaMethod.Orderbook, pair.ToString());

            return await GetJsonAsync<OrderBook>(url.ToString());
        }

        public async Task<List<Trade>> GetTradesAsync(MarketPair pair)
        {
            var url = new StringBuilder();
            url.AppendFormat(KunaMethod.Trades, pair.ToString());

            return await GetJsonAsync<List<Trade>>(url.ToString());
        }

        public async Task<Depth> GetDepthAsync(MarketPair pair)
        {
            var url = new StringBuilder();
            url.AppendFormat(KunaMethod.Depth, pair.ToString());

            return await GetJsonAsync<Depth>(url.ToString());
        }

        #endregion
    }
}

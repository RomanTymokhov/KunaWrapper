﻿using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using KunaWrapper.DataLayer.KunaException;
using KunaWrapper.DataLayer.RequestData;
using Newtonsoft.Json;

namespace KunaWrapper
{
    public abstract class BaseClient : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly AuthData signParams;

        public BaseClient()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://kuna.io") };
        }
        public BaseClient(string pubKey, string secKey) : this()
        {
            signParams = new AuthData(pubKey, secKey);
        }

        protected async Task<T> GetJsonAsync<T>(BaseRequest request)
        {
            var response = await httpClient.GetAsync(request.ToString()).ConfigureAwait(false);

            EnsureSuccessStatusCodeAsync(response);

            return await UnpackingResponseAsync<T>(response);
        }

        protected async Task<T> PostJsonAsync<T>(BaseRequest request)
        {
            var response = await httpClient.PostAsync(request.Url,
                new StringContent(request.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            EnsureSuccessStatusCodeAsync(response);

            return await UnpackingResponseAsync<T>(response);
        }

        private async Task<T> UnpackingResponseAsync<T>(HttpResponseMessage responseMessage)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        private void EnsureSuccessStatusCodeAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                KunaException.CheckException(response);
            }
        }

        public void Dispose() => httpClient.Dispose();
    }
}

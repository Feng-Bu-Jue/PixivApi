using EasyHttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace PixivApi.Net
{
    public class PixivHttpClientProvier : IHttpClientProvider
    {

        private readonly object _syncObject = new object();
        private HttpMessageInvoker _httpClient;
        private bool _enableDirectConnect;

        public PixivHttpClientProvier(bool enableDirectConnect = false)
        {
            this._enableDirectConnect = enableDirectConnect;
        }

        public HttpMessageInvoker GetClient(HttpClientSettings clientSetting, params DelegatingHandler[] handlers)
        {
            if (_httpClient == null)
            {
                lock (_syncObject)
                {
                    if (_httpClient == null)
                    {
                        _httpClient = GetClientInernal(clientSetting, handlers);
                    }
                }
            }
            return _httpClient;
        }

        private HttpMessageInvoker GetClientInernal(HttpClientSettings clientSetting, params DelegatingHandler[] handlers)
        {
            var defaultHandlers = new DelegatingHandler[]
            {
                new PixivHeaderValueHandler()
            };
            handlers = handlers == null ? defaultHandlers : handlers.Concat(defaultHandlers).ToArray();

            var httpClient = SimpleHttpClient.HttpClientFactory.Create((handler) =>
            {
                handler.Settings = new SimpleHttpClient.HttpConnectionSettings()
                {
                    AutomaticDecompression = DecompressionMethods.GZip
                };
                if (_enableDirectConnect)
                {
                    handler.Settings.EndPointProvider = new PixivEndPointProvider();
                }
            }, handlers);

            if (clientSetting != null)
            {
                httpClient.Timeout = clientSetting.Timeout;
            }

            return httpClient;
        }
    }
}

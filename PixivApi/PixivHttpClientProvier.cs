using EasyHttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace PixivApi
{
    public class PixivHttpClientProvier : IHttpClientProvider
    {
        private readonly object _syncObject = new object();
        private HttpMessageInvoker _httpClient;

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
                handler.EndPointProvider = new PixivEndPointProvider();
                handler.AutomaticDecompression = DecompressionMethods.GZip;
            }, handlers);

            if (clientSetting != null)
            {
                httpClient.Timeout = clientSetting.Timeout;
            }

            return httpClient;
        }
    }
}

using EasyHttpClient;
using PixivApi.Net.API.Attributes;
using PixivApi.Net.OAuth;
using System;

namespace PixivApi.Net
{
    public class PixivApiClientFactory
    {
        private readonly EasyHttpClientFactory _innerFactory;

        public PixivApiClientFactory(string username, string password)
            : this(username, password, new JsonFileAuthStore(), TimeSpan.FromSeconds(120))
        {

        }

        public PixivApiClientFactory(string username, string password, IAuthStore authStore, TimeSpan timeout) : base()
        {
            var config = new EasyClientConfig();
            config.Host = new Uri("https://app-api.pixiv.net");
            config.HttpClientProvider = new PixivHttpClientProvier();
            config.HttpClientSettings.Timeout = timeout;
            config.HttpClientSettings.ActionFilters.Add(new ResultActionFilterAttribute());
            config.HttpClientSettings.OAuth2ClientHandler = new PixivOAuthHandler(
                "https://oauth.secure.pixiv.net/",
                new PixivOAuthRequest
                {
                    ClientId = "MOBrBDS8blbauoSck0ZfDbtuzpyT",
                    ClientSecret = "lsACyCD94FhDUtGTXi3QzcFE2uU1hqtDaKeqrdwj",
                    GrantType = "password",
                    GetSecureUrl = "1",
                    Username = username,
                    Password = password,
                },
                authStore
            );

            _innerFactory = new EasyHttpClientFactory
            {
                Config = config
            };
        }

        public T Create<T>()
        {
            return _innerFactory.Create<T>();
        }
    }

}

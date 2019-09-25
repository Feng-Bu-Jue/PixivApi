using EasyHttpClient;
using PixivApi.OAuth;
using System;

namespace PixivApi
{
    public class PixivApiClientFactory : EasyHttpClientFactory
    {
        public PixivApiClientFactory(string username, string password)
            : this(username, password, new TextFileAuthStore(), TimeSpan.FromSeconds(120))
        {

        }

        public PixivApiClientFactory(string username, string password, IAuthStore authStore, TimeSpan timeout) : base()
        {
            this.Config.Host = new Uri("https://app-api.pixiv.net");
            this.Config.HttpClientProvider = new PixivHttpClientProvier();
            this.Config.HttpClientSettings.Timeout = timeout;
            this.Config.HttpClientSettings.OAuth2ClientHandler = new PixivOAuthHandler(
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
        }
    }

}

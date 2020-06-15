﻿using EasyHttpClient;
using EasyHttpClient.Attributes;
using EasyHttpClient.Attributes.Parameter;
using EasyHttpClient.OAuth2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PixivApi.Net.OAuth
{
    public class PixivOAuthHandler : IOAuth2ClientHandler
    {
        private readonly static object _syncObject = new object();

        private readonly IOAuth2Api _oAuth2Api;
        private readonly IAuthStore _authStore;
        private readonly string _oAuth2TokenPath;
        private Task<PixivOAuthResponse> authTokenTask;
        private Task<PixivOAuthResponse> refreshTokenTask;

        private readonly PixivOAuthRequest _request;
        public PixivOAuthHandler(string loginHost, PixivOAuthRequest request, IAuthStore authStore, IHttpClientProvider httpClientProvider)
            : this(loginHost, "auth/token", request, authStore, httpClientProvider)
        {

        }

        public PixivOAuthHandler(string loginHost, string oAuth2TokenPath, PixivOAuthRequest request, IAuthStore authStore, IHttpClientProvider httpClientProvider)
        {
            var factory = new EasyHttpClientFactory();
            factory.Config.HttpClientProvider = httpClientProvider;

            this._request = request;
            this._oAuth2TokenPath = oAuth2TokenPath.Trim('/');
            this._oAuth2Api = factory.Create<IOAuth2Api>(loginHost);
            this._authStore = authStore;
        }

        public bool IsUnauthorized(HttpResponseMessage httpResponse)
        {
            return
                httpResponse.StatusCode == HttpStatusCode.Unauthorized
                ||
                httpResponse.StatusCode == HttpStatusCode.BadRequest;
        }

        public async Task SetAccessToken(HttpRequestMessage originalHttpRequestMessage)
        {
            authTokenTask = TaskWhenEnd(authTokenTask, () => DoAuthToken());
            var authResponse = await authTokenTask;
            SetAuthenticationHeader(originalHttpRequestMessage, authResponse);
        }

        public async Task<bool> RefreshAccessToken(HttpRequestMessage originalHttpRequestMessage)
        {
            refreshTokenTask = TaskWhenEnd(refreshTokenTask, () => DoRefreshToken());
            var authResponse = await refreshTokenTask;
            return SetAuthenticationHeader(originalHttpRequestMessage, authResponse);
        }

        private bool SetAuthenticationHeader(HttpRequestMessage httpRequestMessage, PixivOAuthResponse authResponse)
        {
            if (authResponse == null)
                return false;

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.AccessToken);
            return true;
        }

        private async Task<PixivOAuthResponse> DoAuthToken()
        {
            var authResponse = await _authStore.GetAuthResponseAsync();
            if (authResponse == null)
            {
                var result = await _oAuth2Api.AuthToken(this._oAuth2TokenPath, this._request, this._request.GrantType);

                if (result != null && result.IsSuccessStatusCode && result.Content?.Response != null)
                {
                    authResponse = result.Content.Response;
                    await _authStore.AddAuthResponseAsync(authResponse);
                }
            }
            return authResponse;
        }

        private async Task<PixivOAuthResponse> DoRefreshToken()
        {
            var authResponse = await _authStore.GetAuthResponseAsync();
            var canRefreshToken = authResponse != null && !string.IsNullOrWhiteSpace(authResponse.RefreshToken);
            IHttpResult<PixivOAuthProtocal<PixivOAuthResponse>> result = null;
            if (canRefreshToken)
            {
                result = await _oAuth2Api.RefreshToken(this._oAuth2TokenPath, this._request, authResponse.RefreshToken, "refresh_token");

                if (result != null && result.IsSuccessStatusCode)
                {
                    authResponse = result.Content.Response;
                    await _authStore.AddAuthResponseAsync(authResponse);
                }
            }

            if (!canRefreshToken || (result != null && result.StatusCode == HttpStatusCode.BadRequest))
            {
                authTokenTask = TaskWhenEnd(authTokenTask, () => DoAuthToken());
                authResponse = await authTokenTask;
            }

            return authResponse;
        }

        private Task<T> TaskWhenEnd<T>(Task<T> task, Func<Task<T>> valueFactory)
        {
            if (Check(task))
            {
                lock (_syncObject)
                {
                    if (Check(task))
                    {
                        task = valueFactory();
                    }
                }
            }
            return task;

            bool Check(Task t)
            {
                return t == null || t.IsCanceled || t.IsCompleted || t.IsFaulted;
            }
        }
    }

    public class PixivOAuthProtocal<TR>
    {
        [JsonProperty("response")]
        public TR Response { get; set; }
    }

    public class PixivOAuthResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }

    public class PixivOAuthRequest
    {
        [HttpAlias("client_id")]
        public string ClientId { get; set; }
        [HttpAlias("client_secret")]
        public string ClientSecret { get; set; }
        [HttpAlias("username")]
        public string Username { get; set; }
        [HttpAlias("password")]
        public string Password { get; set; }
        [HttpAlias("device_token")]
        public string DeviceToken { get; set; }

        [HttpAlias("get_secure_url")]
        public string GetSecureUrl { get; set; }

        [HttpIgnore]
        [HttpAlias("grant_type")]
        public string GrantType { get; set; }
    }

    public interface IOAuth2Api
    {
        [Route("{oAuth2TokenPath}")]
        [HttpPost]
        Task<IHttpResult<PixivOAuthProtocal<PixivOAuthResponse>>> AuthToken([PathParam]string oAuth2TokenPath, [FormBody]PixivOAuthRequest request, [FormBody]string grant_type);

        [Route("{oAuth2TokenPath}")]
        [HttpPost]
        Task<IHttpResult<PixivOAuthProtocal<PixivOAuthResponse>>> RefreshToken([PathParam]string oAuth2TokenPath, [FormBody]PixivOAuthRequest request, [FormBody]string refresh_token, [FormBody]string grant_type);
    }
}

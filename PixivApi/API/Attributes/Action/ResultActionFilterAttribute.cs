using EasyHttpClient;
using EasyHttpClient.ActionFilters;
using EasyHttpClient.Attributes;
using EasyHttpClient.Utilities;
using PixivApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PixivApi.API.Attributes
{
    public class ResultActionFilterAttribute : ActionFilterAttribute
    {
        public string Name => string.Empty;

        public ParameterScope Scope { get; set; } = ParameterScope.Query;

        public override async Task<IHttpResult> ActionInvoke(ActionContext context, Func<Task<IHttpResult>> continuation)
        {
            var result = await continuation();
            if (!result.IsSuccessStatusCode)
            {
                throw new PixivApiException(result.ErrorMessage, result.StatusCode);
            }
            return result;
        }
    }
}

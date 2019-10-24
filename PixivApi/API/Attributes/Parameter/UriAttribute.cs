using EasyHttpClient.Attributes;
using EasyHttpClient.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PixivApi.API.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class UriAttribute : Attribute, IParameterScopeAttribute
    {
        public string Name => string.Empty;
        public ParameterScope Scope { get; set; } = ParameterScope.Path;

        public void ProcessParameter(HttpRequestMessageBuilder requestBuilder, ParameterInfo parameterInfo, object parameterValue)
        {
            Uri uri=null;
            if (parameterValue is string stringValue)
            {
                uri = new Uri(stringValue);
            }
            if (parameterValue is Uri uriValue)
            {
                uri = uriValue;
            }

            if (uri != null)
            {
                requestBuilder.UriBuilder = new UriBuilder(uri);
            }

        }
    }
}

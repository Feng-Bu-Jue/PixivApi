using EasyHttpClient.Attributes;
using EasyHttpClient.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PixivApi.Net.API.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class CastStringAttribute : Attribute, IParameterScopeAttribute
    {
        public string Name => string.Empty;

        public ParameterScope Scope { get; set; } = ParameterScope.Query;

        public void ProcessParameter(HttpRequestMessageBuilder requestBuilder, ParameterInfo parameterInfo, object parameterValue)
        {
            var type = parameterValue.GetType();
            string value = null;
            if (type.IsEnum)
            {
                value = Enum.GetName(type, parameterValue);
            }
            else if (typeof(bool) == type)
            {
                value = parameterValue.ToString().ToLower();
            }
            else
            {
                throw new NotSupportedException($"{type} cast to string not yet implement");
            }

            if (value != null)
            {
                if (Scope == ParameterScope.Query)
                {
                    requestBuilder.QueryStrings.Add(parameterInfo.Name, value);
                }
                else if (Scope == ParameterScope.Form)
                {
                    requestBuilder.FormBodys.Add(parameterInfo.Name, value);
                }
            }
        }
    }
}

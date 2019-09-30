using EasyHttpClient.Attributes;
using EasyHttpClient.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PixivApi.API.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class EnumCastStringAttribute : Attribute, IParameterScopeAttribute
    {
        public string Name => string.Empty;

        public ParameterScope Scope { get; set; } = ParameterScope.Query;

        public void ProcessParameter(HttpRequestMessageBuilder requestBuilder, ParameterInfo parameterInfo, object parameterValue)
        {
            var type = parameterValue.GetType();
            if (type.IsEnum)
            {
                var value = Enum.GetName(type, parameterValue);
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

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

        public ParameterScope Scope => ParameterScope.Query;

        public void ProcessParameter(HttpRequestMessageBuilder requestBuilder, ParameterInfo parameterInfo, object parameterValue)
        {
            var type = parameterValue.GetType();
            if (type.IsEnum)
            {
                Enum.GetName(type, parameterValue);
            }
        }
    }
}

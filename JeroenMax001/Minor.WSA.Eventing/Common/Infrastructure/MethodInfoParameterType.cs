using System;
using System.Reflection;

namespace Common.Infrastructure
{
    public class MethodInfoParameterType
    {
        public MethodInfo MethodInfo { get; set; }
        public Type ParameterType { get; set; }

        public MethodInfoParameterType(MethodInfo methodInfo, Type parameterType)
        {
            MethodInfo = methodInfo;
            ParameterType = parameterType;
        }
    }
}

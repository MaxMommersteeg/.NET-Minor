using System;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class HandleAttribute : Attribute
    {
        public string RoutingKey { get; set; }
    }
}

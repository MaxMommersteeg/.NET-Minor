using System;

namespace Minor.WSA.Eventing
{
    public class RoutingKeyAttribute : Attribute
    {
        public RoutingKeyAttribute(string topic)
        {
        }
    }
}
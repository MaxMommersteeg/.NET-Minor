using System;

namespace Minor.WSA.Eventing
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class HandlesAttribute : Attribute
    {
        private string v;

        public HandlesAttribute(string v)
        {
            this.v = v;
        }
    }
}
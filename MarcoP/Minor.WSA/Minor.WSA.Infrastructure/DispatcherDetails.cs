using System;
using Minor.WSA.Common;
using System.Reflection;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;

namespace Minor.WSA.Infrastructure
{
    public class DispatcherDetails
    {
        private Type _eventType;
        private MethodInfo _callbackMethod;

        public DispatcherDetails(Type eventType, MethodInfo callbackMethod)
        {
            _eventType = eventType;
            _callbackMethod = callbackMethod;
        }

        public void Dispatch(object instance, BasicDeliverEventArgs e)
        {
            byte[] body = e.Body;
            string message = Encoding.Unicode.GetString(body);

            var domainEvent = JsonConvert.DeserializeObject(message, _eventType);
            _callbackMethod.Invoke(instance, new object[] { domainEvent });
        }

    }
}
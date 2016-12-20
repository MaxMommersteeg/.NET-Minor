using Minor.RoWe.Eventbus.Dispatchers;
using Minor.RoWe.Eventbus.Connectors;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.EventListener.Services;
using Minor.Case2.Events.RDWIntegration;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.EventListener.Dispatchers
{
    public class ApkDispatcher : EventDispatcher
    {
        private readonly ApkEventService _service;

        public ApkDispatcher(IRabbitMqConnection connection, ApkEventService service) : base(connection)
        {
            _service = service;   
        }

        public override string RoutingKey
        {
            get
            {
                return "Minor.Case2.MaRoWe.RWD.Integration.#";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void HandlerApkEvent(ApkAfgemeldEvent e)
        {
            _service.HandlerApkEvent(e);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            _service?.Dispose();
        }
    }
}

using BKE.Common;
using BKE.GameAdministation.Events;

namespace BKE.GameAdministration.Infrastructure
{
    public interface IEventPublisher
    {
        void Publish(DomainEvent domainEvent);
    }
}
using Common.Event;

namespace Common.Infrastructure
{
    public interface IEventPublisher
    {
        void Publish(DomainEvent domainEvent);
    }
}

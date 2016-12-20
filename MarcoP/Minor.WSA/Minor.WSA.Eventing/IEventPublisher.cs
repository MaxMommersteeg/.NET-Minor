namespace Minor.WSA.Eventing
{
    public interface IEventPublisher
    {
        void Publish(DomainEvent domainEvent);
    }
}
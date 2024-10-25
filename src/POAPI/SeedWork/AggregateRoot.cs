using MediatR;

namespace POAPI.SeedWork
{
  public abstract class AggregateRoot : Entity
  {
    public readonly IList<INotification> events = new List<INotification>();

    public void AddEvent(INotification @event)
    {
      events.Add(@event);
    }

    public void ClearEvents()
    {
      events.Clear();
    }
  }
}

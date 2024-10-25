using MediatR;
using POAPI.Aggregates.PQ;

namespace POAPI.Aggregates.PO
{
  public class TransformAsOrderedHandler : INotificationHandler<TransformAsOrdered>
  {
    private readonly IPurchaseOrderRepository repository;


    public TransformAsOrderedHandler(IPurchaseOrderRepository repository)
    {
      this.repository = repository;
    }

    public Task Handle(TransformAsOrdered notification, CancellationToken cancellationToken)
    {
      // veritabanına purchase order kaydetme logic işletelim

      var po = PurchaseOrder.Create(notification.PurchaseQuoteId, notification.PurchaseRequestId);
      this.repository.Create(po); // Insert State getir.

      return Task.CompletedTask;

    }
  }
}

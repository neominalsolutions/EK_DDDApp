using MediatR;
using POAPI.Aggregates.PO;

namespace POAPI.Aggregates.PR
{
  public class PurchaseRequestSubmitHandler : INotificationHandler<PurchaseOrderSubmited>
  {
    // Port
    private IPurchaseRequestRepository repository;

    public PurchaseRequestSubmitHandler(IPurchaseRequestRepository repository)
    {
      this.repository = repository;
    }

    public Task Handle(PurchaseOrderSubmited notification, CancellationToken cancellationToken)
    {
      var request = this.repository.FindById(notification.PurchaseRequestId);

      request.Complete();

      repository.Update(request); // Update State işaretledik.

      return Task.CompletedTask;
    }
  }
}

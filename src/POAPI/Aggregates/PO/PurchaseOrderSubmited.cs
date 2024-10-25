using MediatR;

namespace POAPI.Aggregates.PO
{
  // Bu eventi işleyen serviste bu eventten gelen Id değeri Completed status çekildecek.
  public record PurchaseOrderSubmited(string PurchaseRequestId):INotification;
  
}

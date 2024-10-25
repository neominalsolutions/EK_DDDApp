using MediatR;

namespace POAPI.Aggregates.PQ
{
  public record TransformAsOrdered(string PurchaseRequestId,string PurchaseQuoteId):INotification;
  
}

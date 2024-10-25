using POAPI.Aggregates.PO;
using POAPI.SeedWork;
using POAPI.Shared;

namespace POAPI.Aggregates.PQ
{



  public class PurchaseQuote : AggregateRoot
  {
    public Money OfferAmount { get; init; } // fiyat teklifi
    public string PurchaseRequestId { get; init; }
    public PurchaseQuoteStatus Status { get; private set; }

    // EF Migrationda hata veriyor mecbur açtık.
    public PurchaseQuote()
    {

    }
    private PurchaseQuote(Money offerAmount, string purchaseRequestId)
    {
      PurchaseRequestId = purchaseRequestId;
      OfferAmount = offerAmount;
      Status = PurchaseQuoteStatus.Submitted;
    }

    public static PurchaseQuote Create(Money offerAmount, string purchaseRequestId)
    {
      return new PurchaseQuote(offerAmount, purchaseRequestId);
    }

    public void TransformAsOrder()
    {
      Status = PurchaseQuoteStatus.Approved;
      // Event fırlatıp Order oluştur.
      AddEvent(new TransformAsOrdered(PurchaseRequestId, Id));
      AddEvent(new PurchaseOrderSubmited(PurchaseRequestId));
    }

    public void Reject()
    {
      Status = PurchaseQuoteStatus.Rejected;
    }


  }
}

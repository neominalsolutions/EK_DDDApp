using POAPI.SeedWork;

namespace POAPI.Aggregates.PQ
{
  public class PurchaseQuoteStatus : Enumeration
  {
    public static PurchaseQuoteStatus Submitted => new PurchaseQuoteStatus(100, "Submitted");
    public static PurchaseQuoteStatus Approved => new PurchaseQuoteStatus(300, "Approved");
    public static PurchaseQuoteStatus Rejected => new PurchaseQuoteStatus(300, "Rejected");

    public PurchaseQuoteStatus(int id, string name) : base(id, name)
    {
    }
  }
}

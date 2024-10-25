using POAPI.SeedWork;

namespace POAPI.Aggregates.PR
{
  public class PurchaseRequestStatus : Enumeration
  {
    public static PurchaseRequestStatus Submitted => new PurchaseRequestStatus(100, "Submitted");
    public static PurchaseRequestStatus Canceled => new PurchaseRequestStatus(200, "Canceled");

    public static PurchaseRequestStatus Completed => new PurchaseRequestStatus(200, "Completed");

    public PurchaseRequestStatus(int id, string name) : base(id, name)
    {
    }
  }
}

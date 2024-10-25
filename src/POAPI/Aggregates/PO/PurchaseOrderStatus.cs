using POAPI.SeedWork;

namespace POAPI.Aggregates.PO
{
  public class PurchaseOrderStatus : Enumeration
  {
    public static PurchaseOrderStatus Submitted => new PurchaseOrderStatus(100, "Submitted");

    public static PurchaseOrderStatus Invoiced => new PurchaseOrderStatus(200, "Invoiced");
    public PurchaseOrderStatus(int id, string name) : base(id, name)
    {
    }
  }
}

using POAPI.Aggregates.PO;

namespace POAPI.Data
{
  // Adapter
  public class EFPurchaseOrderRepository : EFRepository<PoDbContext, PurchaseOrder>, IPurchaseOrderRepository // Port
  {
    public EFPurchaseOrderRepository(PoDbContext db) : base(db)
    {
    }
  }
}

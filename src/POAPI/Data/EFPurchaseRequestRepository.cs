using POAPI.Aggregates.PR;
using POAPI.SeedWork;

namespace POAPI.Data
{
  public class EFPurchaseRequestRepository : EFRepository<PoDbContext, PurchaseRequest>, IPurchaseRequestRepository
  {
    public EFPurchaseRequestRepository(PoDbContext db) : base(db)
    {
    }
  }
}

using POAPI.Aggregates.PQ;

namespace POAPI.Data
{
  public class EFPurchaseQuoteRepository : EFRepository<PoDbContext, PurchaseQuote>, IPurchaseQuoteRepository
  {
    public EFPurchaseQuoteRepository(PoDbContext db) : base(db)
    {
    }
  }
}

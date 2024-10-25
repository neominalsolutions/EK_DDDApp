using POAPI.SeedWork;
using POAPI.Shared;

namespace POAPI.Aggregates.PR
{
  // {description:'a',money:{amount,currency},status:{id,name}, items:[]}
  // budget_amount, budget_currency, status_id, status_name
  public class PurchaseRequest : AggregateRoot
  {
    public string Description { get; init; } // 2x Mouse 1x Klavye

    public PurchaseRequestStatus Status { get; private set; } // State

    public Money Budget { get; init; } // Bütçe

    public PurchaseRequest()
    {

    }

    // private constructor
    private PurchaseRequest(Money budget, string description)
    {
      Description = description;
      Status = PurchaseRequestStatus.Submitted;
      Budget = budget;
    }

    // Factory ilk state 1.aşama
    public static PurchaseRequest Create(Money budget, string description)
    {
      return new PurchaseRequest(budget, description);
    }

    // Talep iptal edildiğinde state güncellensin
    public void Cancel()
    {
      Status = PurchaseRequestStatus.Canceled;
    }

    /// <summary>
    /// PO dönüştüğünde artık tekliflendirme ile ilgilenmiyoruz. Bu sebeple süreci completed'a çevirdik.
    /// </summary>
    public void Complete()
    {
      Status = PurchaseRequestStatus.Completed;
    }

  }
}

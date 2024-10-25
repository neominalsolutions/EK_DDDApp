using POAPI.SeedWork;

namespace POAPI.Shared
{
  public class Money : ValueObject
  {

    public string Currency { get; init; }
    public decimal Amount { get; init; }

    public Money(string currency, decimal amount)
    {
      Currency = currency;
      Amount = amount;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Currency.Trim().ToUpper();
      yield return Math.Round(Amount, 2); // 77.90
    }
  }
}

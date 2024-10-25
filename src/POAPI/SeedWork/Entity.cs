namespace POAPI.SeedWork
{
  public abstract class Entity
  {
    public string Id { get; init; }

    protected Entity()
    {
      Id = Guid.NewGuid().ToString();
    }
  }
}

namespace POAPI.SeedWork
{
  public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
  {
    void Create(TAggregateRoot root);
    void Update(TAggregateRoot root);
    void Delete(string Id);
    List<TAggregateRoot> FindAll();
    TAggregateRoot FindById(string Id);
  }
}

using Microsoft.EntityFrameworkCore;
using POAPI.SeedWork;
using System.Linq.Expressions;

namespace POAPI.Data
{
  public abstract class EFRepository<TContext, TEntity> : IRepository<TEntity>
    where TEntity : AggregateRoot
    where TContext : DbContext
  {
    protected readonly TContext db;
    protected readonly DbSet<TEntity> table;


    public EFRepository(TContext db)
    {
      this.db = db;
      this.table = db.Set<TEntity>(); // tabloyu db deki entity bağladık.
    }



    public virtual void Create(TEntity entity)
    {
      this.table.Add(entity);
    }

    public virtual void Delete(string Id)
    {
      var entity = FindById(Id);
      this.table.Remove(entity);
     
    }

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> lamda)
    {
      return this.table.Where(lamda).ToList();
    }

    public List<TEntity> FindAll()
    {
      return this.table.ToList();
    }

    public virtual TEntity FindById(string Id)
    {
      var entity = table.Find(Id);

      if (entity is null)
      {
        throw new Exception("Entity Not Found");
      }

      return entity;
    }


    public virtual void Update(TEntity entity)
    {
      this.table.Update(entity);
    }
  }
}

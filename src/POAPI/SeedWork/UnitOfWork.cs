using POAPI.Data;

namespace POAPI.SeedWork
{
  public class UnitOfWork : IUnitOfWork
  {

    private readonly PoDbContext db;

    public UnitOfWork(PoDbContext db)
    {
      this.db = db;
    }

    public void Commit()
    {

      using (var tran = this.db.Database.BeginTransaction())
      {
        try
        {
          this.db.SaveChanges();

          tran.Commit();
        }
        catch (Exception)
        {
          tran.Rollback();
          throw;
        }
      }

       
    }
  }
}

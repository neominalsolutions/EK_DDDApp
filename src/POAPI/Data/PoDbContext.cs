using MediatR;
using Microsoft.EntityFrameworkCore;
using POAPI.Aggregates.PO;
using POAPI.Aggregates.PQ;
using POAPI.Aggregates.PR;
using POAPI.SeedWork;
using POAPI.Shared;

namespace POAPI.Data
{
  public class PoDbContext : DbContext
  {
    private readonly IMediator mediator;

    public PoDbContext(DbContextOptions<PoDbContext> opt, IMediator mediator) : base(opt)
    {
      this.mediator = mediator;
    }

    public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
    public DbSet<PurchaseQuote> PurchaseQuotes { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Enumeration ve ValueObject için aşağıdaki gibi davranıyoruz.
      // Veritabanına doğru bir şekilde mapleme yap.
      modelBuilder.Entity<PurchaseRequest>().OwnsOne<Money>(x => x.Budget).Property(x => x.Amount).HasColumnName("Budget_Amount");
      modelBuilder.Entity<PurchaseRequest>().OwnsOne<Money>(x => x.Budget).Property(x => x.Currency).HasColumnName("Budget_Currency");

      modelBuilder.Entity<PurchaseRequest>().OwnsOne<PurchaseRequestStatus>(x => x.Status).Property(x => x.Id).HasColumnName("Status_Id");
      modelBuilder.Entity<PurchaseRequest>().OwnsOne<PurchaseRequestStatus>(x => x.Status).Property(x => x.Name).HasColumnName("Status_Name");



      modelBuilder.Entity<PurchaseQuote>().OwnsOne<Money>(x => x.OfferAmount).Property(x => x.Amount).HasColumnName("Offer_Amount");
      modelBuilder.Entity<PurchaseQuote>().OwnsOne<Money>(x => x.OfferAmount).Property(x => x.Currency).HasColumnName("Offer_Currency");

      modelBuilder.Entity<PurchaseQuote>().OwnsOne<PurchaseQuoteStatus>(x => x.Status).Property(x => x.Id).HasColumnName("Status_Id");
      modelBuilder.Entity<PurchaseQuote>().OwnsOne<PurchaseQuoteStatus>(x => x.Status).Property(x => x.Name).HasColumnName("Status_Name");


      modelBuilder.Entity<PurchaseOrder>().OwnsOne<PurchaseOrderStatus>(x => x.Status).Property(x => x.Id).HasColumnName("Status_Id");
      modelBuilder.Entity<PurchaseOrder>().OwnsOne<PurchaseOrderStatus>(x => x.Status).Property(x => x.Name).HasColumnName("Status_Name");


      base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
      // ChangeTracker ile entitylerin Modified, Removed, Added state takibini yapıyoruz.
      var domainEntities = this.ChangeTracker
                             .Entries<AggregateRoot>()
                             .Where(x => x.Entity.events != null && x.Entity.events.Any());

      var domainEvents = domainEntities
          .SelectMany(x => x.Entity.events)
          .ToList();

      // Pre Save
      foreach (var domainEvent in domainEvents)
      {
        // aggregate nesneleri üzerine tanımlanmış olan eventleri yayınla.
         mediator.Publish(domainEvent).Wait();
      }

      // aggregate root objeleri üzerindeki eventleri temizle.
      domainEntities.ToList()
               .ForEach(entity => entity.Entity.ClearEvents());

      // veri tabanına verileri kaydetmeden önce ilgili entity ait eventleri fırlatacağız.
      return base.SaveChanges();
    }
  }
}

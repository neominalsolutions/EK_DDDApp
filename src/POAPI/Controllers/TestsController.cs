using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POAPI.Aggregates.PQ;
using POAPI.Aggregates.PR;
using POAPI.Data;
using POAPI.SeedWork;

namespace POAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestsController : ControllerBase
  {
    private readonly IPurchaseRequestRepository purchaseRequestRepository;
    private readonly IPurchaseQuoteRepository purchaseQuoteRepository;
    private readonly PoDbContext db;
    private readonly IUnitOfWork unitOfWork;

    public TestsController(IPurchaseRequestRepository purchaseRequestRepository, PoDbContext db, IPurchaseQuoteRepository purchaseQuoteRepository, IUnitOfWork unitOfWork)
    {
      this.purchaseRequestRepository = purchaseRequestRepository;
      this.purchaseQuoteRepository = purchaseQuoteRepository;
      this.db = db;
      this.unitOfWork = unitOfWork;
    }

    [HttpPost("poRequest")] // 1. Aşamada Request Db de oluşmalı
    public IActionResult CreatePurchaseRequest()
    {
      var request = PurchaseRequest.Create(new Shared.Money("TL", 5000), "5 adet Yazıcı");

      this.purchaseRequestRepository.Create(request);
      this.db.SaveChanges();


      return Ok();
    }

    [HttpPost("poQoute")] // 2. Aşamada Request Db de oluşmalı
    public IActionResult CreatePurchaseQoutes()
    {
      var q1 = PurchaseQuote.Create(new Shared.Money("TL",5000), "4a520b2b-af70-4103-863f-b09a8e09d1f3");
      var q2 = PurchaseQuote.Create(new Shared.Money("TL", 7500), "4a520b2b-af70-4103-863f-b09a8e09d1f3");
 
      this.purchaseQuoteRepository.Create(q1);
      this.purchaseQuoteRepository.Create(q2);
      this.unitOfWork.Commit();


      q1.Reject();
      q2.TransformAsOrder();


      this.purchaseQuoteRepository.Update(q1);
      this.purchaseQuoteRepository.Update(q2);


      this.unitOfWork.Commit();

      // Purchase Order oluşmuş olması lazım.


      return Ok();
    }

  }
}

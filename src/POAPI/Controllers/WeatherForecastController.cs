using Microsoft.AspNetCore.Mvc;
using POAPI.Aggregates.PO;
using POAPI.Aggregates.PQ;
using POAPI.Aggregates.PR;

namespace POAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
          "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
      };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {

      var request =  PurchaseRequest.Create(new Shared.Money("Tl", 50000), "2x1 Laptop");

      request.Cancel();

      var q1 = PurchaseQuote.Create(new Shared.Money("TL", 5500), request.Id);
      var q2 = PurchaseQuote.Create(new Shared.Money("TL", 3500), request.Id);
      var q3 = PurchaseQuote.Create(new Shared.Money("TL", 4200), request.Id);

      // Tekliflendirme yapýlýnca PurchaseRequest Aggregatedeki Request artýk. Bir daha tekliflendirme olmamasý için Kitlensin.

      q1.Reject();
      q2.TransformAsOrder();




      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToArray();
    }
  }
}

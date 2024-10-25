using Microsoft.EntityFrameworkCore;
using POAPI.Aggregates.PO;
using POAPI.Aggregates.PQ;
using POAPI.Aggregates.PR;
using POAPI.Data;
using POAPI.SeedWork;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// MS Veritaban� ba�lant�s�
builder.Services.AddDbContext<PoDbContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});


// Uygulama IoC Gereksinimleri
// T�m Handlerlar� reflection ile mediator nesnesi i�erisinde tan�mla.
builder.Services.AddMediatR(opt =>
{
  opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

// Repository Kodlar�
builder.Services.AddScoped<IPurchaseOrderRepository, EFPurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseQuoteRepository, EFPurchaseQuoteRepository>();
builder.Services.AddScoped<IPurchaseRequestRepository, EFPurchaseRequestRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using EFCoreApp.DataAccess.Repositories.Abstract;
using EFCoreApp.DataAccess.Repositories.Concrete;
using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.DataAccess.Services.Concrete;
using EFCoreApp.DataAccess.UnitOfWork;
using EFCoreApp.Domain;
using EFCoreApp.Domain.Mapers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings.DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<IBusinessUnitRepository, BusinessUnitRepository>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IBusinessUnitService, BusinessUnitService>();
builder.Services.AddAutoMapper(typeof(MapProfile));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

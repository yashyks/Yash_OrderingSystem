using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions.Logging;
using OrderingSystem.DAL;
using OrderingSystem.DAL.Interface;
using OrderingSystem.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration("nlog.config");

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DB Connection.
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//repository entries
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// NLog as the logging provider
builder.Logging.ClearProviders();
builder.Logging.AddNLog();

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

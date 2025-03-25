using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Services;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Rental_Management.DataAccess;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Rental_Management.DataAccess")));

builder.Services.AddLogging(configure => configure.AddConsole());

// Add services to the container.

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddScoped<ILandlordService, LandlordService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

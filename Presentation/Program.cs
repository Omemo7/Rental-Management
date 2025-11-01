using Business.Application.Abstractions;
using Business.Application.Buildings;
using Business.Application.Landlords;
using Infrastructure.Identity;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Infrastructure;
using RentalManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Application + Infrastructure DI
//builder.Services.AddApplication();  
var cs = builder.Configuration.GetConnectionString("DefaultConnection")
         ?? throw new InvalidOperationException("Missing connection string 'Default'.");
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(cs));


builder.Services
    .AddIdentityCore<ApplicationUser>(o => o.User.RequireUniqueEmail = true)
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDbContext>();





// 4) Infrastructure registrations
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<ILandlordRepository, LandlordRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();


builder.Services.AddScoped<ILandlordService, LandlordService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
// Controllers (or Minimal APIs, see below)
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers(); // or MapGroup(...) for minimal APIs

app.Run();

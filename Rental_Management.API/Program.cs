using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Services;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Rental_Management.DataAccess;
using Rental_Management.Business.Mappers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Rental_Management.DataAccess")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddLogging(configure => configure.AddConsole());
builder.Services.AddLogging(configure => configure.AddDebug());
// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddScoped<IApartmentRentalService, ApartmentRentalService>();
builder.Services.AddScoped<IApartmentRentalRepository, ApartmentRentalRepository>();

builder.Services.AddScoped<IRentalRepository, RentalRepository>();

builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();


builder.Services.AddScoped<IApartmentBuildingService, ApartmentBuildingService>();
builder.Services.AddScoped<IApartmentBuildingRepository,ApartmentBuildingRepository>();

builder.Services.AddScoped<ILandlordService, LandlordService>();
builder.Services.AddScoped<ILandlordRepository, LandlordRepository>();

builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();

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
